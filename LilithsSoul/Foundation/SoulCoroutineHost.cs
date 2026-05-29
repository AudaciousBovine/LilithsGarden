using BepInEx.Unity.IL2CPP.Utils.Collections;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

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
//  This is the same pattern used by ZUI's ImageDownloader.
//
//  Registration:
//  ─────────────
//  ClassInjector.RegisterTypeInIl2Cpp<SoulCoroutineHost>() MUST
//  be called in SoulPlugin.Load() before any coroutine is started.
//  The host GameObject is created lazily on first use.
//
//  [PERFORMANCE] One persistent GameObject per Soul session.
//                Zero per-frame overhead — MonoBehaviour has no
//                Update() or other tick methods.
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
        _instance = go.AddComponent<SoulCoroutineHost>();

        SoulLogger.Debug("LilithsSoul.SoulCoroutineHost",
            "Coroutine host created.");
    }

    // Required IL2CPP constructor.
    public SoulCoroutineHost(System.IntPtr pointer) : base(pointer) { }
}