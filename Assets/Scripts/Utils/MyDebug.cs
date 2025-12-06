using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyDebug
{
    private static bool showDebug=true;
    public static void Log(string message)
    {
        if (!showDebug) return;
        Debug.Log(message);
    }
    public static void LogError(string message)
    {
        if (!showDebug) return;
        Debug.LogError(message);
    }
    public static void LogWarning(string message)
    {
        if (!showDebug) return;
        Debug.LogWarning(message);
    }
}
