using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHelper {

	private static AreaHelper instance;

	public static AreaHelper GetInstance(){
		return instance;
	}

	public AreaHelper(){
		instance = this;
	}

    public Vector2[,] GetArea(Vector2 origin, int areaRange){
        Vector2[,] moveArea = new Vector2[(areaRange + 1) * 2, (areaRange + 1) * 2];

        for (int x = -areaRange; x <= areaRange; x++){
            for (int y = -areaRange; y <= areaRange; y++){
                Vector2 newCell = new Vector2(origin.x + x, origin.y + y);
				moveArea[x + areaRange, y + areaRange] = newCell;
            }
        }
        
        return moveArea;
    }

	public List<GridCell> GetLimitedArea(Vector2[,] area, int steps){
		Spot[,] spots = CreateSpots(area);
		SetNeighbours(spots);
		List<Spot> spots2 = CalculateWalkableSteps(spots[spots.GetUpperBound(0), spots.GetUpperBound(1)], steps);
		return ConvertSpotToGridCell(spots2);
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

	private List<Spot> CalculateWalkableSteps(Spot currentSpot, int stepsLeft){
		List<Spot> walkableSpots = new List<Spot>();

		if(stepsLeft >= 0){
			walkableSpots.Add(currentSpot);
			
			for (int i = 0; i < currentSpot.neighbours.Length; i++)
			{
				CalculateWalkableSteps(currentSpot.neighbours[i], stepsLeft - 1);
			}
		}

		return walkableSpots;
	}

	private List<GridCell> ConvertSpotToGridCell(List<Spot> spots){
		List<GridCell> cells = new List<GridCell>();

		for (int i = 0; i < spots.Count; i++)
		{
			cells.Add(new GridCell(spots[i].position, Grid.CellType.neutral));
		}

		return cells;
	}
}

public class Spot {
	public int minimumSteps;
	public Vector2 position;
	public Spot[] neighbours = new Spot[4];

	public Vector2[] adjacent = new Vector2[4];

	public Spot(Vector2 position){
		this.position = position;
	}

	public void SetSteps(int steps){
		if(steps < minimumSteps){
			minimumSteps = steps;
		}
	}

	public void SetNeightbours(Spot[] neighbours){
		this.neighbours = neighbours;
	}
}
