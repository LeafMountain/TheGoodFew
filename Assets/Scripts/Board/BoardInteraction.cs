using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInteraction {

    private Board board;
    private List<Tile> markedTiles = new List<Tile> ();
    private Grid grid;

    public BoardInteraction (Board board) {
        this.board = board;
    }

    //Creates a grid mesh and places it in the world. Range decides the size and special color decides the color of the special tiles.
    public List<Tile> MarkTiles (Tile rootTile, int range, Color specialColor) {
        DeMarkTiles ();
        
        List<Tile> tiles = GetTilesArea (rootTile, range);
        tiles.Remove (rootTile);

        markedTiles = FindUsableTiles (tiles, Tile.Status.open);

        grid = new Grid (1, specialColor, ConvertToCellType (tiles, rootTile));
        grid.gameObject.transform.position = rootTile.WorldPosition;
        grid.UpdateGrid ();

        return markedTiles;
    }

    //Converts a list of tiles to a GridCell list
    public List<GridCell> ConvertToCellType (List<Tile> tiles, Tile rootTile) {
        List<GridCell> cells = new List<GridCell> ();

        for (int i = 0; i < tiles.Count; i++) {
            if (tiles[i].CurrentStatus == Tile.Status.open) {
                cells.Add (new GridCell (tiles[i].BoardPosition - rootTile.BoardPosition, Grid.CellType.neutral));
            } else if (tiles[i].CurrentStatus == Tile.Status.occupied) {
                cells.Add (new GridCell (tiles[i].BoardPosition - rootTile.BoardPosition, Grid.CellType.special));
            } else if (!board.WithinBounds (tiles[i].BoardPosition)) {
                cells.Add (new GridCell (tiles[i].BoardPosition - rootTile.BoardPosition, Grid.CellType.invisible));
            }
        }

        return cells;
    }

    //Destroys the grid and makes the grid variable empty
    public void DeMarkTiles () {
        if (grid != null) {
            GameObject.Destroy (grid.gameObject);
            grid = null;
        }
    }

    //Sorts out the tiles that is not of the desired type from the inputed list.
    public List<Tile> FindUsableTiles (List<Tile> tiles, Tile.Status type) {
        List<Tile> useableTiles = new List<Tile> ();

        foreach (Tile tile in tiles) {
            if (tile.CurrentStatus == type) {
                useableTiles.Add (tile);
            }
        }

        return useableTiles;
    }

    //Findts the walkable tiles within range from the root tile
    public List<Tile> FindWalkableTiles (Tile rootTile, int range) {
        return FindUsableTiles (GetTilesArea (rootTile, range), Tile.Status.open);
    }

    //Checks if a tile is within the markedTiles list.
    public bool WithinBounds (Tile tile) {
        return markedTiles.Contains (tile);
    }

    //Returns tiles within range
    public List<Tile> GetTilesArea (Tile rootTile, int range) {
        List<Tile> tiles = new List<Tile> ();

        for (int x = -range; x <= range; x++)
            for (int y = -range; y <= range; y++)
                if (Mathf.Abs (x) <= range - Mathf.Abs (y)) {
                    Vector2 pos = new Vector2 (x, y) + rootTile.BoardPosition;

                    if (board.WithinBounds (pos)) {
                        tiles.Add (board.GetTile (pos));
                    }
                }

        return tiles;
    }
}