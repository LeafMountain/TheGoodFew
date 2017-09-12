using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{

    Board board;
    Event e;

    private GameObject basePlane;

    private void OnEnable()
    {
        board = (Board)target;
        // SceneView.onSceneGUIDelegate = BoardUpdate;
    }

    private void OnDisable()
    {

    }

    public override void OnInspectorGUI()
    {
    }

    public void BoardUpdate(SceneView sceneView)
    {
        e = Event.current;

        MouseWorldPosition();

        if (e.isKey && e.character == 'a')
        {
            GameObject obj;
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);

            if (prefab)
            {
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                obj.transform.position = FloorVector3(MouseWorldPosition());
                obj.transform.SetParent(board.gameObject.transform);

                Undo.IncrementCurrentGroup();
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            }
        }
    }

    private Vector3 MouseWorldPosition()
    {
        Ray r = HandleUtility.GUIPointToWorldRay(e.mousePosition);

        RaycastHit hit;

        Physics.Raycast(r, out hit, Mathf.Infinity);

        return Camera.current.ScreenToWorldPoint(e.mousePosition);
    }

    private Vector3 FloorVector3(Vector3 pos)
    {
        return new Vector3(Mathf.Floor(pos.x), 0, Mathf.Floor(pos.z));
    }

    private void AddNewCell()
    {

    }
}

