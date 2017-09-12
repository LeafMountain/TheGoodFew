using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AINodeEditor : EditorWindow {

    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // Add menu named "My Window" to the Window menu
    [MenuItem ("Window/AI Node Editor")]
    static void Init () {
        // Get existing open window or if none, make a new one:
        AINodeEditor window = (AINodeEditor) EditorWindow.GetWindow (typeof (AINodeEditor));
        window.Show ();
    }

    void OnGUI () {
        GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField ("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle ("Toggle", myBool);
        myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup ();
    }
}