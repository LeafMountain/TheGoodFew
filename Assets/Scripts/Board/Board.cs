using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public BoardInteraction interaction { get; private set; }

    private const float tileSize = 1;
    private Vector3 BottomLeftCorner {
        get {
            return Rend.bounds.min;
        }
    }

    private Renderer rend;
    private Renderer Rend {
        get {
            if (!rend) {
                rend = GetComponent<Renderer> ();
            }
            return rend;
        }
    }

    //New stuffs
    private List<Vector2> boardPositions = new List<Vector2> ();
    private List<Tile> tiles = new List<Tile> ();

    public void Awake () {
        interaction = new BoardInteraction (this);

        //Find valid positions
        boardPositions = FindBoardPositions ();
        //Create tiles on valid positions
        tiles = CreateTiles (boardPositions);        
    }

    //Creates new tiles depending on the mesh size of the ground GameObject.
    private List<Tile> CreateTiles (List<Vector2> positions) {
        List<Tile> tiles = new List<Tile> ();

        for (int i = 0; i < positions.Count; i++) {
            Tile newTile = new Tile (positions[i], ConvertToWorldPosition (positions[i]));
            tiles.Add (newTile);
        }

        return tiles;
    }

    private List<Vector2> FindBoardPositions () {
        List<Vector2> positions = new List<Vector2> ();
        Vector3 worldPos;

        for (int x = 0; x < Mathf.FloorToInt (Rend.bounds.size.x); x++)
            for (int y = 0; y < Mathf.FloorToInt (Rend.bounds.size.z); y++) {
                worldPos = ConvertToWorldPosition (new Vector2 (x, y));

                if (worldPos.y != -Mathf.Infinity) {
                    positions.Add (new Vector2 (x, y));
                }
            }

        return positions;
    }

    //Retruns tile at position. If position is outside of bounds, returns null.
    public Tile GetTile (Vector2 position) { //Den gör något fel!!
        if (boardPositions.Contains (position)) {
            return tiles[boardPositions.IndexOf (position)];
        } else {
            return null;
        }
    }

    //Converts Vector3 world position to board positions.
    public Vector2 ConvertToBoardPosition (Vector3 pos) {
        return new Vector2 (Mathf.Floor (pos.x - BottomLeftCorner.x), Mathf.Floor (pos.z - BottomLeftCorner.z));
    }

    //Converts board position to Vector3 world position.
    public Vector3 ConvertToWorldPosition (Vector2 pos) {
        Vector3 worldPos = new Vector3 ((pos.x * tileSize) + BottomLeftCorner.x + tileSize / 2, 0, (pos.y * tileSize) + BottomLeftCorner.z + tileSize / 2);

        Ray heightChecker = new Ray (worldPos + Vector3.up * 10, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast (heightChecker, out hit, Mathf.Infinity, 1 << 8)) {
            worldPos.y = hit.point.y;
        } else {
            worldPos.y = -Mathf.Infinity;
        }

        return worldPos;
    }

    //Checks if boardPos is within bounds of the tiles array
    public bool WithinBounds (Vector2 boardPos) {
        return boardPositions.Contains (boardPos);
    }

#region EditorMethods
    //Marks obstacles and grid in the editor view
    private void OnDrawGizmos () {
        List<Vector2> boardPositions = FindBoardPositions ();

        //Find Obstacles
        List<GridOccupant> obstacles = new List<GridOccupant> ();
        obstacles.AddRange (FindObjectsOfType (typeof (GridOccupant)) as GridOccupant[]);
        List<Vector2> obstaclePositions = new List<Vector2> ();

        for (int i = 0; i < obstacles.Count; i++) {
            List<Vector3> obstaclePos = obstacles[i].Positions ();

            for (int y = 0; y < obstaclePos.Count; y++) {
                obstaclePositions.Add (ConvertToBoardPosition (obstaclePos[y]));
            }
        }

        //Draw Gizmos
        for (int i = 0; i < boardPositions.Count; i++) {
            Vector3 worldPos = ConvertToWorldPosition (boardPositions[i]);
            if (obstaclePositions.Contains (boardPositions[i])) {
                Gizmos.color = new Color (1, 0, 0, 0.5f);
                Gizmos.DrawCube (worldPos, new Vector3 (tileSize, 0.01f, tileSize));
            } 
            else {
                Gizmos.color = new Color (1, 1, 1, 0.3f);
                Gizmos.DrawWireCube (worldPos, new Vector3 (tileSize, 0.01f, tileSize) * 0.8f);
            }
        }

    }
    #endregion

    
}