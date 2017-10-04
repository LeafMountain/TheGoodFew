using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHelper {

    public Vector2[,] GetArea(Vector2 origin, int areaRange){
        Vector2[,] moveArea = new Vector2[areaRange, areaRange];

        for (int x = -areaRange; x <= areaRange; x++){
            for (int y = -areaRange; y <= areaRange; y++){
                Vector2 newCell = new Vector2(origin.x + x, origin.y + y);
				moveArea[x, y] = newCell;
            }
        }
        
        return moveArea;
    }

	public Vector2[,] PathfindArea(Vector2 origin, Vector2[,] area, int steps){

		PathfindStep[,] path = new PathfindStep[steps, steps];

		for (int x = -steps; x < steps; x++){
			for (int y = -steps; y < steps; y++){
				path[x, y] = new PathfindStep(new Vector2(x, y), new Vector2[]{ 
					new Vector2( x - 1, y),
					new Vector2( x, y - 1),
					new Vector2( x + 1, y),
					new Vector2( x, y + 1)}
					);
			}
		}

		return area;
	}
}

public class PathfindStep {
	public int minimumSteps;
	public Vector2 position;

	public Vector2[] adjacent = new Vector2[4];

	public PathfindStep(Vector2 position, Vector2[] adjacent){
		this.adjacent = adjacent;
		this.position = position;
	}

	public void SetSteps(int steps){
		if(steps < minimumSteps){
			minimumSteps = steps;
		}
	}

}
