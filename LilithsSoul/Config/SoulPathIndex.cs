// ============================================================
//  SoulPathIndex — LilithsSoul
//  LilithsSoul/Config/SoulPathIndex.cs
//
//  Single source of truth for every filesystem path used by
//  LilithsSoul and its child client modules.
//
//  All Soul config lives under:
//      BepInEx/config/LilithsSoul/
//
//  Structure:
//      LilithsSoul/
//          LilithsSoul.cfg                 ← Soul core settings
//          servers.json                    ← connection string → folder name map
//          Icons/                          ← custom PNG icons + URL download cache
//              vitae.png
//              Weapons/
//                  bone-sword.png
//          <ServerIdentity>/
//              sync.json                   ← cached ServerSyncPayload per server
//
//  [CHANGED] Added IconsDir.
//            Soul's IconPatcher scans this directory recursively
//            for *.png files, building a filename → full path lookup.
//            URL downloads are also saved here (flat, no subfolder)
//            so they are found on subsequent connects without
//            re-downloading.
//
//  ServerIdentity is the sanitized server name received in the
//  ServerSyncPayload. Each server the client connects to gets
//  its own subfolder so configs don't collide.
// ============================================================

namespace LilithsSoul.Config;

public static class SoulPathIndex
{
    // ── Root ────────────────────────────────────────────────

    /// <summary>
    /// BepInEx/config/LilithsSoul/
    /// All Soul config lives under this directory.
    /// </summary>
    public static readonly string Root = Path.Combine(
        BepInEx.Paths.ConfigPath,
        "LilithsSoul"
    );

    // ── .cfg files ──────────────────────────────────────────

    /// <summary>
    /// BepInEx/config/LilithsSoul/LilithsSoul.cfg
    /// </summary>
    public static readonly string CoreConfig = Path.Combine(Root, "LilithsSoul.cfg");

    // ── Shared data ─────────────────────────────────────────

    /// <summary>
    /// BepInEx/config/LilithsSoul/Icons/
    /// Custom PNG icon files placed by the client operator, plus
    /// any icons downloaded from URLs advertised by the server.
    /// Scanned recursively by IconPatcher — admins can organize
    /// into subdirectories freely (e.g. Icons/Weapons/, Icons/Currencies/).
    /// Matched by filename without extension (e.g. "vitae" matches "vitae.png"
    /// anywhere under this directory). First alphabetical match wins on collision.
    /// </summary>
    public static readonly string IconsDir = Path.Combine(Root, "Icons");

    // ── Per-server data ─────────────────────────────────────

    /// <summary>
    /// Returns the directory for a specific server's cached data.
    /// e.g. SoulPathIndex.ServerDir("LilithsGarden")
    ///      → BepInEx/config/LilithsSoul/LilithsGarden/
    ///
    /// ServerIdentity comes from ServerSyncPayload.ServerIdentity
    /// which is already sanitized by Heart before sending.
    /// </summary>
    public static string ServerDir(string serverIdentity)
        => Path.Combine(Root, serverIdentity);

    /// <summary>
    /// Returns the path to the cached sync payload for a specific server.
    /// e.g. SoulPathIndex.SyncFile("LilithsGarden")
    ///      → BepInEx/config/LilithsSoul/LilithsGarden/sync.json
    /// </summary>
    public static string SyncFile(string serverIdentity)
        => Path.Combine(ServerDir(serverIdentity), "sync.json");
}