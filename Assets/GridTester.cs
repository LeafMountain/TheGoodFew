using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour {

	AreaHelper areaHelper;
	Vector2 position;
	int steps = 3;

	private void Awake(){
		areaHelper = new AreaHelper();
		position = new Vector2(transform.position.x, transform.position.z);

		Grid grid = new Grid(1, Color.red, PathfindCells(CreateGridCells()));
		grid.UpdateGrid();
	}

	private Vector2[,] CreateGridCells(){
		return areaHelper.GetArea(position, steps);
	}

	private List<GridCell> PathfindCells(Vector2[,] cells){
		// List<GridCell> walkableCells = new List<GridCell>();

		// ConvertVector2ToGridCells(areaHelper.PathfindArea(position, cells, steps));

		return ConvertVector2ToGridCells(areaHelper.PathfindArea(position, cells, steps));
	}
	
	private List<GridCell> ConvertVector2ToGridCells(Vector2[,] cellPositions){
		List<GridCell> cells = new List<GridCell>();

		for (int x = 0; x < cellPositions.GetUpperBound(0); x++)
		{
			for (int y = 0; y < cellPositions.GetUpperBound(1); y++)
			{
				cells.Add(new GridCell(cellPositions[x, y], Grid.CellType.neutral));
			}
		}

		return cells;
	}
}
