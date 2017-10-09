using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHelper {

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

	public Vector2[,] PathfindArea(Vector2 origin, Vector2[,] area, int steps){

		Spot[,] path = new Spot[(steps + 1) * 2, (steps + 1) * 2];

		for (int x = -steps; x < steps; x++){
			for (int y = -steps; y < steps; y++){
				// path[x + steps, y + steps] = new PathfindStep(area)
			}
		}

		return area;
	}

	public Spot[,] ConvertVector2ToSteps(Vector2[,] area){
		Spot[,] steps = new Spot[area.GetUpperBound(0), area.GetUpperBound(1)];

		for (int i = 0; i < area.GetUpperBound(0); i++)
		{
			for (int j = 0; j < area.GetUpperBound(1); j++)
			{
				steps[i, j] = new Spot(area[i,j]);
			}
		}

		return steps;
	}

	private void GetNeighbours(){

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
