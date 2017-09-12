using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (AIState), true)]
public class AIStateEditor : Editor {

    private AIState state;

    private void OnEnable () {
        state = (AIState) target;
    }

    public override void OnInspectorGUI () {

        if (GUILayout.Button ("+")) {
            AddElement ();
        }

        for (int i = 0; i < state.transitions.Count; i++) {
            GUILayout.BeginVertical ("box");
            GUILayout.BeginHorizontal ();

            state.transitions[i].nextState = (AIState) EditorGUI.ObjectField (new Rect (0, 0, 30, 30), state.transitions[i].nextState, typeof (AIState), false);

            GUILayout.Space(5);
            EditorGUI.ObjectField (new Rect (0, 0, 30, 30), state.transitions[i].nextState, typeof (AIState), false);

            if (GUILayout.Button ("-")) {
                RemoveElement (i);
            }

            GUILayout.EndHorizontal ();

            
            GUILayout.EndVertical ();
        }

        DrawDefaultInspector ();

        if (GUI.changed) {
            EditorUtility.SetDirty (state);
            serializedObject.ApplyModifiedProperties ();
        }
    }

    public void AddElement () {
        state.transitions.Add (new Transition ());
    }

    public void RemoveElement (int index) {
        state.transitions.RemoveAt (index);
    }
}