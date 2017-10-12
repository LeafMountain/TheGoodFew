using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseController : MonoBehaviour {

    private BattleManager battleManager;

    public Grid marker;
    private Vector2 boardPosition;

    // public Tile CurrentTile { get { return battleManager.board.GetTile (BoardPosition ()); } }

    private void Start () {
        battleManager = BattleManager.GetInstance();

        //Create grid for mouse marker
        List<GridCell> gridCell = new List<GridCell> ();
        gridCell.Add (new GridCell (Vector2.zero, Grid.CellType.neutral));
        // marker = new Grid (1, Color.blue, gridCell);
    }

    //Check if mouse is hovering over a new tiles and move marker
    // private void CheckIfNewTile () {
    //     // if (battleManager.board.ConvertToBoardPosition (Position ()) != boardPosition) {
    //     //     boardPosition = battleManager.board.ConvertToBoardPosition (Position ());
    //     //     MoveMarker ();
    //     // }
    // }

    //Check if mouse is within the bounds of the board
    private bool WithinBounds () {
        return Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), Mathf.Infinity, 1 << 8);
    }

    //Checks where the mouse is pointing in the world
    public Vector3 Position () {
        Ray mousePointer = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast (mousePointer, out hit, Mathf.Infinity, 1 << 8);

        return hit.point;
    }

    //Check what the mouse is pointing at
    public GameObject Hit () {
        Ray mousePointer = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (mousePointer, out hit, Mathf.Infinity))
            return hit.transform.gameObject;
        else
            return null;
    }

    //Check where the mouse is pointing on the board
    // public Vector2 BoardPosition () {
    //     return battleManager.board.ConvertToBoardPosition (Position ());
    // }

    // //Move the grid marker
    // private void MoveMarker () {
    //     if (WithinBounds ()) {
    //         if (!marker.gameObject.activeInHierarchy)
    //             marker.gameObject.SetActive (true);

    //         if (CurrentTile != null) {
    //             Vector3 newPos = CurrentTile.WorldPosition;

    //             marker.gameObject.transform.position = new Vector3 (newPos.x, 0, newPos.z);

    //             marker.UpdateGrid ();
    //         }
    //     } else
    //         marker.gameObject.SetActive (false);
    // }

    void Update () {
        // CheckIfNewTile ();
    }
}