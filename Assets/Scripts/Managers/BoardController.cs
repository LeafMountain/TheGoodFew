using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : CombatElement {
	private static BoardController instance;

    private Grid grid;
    public PathfindingController AreaHelper{ get; private set; }

    //Need a pathfinder to find areas.

    private void Start(){
        SetupBoard(10, 10);
    }

	public void SetupBoard(int width, int height){
		instance = this;

        Debug.Log(App.model);

		App.model.boardModel.mapWidth = width;
        App.model.boardModel.mapHeight = height;

        CreateBoardCells();
        SetNeighbours();

        AreaHelper = PathfindingController.GetInstance();
        
        if(AreaHelper == null){
            AreaHelper = new PathfindingController();
        }
	}

	public static BoardController GetInstance(){
		return instance;
	}

    public BoardCell GetCell(Vector2 cell){
        return App.model.boardModel.boardCells[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)];
    }

	private void CreateBoardCells(){
        App.model.boardModel.boardCells = new BoardCell[App.model.boardModel.mapWidth, App.model.boardModel.mapHeight];
        for (int x = 0; x < App.model.boardModel.mapWidth; x++){
            for (int y = 0; y < App.model.boardModel.mapHeight; y++){

                //Need to check if blocked later.
                App.model.boardModel.boardCells[x, y] = new BoardCell(new Vector2(x, y), BoardCell.CellType.walkable);
            }
        }

        App.model.boardModel.boardCells[5, 5].ChangeType(BoardCell.CellType.blocked);
    }

	private void SetNeighbours(){
		//Find and set the neightbours to the cell.
        for (int x = 0; x < App.model.boardModel.mapWidth; x++)
        {
            for (int y = 0; y < App.model.boardModel.mapHeight; y++)
            {
                BoardCell[] neighbors = new BoardCell[4];

                if(y < App.model.boardModel.mapHeight - 1){
                    neighbors[0] = App.model.boardModel.boardCells[x, y + 1];
                }
                if(x < App.model.boardModel.mapWidth - 1 ){
                    neighbors[1] = App.model.boardModel.boardCells[x + 1, y];
                }
                if(y > 0){
                    neighbors[2] = App.model.boardModel.boardCells[x, y - 1];
                }
                if(x > 0){
                    neighbors[3] = App.model.boardModel.boardCells[x - 1, y];
                }

                App.model.boardModel.boardCells[x, y].SetNeighbors(neighbors);
            }
        }
	}

	public void ChangeCellType(Vector2 cell, BoardCell.CellType newType){
        if(cell.x >= 0 && cell.x < App.model.boardModel.mapWidth && cell.y >= 0 && cell.y < App.model.boardModel.mapHeight){
		    App.model.boardModel.boardCells[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)].ChangeType(newType);
            // CreateGrid();
        }
	}

    public void CreateGrid(){
        if(grid != null){
            GameObject.Destroy(grid.gameObject);
        }
        List<GridCell> cells = new List<GridCell>();
        for (int x = 0; x < App.model.boardModel.mapWidth; x++)
        {
            for (int y = 0; y < App.model.boardModel.mapHeight; y++)
            {
                if(App.model.boardModel.boardCells[x, y].Type == BoardCell.CellType.blocked){
                    cells.Add(new GridCell(App.model.boardModel.boardCells[x, y].Position, Grid.CellType.special));
                }
                else{
                    cells.Add(new GridCell(App.model.boardModel.boardCells[x, y].Position, Grid.CellType.neutral));
                }
            }
        }
        // grid = new Grid(1, Color.red, cells);
        // grid.UpdateGrid();
    }

}