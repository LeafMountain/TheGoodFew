using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoadAttribute]
public class LevelEditorWindow : EditorWindow {

    static Vector2 scrollPosition = Vector2.zero;
    static int selectedProp;
    static int selectedCategory;

    //Tools
    static int selectedTool;
    public enum LevelTools { None, Add, Remove };

    static SetupLevel setup = new SetupLevel ();
    public static string selectedPrefabPrefsLocation = "levelEditorSelectedPrefab";
    public static string selectedtoolPrefs = "LevelEditorSelectedTool";
    public static string paintToolActivatedPrefs = "LevelEditorPaintToolActivated";
    private static bool paintToolActivated;

    [MenuItem ("Window/Level Editor")]
    static void Init () {
        // Get existing open window or if none, make a new one:
        LevelEditorWindow levelEditor = (LevelEditorWindow) EditorWindow.GetWindow (typeof (LevelEditorWindow));
        levelEditor.Show ();
    }

    void OnGUI () {
        if (!setup.CheckIfSetup ()) {
            if (GUILayout.Button ("Setup hierarchy")) {
                setup.SetupHierarchy ();
            }
        } else {
            ToolSelector ();
            PropSelector ();
        }
    }

    private void PropSelector () {
        GUILayout.Space (10);
        LevelEditorAssetPackageLibrary assetLibrary = AssetDatabase.LoadAssetAtPath ("Assets/Editor/LevelEditor/LevelLibrary.asset", typeof (LevelEditorAssetPackageLibrary)) as LevelEditorAssetPackageLibrary;
        LevelEditorAssetPackage[] packages = assetLibrary.packages;

        PrintCategorys (packages);
        PrintPropList (packages[selectedCategory]);
    }

    private void PrintCategorys (LevelEditorAssetPackage[] packages) {
        GUILayout.Label ("Level parts");

        //Get category names
        string[] categoryNames = new string[packages.Length];

        for (int i = 0; i < packages.Length; i++) {
            categoryNames[i] = packages[i].name;
        }

        //Draw category list
        selectedCategory = GUILayout.Toolbar (selectedCategory, categoryNames);
    }

    private void PrintPropList (LevelEditorAssetPackage assetPackage) {
        //Draw prop list
        GUILayout.BeginVertical ("box");

        //Update selected prop index
        int xCount = Mathf.FloorToInt (position.width / 100);
        selectedProp = GUILayout.SelectionGrid (selectedProp, assetPackage.GetAssetPreviews(), xCount);

        //Get asset path
        string assetPath = AssetDatabase.GetAssetPath (assetPackage.assets[selectedProp]);
        EditorPrefs.SetString (selectedPrefabPrefsLocation, assetPath);
        GUILayout.EndVertical ();
    }

    private void ToolSelector () {
        GUILayout.Label ("Tools");
        // string[] tools = Enum.GetNames (typeof (LevelTools));
        paintToolActivated = GUILayout.Toggle(paintToolActivated, ((paintToolActivated) ? "Deactivate" : "Activate") + " Paint Tool", GUI.skin.button);
        EditorPrefs.SetBool(paintToolActivatedPrefs, paintToolActivated);

        // selectedTool = GUILayout.Toolbar (selectedTool, tools);
        // EditorPrefs.SetInt ("LevelEditorSelectedTool", selectedTool);
    }
}