# LilithsGarden
A modular V Rising mod suite












[LilithsHeart] >
    > Heart.cs
    > HeartPlugin.cs
    > HeartPaths.cs
    > LilithsLogger.cs
    
    > [Systems]
        > EntityExtensions.cs
        > HeartEventBus.cs - pub/sub infrastructure
        > HeartEvents.cs - event TYPE definitions
        > HeartRegistry.cs - registers modules installed
        > PrefabNameResolver.cs - reflects over registry classes, writes JSON files
        > PrefabNamesExporter.cs - reads JSON files, looks up names to GUID
    > [Resources]
        > Equipment.cs - Sorted Equipment list
        > Items.cs - Sorted Items list
        > PrefabNameAttribute.cs - Attribute that gives names to prefabs
        > Recipes.cs - Sorted recipes list
        > Stations.cs - Sorted stations list
        > Unsorted.cs - The rest of the prefabGUIDs
        > Weapons.cs - Sorted weapon list
    > [Patches]
    > [Network]
    > [Config]