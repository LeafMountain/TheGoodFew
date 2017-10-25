using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    public enum Status { open, blocked, occupied }

    //Returns status of tile depending on the return of GetOccupant
    public Status CurrentStatus {
        get {
            GridOccupant occupant = GetOccupant();
            Status status = Status.open;

            if(occupant){
                status = (occupant.GetComponent<Health>()) ? Status.occupied : Status.blocked;
            }

            return status;
        }
    }
    public Vector2 BoardPosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public int MoveCost { get{ return moveCost; } }
    public int moveCost;

    private Tile[] neighbors = new Tile[4];
    public Tile[] Neighbors { get { return neighbors; } }

    //Initialize board position, world position and status
    public Tile (Vector2 boardPosition, Vector3 worldPosition, Status Status = Status.open) {
        this.BoardPosition = boardPosition;
        this.WorldPosition = new Vector3 (worldPosition.x, 0, worldPosition.z);
    }

    //Check if a collider with the gridOccupant component exists on this tile
    public GridOccupant GetOccupant () {
        Ray ray = new Ray (WorldPosition - Vector3.up, Vector3.up);
        RaycastHit hit;
        Physics.Raycast (ray, out hit, 2);

        if (hit.transform != null) {
            GridOccupant gridObject = hit.transform.GetComponent<GridOccupant> ();

            if (gridObject) {
                return gridObject;
            }
        }

        return null;
    }

    public void SetNeightbors(Tile[] neighbors){
        this.neighbors = neighbors;
    }
}