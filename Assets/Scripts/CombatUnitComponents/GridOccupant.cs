using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class GridOccupant : CombatElement {

    private BoxCollider collider;
    public BoxCollider Collider {
        get {
            if (!collider) {
                collider = GetComponent<BoxCollider> ();

                // if (!col) { col = GetComponentInChildren<BoxCollider> (); }
                // if (!col) { Debug.LogWarning ("No box collider found on " + gameObject.name + " game object."); }
            }
            return collider;
        }
    }

    //Calculates the size of the collider and rounds the values
    public Vector2 Size {
        get {
            Vector2 size = new Vector2 (Mathf.Round (Collider.size.x), Mathf.Round (Collider.size.z));
            size.x = (size.x < 1) ? 1 : size.x;
            size.y = (size.y < 1) ? 1 : size.y;

            return size;
        }
    }

    //Positions for the board gizmos.
    public List<Vector3> Positions () {
        List<Vector3> positions = new List<Vector3> ();

        for (float x = -Size.x * 0.5f; x < Size.x * 0.5f; x++)
            for (float y = -Size.y * 0.5f; y < Size.y * 0.5f; y++) {
                positions.Add ((Collider.bounds.center + (transform.forward + transform.right) * 0.5f) + (transform.right * x) + (transform.forward * y));
            }
        return positions;
    }

    private void OnEnable () {
        Collider.enabled = true;

    }

    private void OnDisable () {
        Collider.enabled = false;
    }

    private void Start(){
        List<Vector3> positions = Positions();
        for (int i = 0; i < positions.Count; i++)
        {
            App.Controller.Board.AddOccupant(App.Controller.Board.GetCell(new Vector2(positions[i].x, positions[i].z)));
            // App.Controller.Board.ChangeCellType(new Vector2(positions[i].x, positions[i].z), TileModel.CellType.blocked);
        }
    }
}