using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour {

	AreaHelper areaHelper;
	Vector2 position;
	int steps = 6;

	private List<Spot> walkableSpots = new List<Spot>();
	private Vector2[,] spotPositions;
	private Spot[,] spots;

	private void Awake(){
		areaHelper = new AreaHelper();

		TestCalc();
	}

	//Get a 2D area with the area of steps*steps
	private Vector2[,] CreateGridCells(){
		return areaHelper.GetArea(new Vector2(transform.position.x, transform.position.z), steps * 2 + 1);
	}


	private Spot[,] CreateSpots(Vector2[,] area){
		Spot[,] spots = new Spot[area.GetUpperBound(0), area.GetUpperBound(1)];

		for (int x = 0; x < spots.GetUpperBound(0); x++)
		{
			for (int y = 0; y < spots.GetUpperBound(1); y++)
			{
				spots[x, y] = new Spot(area[x, y]);
			}
		}
		return spots;
	}

	private void SetNeighbours(Spot [,] spots){
		for (int x = 0; x < spots.GetUpperBound(0); x++)
		{
			for (int y = 0; y < spots.GetUpperBound(1); y++)
			{
				Spot[] neighbours = new Spot[4];

				if(y - 1 >= 0){
					neighbours[0] = spots[x, y - 1];
				}
				if(x + 1 <= spots.GetUpperBound(0)){
					neighbours[1] = spots[x + 1, y];
				}
				if(y + 1 <= spots.GetUpperBound(1)){
					neighbours[2] = spots[x, y + 1];
				}
				if(x - 1 >= 0){
					neighbours[3] = spots[x -1, y];
				}

				spots[x, y].SetNeightbours(neighbours);
			}
		}
	}

	private void CalculateSteps(Spot currentSpot, int stepsLeft){
		if(stepsLeft >= 0){
			walkableSpots.Add(currentSpot);
			
			for (int i = 0; i < currentSpot.neighbours.Length; i++)
			{
				CalculateSteps(currentSpot.neighbours[i], stepsLeft - 1);
			}
		}
	}

	private List<GridCell> ConvertSpotToGridCell(List<Spot> spots){
		List<GridCell> cells = new List<GridCell>();

		for (int i = 0; i < spots.Count; i++)
		{
			cells.Add(new GridCell(spots[i].position, Grid.CellType.neutral));
		}

		return cells;
	}

	private void TestCalc(){
		spotPositions = CreateGridCells();
		spots = CreateSpots(spotPositions);
		SetNeighbours(spots);
		CalculateSteps(spots[Mathf.CeilToInt(spotPositions.GetUpperBound(0) / 2), Mathf.CeilToInt(spotPositions.GetUpperBound(1) / 2)], steps);

		Grid grid = new Grid(1, Color.red, ConvertSpotToGridCell(walkableSpots));
		grid.UpdateGrid();
		
	}
}
