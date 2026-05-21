using ProjectM;
using Unity.Entities;


namespace LilithsSoul.Foundation;

public static class EntityExtensions
{
    public delegate void WithRefHandler<T>(ref T item) where T : struct;

    /// <summary>
    /// Reads a component, modifies it via the provided action, then writes it back.
    /// Handles the get/modify/set pattern in one call.
    /// Does nothing if the entity does not have the component.
    /// </summary>
    public static void With<T>(this Entity entity, WithRefHandler<T> action) where T : struct
    {
        if (!entity.Has<T>()) return;
        T item = Soul.EntityManager.GetComponentData<T>(entity);
        action(ref item);
        Soul.EntityManager.SetComponentData(entity, item);
    }

    /// <summary>
    /// Reads a component from the entity.
    /// </summary>
    public static T Read<T>(this Entity entity) where T : struct
        => Soul.EntityManager.GetComponentData<T>(entity);

    /// <summary>
    /// Writes a component to the entity.
    /// Does nothing if the entity does not have the component.
    /// </summary>
    public static void Write<T>(this Entity entity, T componentData) where T : struct
    {
        if (!entity.Has<T>()) return;
        Soul.EntityManager.SetComponentData(entity, componentData);
    }

    /// <summary>
    /// Returns true if the entity has the specified component.
    /// </summary>
    public static bool Has<T>(this Entity entity) where T : struct
        => Soul.EntityManager.HasComponent<T>(entity);

    /// <summary>
    /// Adds a component to the entity if it does not already have it.
    /// </summary>
    public static void Add<T>(this Entity entity) where T : struct
    {
        if (!entity.Has<T>())
            Soul.EntityManager.AddComponent<T>(entity);
    }

    /// <summary>
    /// Removes a component from the entity if it has it.
    /// </summary>
    public static void Remove<T>(this Entity entity) where T : struct
    {
        if (entity.Has<T>())
            Soul.EntityManager.RemoveComponent<T>(entity);
    }

    /// <summary>
    /// Reads a DynamicBuffer from the entity.
    /// </summary>
    public static DynamicBuffer<T> ReadBuffer<T>(this Entity entity) where T : struct
        => Soul.EntityManager.GetBuffer<T>(entity);

    /// <summary>
    /// Adds a DynamicBuffer to the entity and returns it.
    /// </summary>
    public static DynamicBuffer<T> AddBuffer<T>(this Entity entity) where T : struct
        => Soul.EntityManager.AddBuffer<T>(entity);

    /// <summary>
    /// Attempts to get a DynamicBuffer from the entity.
    /// Returns false and default buffer if the component is not present.
    /// </summary>
    public static bool TryGetBuffer<T>(this Entity entity, out DynamicBuffer<T> buffer) where T : struct
    {
        if (Soul.EntityManager.HasComponent<T>(entity))
        {
            buffer = Soul.EntityManager.GetBuffer<T>(entity);
            return true;
        }
        buffer = default;
        return false;
    }

    /// <summary>
    /// Attempts to read a component from the entity.
    /// Returns false and default value if the component is not present.
    /// </summary>
    public static bool TryGetComponent<T>(this Entity entity, out T componentData) where T : struct
    {
        componentData = default;
        if (entity.Has<T>())
        {
            componentData = entity.Read<T>();
            return true;
        }
        return false;
    }
}