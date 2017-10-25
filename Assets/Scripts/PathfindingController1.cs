using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingController1 {

	List<TileModel> tiles = new List<TileModel>();
	List<Spot> spots = new List<Spot>();

	public List<TileModel> GetWalkableTiles(TileModel tile, int stepCount){
		tiles.Clear();
		spots.Clear();

		CalculateSteps(tile, stepCount);
		return tiles;
	}

	private void CalculateSteps(TileModel tile, int stepsLeft){
		//Check if there's any steps left and that the tile exists
		if(stepsLeft < 0){
			return;
		}

		//Check if a spot has been created for the tile
		Spot spot = CheckIfExisting(tile);

		//If the spot has been created and the spot has been reached with fewer steps, return.
		if(spot != null){
			if(spot.stepsLeft > stepsLeft){
				return;
			}
		}
		else {
		//If the spot doesn't exist, create it.			
			spot = CreateSpot(tile);
		}

		spot.SetSteps(stepsLeft);

		//If the neighbor tile isnt blocked, to the same to that tile.
		for (int i = 0; i < tile.neighbors.Length; i++) {
			TileModel neighbor = tile.neighbors[i];

			if(neighbor != null && neighbor.Type != TileModel.CellType.blocked){
				CalculateSteps(neighbor, stepsLeft - neighbor.MoveCost);
			}
		}
	}

	private Spot CreateSpot(TileModel tile){
		Spot spot = new Spot(tile.Position);

		tiles.Add(tile);
		spots.Add(spot);

		return spot;
	}

	private Spot CheckIfExisting(TileModel tile){
		if(tile == null) {
			return null;
		}

		for (int i = 0; i < spots.Count; i++)
		{
			if(spots[i].position == tile.Position){
				return spots[i];
			}
		}

		return null;
	}
}

// public class Spot {
// 	public int stepsLeft;
// 	public Vector2 position;
// 	public Spot[] neighbours = new Spot[4];

// 	public Vector2[] adjacent = new Vector2[4];

// 	public Spot(Vector2 position){
// 		this.position = position;
// 	}

// 	public void SetSteps(int steps){
// 		if(steps < stepsLeft){
// 			stepsLeft = steps;
// 		}
// 	}

// 	public void SetNeightbours(Spot[] neighbours){
// 		this.neighbours = neighbours;
// 	}
// }