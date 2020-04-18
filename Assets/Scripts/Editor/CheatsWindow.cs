using UnityEditor;
using UnityEngine;

public class CheatsWindow : EditorWindow
{
    [MenuItem("DevTools/Cheats")]
    public static void ShowWindow()
    {
        GetWindow<CheatsWindow>(false, "Cheats", true);
    }

    private void OnGUI()
    {
        Cheats.FlyModeEnabled = EditorGUILayout.Toggle("Enable Fly Mode", Cheats.FlyModeEnabled);
        Cheats.PuzzleDoorUnlocked = EditorGUILayout.Toggle("Unlock Puzzle Door", Cheats.PuzzleDoorUnlocked);

        Cheats.StartInIntroPhase = EditorGUILayout.Toggle("Start at Intro Phase", Cheats.StartInIntroPhase);
        Cheats.StartInHammerPhase = EditorGUILayout.Toggle("Start at Hammer Phase", Cheats.StartInHammerPhase);
        Cheats.StartInKeyPhase = EditorGUILayout.Toggle("Start at Key Phase", Cheats.StartInKeyPhase);
        Cheats.StartInCrowbarPhase = EditorGUILayout.Toggle("Start at Crowbar Phase", Cheats.StartInCrowbarPhase);

        Cheats.DevLightingEnabled = EditorGUILayout.Toggle("Enable Dev Lighting", Cheats.DevLightingEnabled);
    }
}
