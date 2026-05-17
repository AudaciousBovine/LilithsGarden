using BepInEx.Logging;
using LilithsHeart.Config;

namespace LilithsHeart;

public static class LilithsLogger
{
    private static ManualLogSource _logger = null!;

    internal static void Initialize(ManualLogSource logger)
    {
        _logger = logger;
    }

    public static void Info(string source, string message) 
        => _logger.LogInfo($"[{source}] {message}");

    public static void Warning(string source, string message) 
        => _logger.LogWarning($"[{source}] {message}");

    public static void Error(string source, string message) 
        => _logger.LogError($"[{source}] {message}");

    public static void Debug(string source, string message)
    {
        // [PERFORMANCE] Guard prevents string allocation and write operations
        //               when debug logging is disabled. Zero cost on live servers.
        if (HeartConfig.IsDebug)
            _logger.LogDebug($"[{source}] {message}");
    }
}