using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : CombatElement {
    public BoardSetupController Setup { get; private set; }

    private void Awake(){
        Setup = GetComponentInChildren<BoardSetupController>();
    }

    public TileModel GetCell(Vector2 cell){
        return App.Model.Board.Tiles[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)];
    }

	public void ChangeCellType(Vector2 cell, TileModel.CellType newType){
        if(cell.x >= 0 && cell.x < App.Model.Board.Width && cell.y >= 0 && cell.y < App.Model.Board.Height){
		    App.Model.Board.Tiles[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)].ChangeType(newType);
        }
	}

    public TileModel[,] GetCurrenLayout(){
        return App.Model.Board.Tiles;
    }

    public void AddOccupant(TileModel tile){
        tile.ChangeType(TileModel.CellType.blocked);
    }

    public void AddUnit(TileModel tile, UnitModel unit){
        tile.SetUnit(unit);
    }

}