using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor {

    private Dialogue dia;

    private void OnEnable () {
        dia = (Dialogue)target;
    }

    public override void OnInspectorGUI () {

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Line"))
        {
            AddLine();
        }
        GUILayout.EndHorizontal();

        for (int i = 0; i < dia.lines.Count; i++)
        {
            GUILayout.BeginHorizontal("box");

            dia.lines[i].line = GUILayout.TextArea(dia.lines[i].line, GUILayout.Height(50), GUILayout.Width(250));

            GUILayout.BeginVertical();
            dia.lines[i].name = GUILayout.TextField(dia.lines[i].name);
            // dia.lines[i].fromUnit = EditorGUILayout.ObjectField (dia.lines[i].fromUnit, typeof (Unit), true) as Unit;

            if (GUILayout.Button("Remove"))
            {
                RemoveLine(i);
                return;
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(dia);
            serializedObject.ApplyModifiedProperties();
        }

    }

    private void AddLine () {
        dia.lines.Add(new Line());
    }

    private void RemoveLine (int i) {
        dia.lines.RemoveAt(i);
    }
}