using BepInEx.Unity.IL2CPP.Utils.Collections;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;
using LilithsSoul.Foundation;

// ============================================================
//  SoulCoroutineHost — LilithsSoul
//  LilithsSoul/Foundation/SoulCoroutineHost.cs
//
//  A minimal MonoBehaviour that provides coroutine execution
//  for Soul services that need async Unity operations —
//  specifically IconDownloader's UnityWebRequest downloads.
//
//  Why needed:
//  ────────────
//  Unity coroutines must be started on a MonoBehaviour instance.
//  In an IL2CPP BepInEx plugin there is no built-in MonoBehaviour
//  host. We create one, register it with IL2CPP's type system,
//  attach it to a persistent GameObject, and use it as the host
//  for all Soul coroutines.
//
//  Registration:
//  ─────────────
//  ClassInjector.RegisterTypeInIl2Cpp<SoulCoroutineHost>() MUST
//  be called in SoulPlugin.Load() before any coroutine is started.
//
//  [CHANGED] CreateHost() now uses the non-generic IL2CPP
//            AddComponent overload via Il2CppType.Of<T>() and
//            .Cast<T>(). The generic AddComponent<T>() throws
//            TypeInitializationException in IL2CPP if the type
//            is not fully resolved at call time.
//
//  [PERFORMANCE] One persistent GameObject per Soul session.
//                Zero per-frame overhead — no Update() or tick.
// ============================================================

namespace LilithsSoul.Foundation;

public class SoulCoroutineHost : MonoBehaviour
{
    static SoulCoroutineHost? _instance;

    /// <summary>
    /// Registers SoulCoroutineHost with IL2CPP's type system.
    /// Must be called in SoulPlugin.Load() before any coroutine is started.
    /// </summary>
    public static void Register()
    {
        ClassInjector.RegisterTypeInIl2Cpp<SoulCoroutineHost>();
    }

    /// <summary>
    /// Starts a coroutine on the persistent host instance.
    /// Creates the host GameObject on first call.
    /// </summary>
    public static void Run(System.Collections.IEnumerator routine)
    {
        if (_instance == null)
            CreateHost();

        _instance!.StartCoroutine(routine.WrapToIl2Cpp());
    }

    static void CreateHost()
    {
        var go = new GameObject("SoulCoroutineHost");
        UnityEngine.Object.DontDestroyOnLoad(go);

        // [CHANGED] Use non-generic IL2CPP AddComponent to avoid
        // TypeInitializationException with generic AddComponent<T>().
        _instance = go.AddComponent(Il2CppType.Of<SoulCoroutineHost>())
            .Cast<SoulCoroutineHost>();

        SoulLogger.Debug("LilithsSoul.SoulCoroutineHost",
            "Coroutine host created.");
    }

    // Required IL2CPP constructor.
    public SoulCoroutineHost(System.IntPtr pointer) : base(pointer) { }
}