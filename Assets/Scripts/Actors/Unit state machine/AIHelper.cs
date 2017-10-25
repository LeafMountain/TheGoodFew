using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHelper {

    //Find closest target to unit
    public TurnOrderObject FindClosestTarget (TurnOrderObject turnOrderObject, List<TurnOrderObject> targets) {

        TurnOrderObject target;
        List<TurnOrderObject> objs = new List<TurnOrderObject>();

        for (int i = 0; i < targets.Count; i++) {
            if (targets[i].allegiance != turnOrderObject.allegiance) {
                objs.Add(targets[i]);
            }
        }

        target = objs[0];

        for (int i = 0; i < objs.Count; i++)
        {
            if(Vector3.Distance(turnOrderObject.transform.position, objs[i].transform.position) < Vector3.Distance(turnOrderObject.transform.position, target.transform.position)){
                target = objs[i];
            }
        }

        return target;
    }

    //Find closest tile to target unit
    public Tile FindTileClosestToTarget (TurnOrderObject target, List<Tile> tiles) {
        Tile tile = new Tile(Vector2.one * Mathf.Infinity, Vector3.one * Mathf.Infinity);

        for (int i = 1; i < tiles.Count; i++) {
            if (Vector3.Distance(target.transform.position, tiles[i].WorldPosition) < Vector3.Distance(target.transform.position, tile.WorldPosition)) {
                tile = tiles[i];
            }
        }

        return tile;
    }

}
