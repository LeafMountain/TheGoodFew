using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class GridOccupant : MonoBehaviour {

    private BattleManager battleManager;
    public BattleManager BattleManager {
        get {
            if (!battleManager) { battleManager = BattleManager.GetInstance (); }
            if (!battleManager) { Debug.LogWarning ("No battle manager instance found."); }
            return battleManager;
        }
    }

    //Get the current tile this gameobject occupies
    public Tile CurrentTile { get { return BattleManager.board.GetTile (BattleManager.board.ConvertToBoardPosition (transform.position)); } }

    private BoxCollider col;
    public BoxCollider Collider {
        get {
            if (!col) {
                col = GetComponent<BoxCollider> ();

                if (!col) { col = GetComponentInChildren<BoxCollider> (); }
                if (!col) { Debug.LogWarning ("No box collider found on " + gameObject.name + " game object."); }
            }
            return col;
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

    private BoardManager boardManager;

    private void OnEnable () {
        //Enable collider when this component is enabled
        Collider.enabled = true;

    }

    private void OnDisable () {
        //Disable collider when this component is disabled
        Collider.enabled = false;
    }

    private void Start(){
        SetupBoardManager();

        List<Vector3> positions = Positions();
        for (int i = 0; i < positions.Count; i++)
        {
            boardManager.ChangeCellType(new Vector2(positions[i].x, positions[i].z), BoardCell.CellType.blocked);     
        }
    }
    
    private void SetupBoardManager(){
        if(boardManager == null){
            boardManager = BoardManager.GetInstance();
        }
    }
}