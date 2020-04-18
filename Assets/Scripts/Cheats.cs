#if UNITY_EDITOR
using UnityEditor;
#endif

public class Cheats
{
    public static bool FlyModeEnabled
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Enable Fly Mode", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Enable Fly Mode", value);
#endif
        }
    }
    public static bool PuzzleDoorUnlocked
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Unlock Puzzle Door", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Unlock Puzzle Door", value);
#endif
        }
    }
    public static bool StartInIntroPhase
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Start at Intro Phase", true);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Start at Intro Phase", value);
#endif
        }
    }
    public static bool StartInHammerPhase
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Start at Hammer Phase", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Start at Hammer Phase", value);
#endif
        }
    }
    public static bool StartInKeyPhase
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Start at Key Phase", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Start at Key Phase", value);
#endif
        }
    }
    public static bool StartInCrowbarPhase
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Start at Crowbar Phase", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Start at Crowbar Phase", value);
#endif
        }
    }
    public static bool DevLightingEnabled
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("Enable Dev Lighting", false);
#else
            return false;
#endif
        }
        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("Enable Dev Lighting", value);
#endif
        }
    }

}
