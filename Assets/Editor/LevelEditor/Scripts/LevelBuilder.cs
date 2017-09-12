using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoadAttribute]
public class LevelBuilder : Editor {

    private static bool mouseWithinEditorWindow = false;
    private static Vector3 currentHandlePosition;
    private static Vector3 oldHandlePosition;
    private static float currentRotation;

    static LevelBuilder () {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    private void OnDestroy () {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static private void OnSceneGUI (SceneView sceneView) {
        mouseWithinEditorWindow = MouseWithinSceneView (sceneView.position);

        UseTool ();

        UpdateRepaint ();
    }

    static private void UseTool () {
        LevelEditorWindow.LevelTools currentTool = (LevelEditorWindow.LevelTools) EditorPrefs.GetInt (LevelEditorWindow.selectedtoolPrefs, 0);

        if (mouseWithinEditorWindow && EditorPrefs.GetBool (LevelEditorWindow.paintToolActivatedPrefs)) {
            if (Event.current.control) {
                RemoveTool ();
            } else {
                AddTool ();
            }
        }

    }

    static private void AddTool () {
        string assetPath = EditorPrefs.GetString (LevelEditorWindow.selectedPrefabPrefsLocation);
        Object prefab = AssetDatabase.LoadAssetAtPath (assetPath, typeof (Object));

        if (Event.current.type == EventType.mouseDown && Event.current.button == 2) {
            currentRotation += (currentRotation < 360) ? 90 : -360;
        }

        if (Event.current.type == EventType.mouseDown && Event.current.button == 0) {
            InstantiatePrefab (currentHandlePosition, currentRotation, prefab);
        }
        DrawHandle (MouseWorldPosition (), Color.white, (prefab as GameObject).GetComponent<MeshFilter> ().sharedMesh);
    }

    static private void RemoveTool () {
        DrawHandle (MouseWorldPosition (), Color.red);

    }

    static private bool MouseWithinSceneView (Rect screen) {
        return screen.Contains (Event.current.mousePosition);
    }

    static private void DrawHandle (Vector3 center, Color handleColor, Mesh mesh = null) {
        Handles.color = handleColor;
        Vector3 newPos = new Vector3 (Mathf.Round (center.x), 0, Mathf.Round (center.z));

        if (mouseWithinEditorWindow) {
            if (currentHandlePosition != oldHandlePosition) {
                oldHandlePosition = currentHandlePosition;
            }

            Vector3 cubeSize = Vector3.zero;
            Vector3 cubePosition = currentHandlePosition;

            if (mesh) {

                if (currentRotation == 90 || currentRotation == 270) {
                    cubeSize = new Vector3 (mesh.bounds.size.z, mesh.bounds.size.y, mesh.bounds.size.x);
                } else {
                    cubeSize = mesh.bounds.size;
                }

                cubePosition.y += mesh.bounds.center.y;
            } else {
                cubeSize = new Vector3 (1, 0.01f, 1);
            }

            Handles.DrawWireCube (cubePosition, cubeSize);
            currentHandlePosition = newPos;

            if (Event.current.shift) {
                currentHandlePosition.y += CheckHeight (currentHandlePosition);
            }

        }
    }

    private static float CheckHeight (Vector3 origin) {
        float maximumHeight = 20;
        Ray ray = new Ray (origin + Vector3.up * maximumHeight, Vector3.down);
        RaycastHit hit;
        Physics.Raycast (ray, out hit, Mathf.Infinity);

        return hit.point.y;
    }

    private static Vector3 MouseWorldPosition () {
        Ray mouseRay = HandleUtility.GUIPointToWorldRay (Event.current.mousePosition);
        RaycastHit hit;
        Physics.Raycast (mouseRay, out hit, Mathf.Infinity, 1 << 8);
        return hit.point;
    }

    private static void UpdateRepaint () {
        SceneView.RepaintAll ();
    }

    private static void InstantiatePrefab (Vector3 position, float rotation, Object prefab) {
        GameObject instantiatedPrefab = PrefabUtility.InstantiatePrefab (prefab) as GameObject;
        instantiatedPrefab.transform.position = position;
        instantiatedPrefab.transform.rotation = Quaternion.Euler (0, rotation, 0);
        Undo.IncrementCurrentGroup ();
        Undo.RegisterCreatedObjectUndo (instantiatedPrefab, "Instantiated " + instantiatedPrefab.name);
    }
}