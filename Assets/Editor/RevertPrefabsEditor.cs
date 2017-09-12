using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//From http://answers.unity3d.com/questions/144453/reverting-several-gameobjects-to-prefab-settings-a.html
//For resetting more than one prefab at a time

public class RevertPrefabsEditor : Editor {

    [MenuItem ("Tools/Revert to Prefab %r")]
    static void Revert () {
        GameObject[] selection = Selection.gameObjects;

        if (selection.Length > 0) {
            for (int i = 0; i < selection.Length; i++) {
                PrefabUtility.ResetToPrefabState (selection[i]);
            }
        } else {
            Debug.Log ("Cannot revert to prefab - nothing selected");
        }
    }
}