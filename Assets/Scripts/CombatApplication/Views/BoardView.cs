using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : CombatElement {

    public int GetWidth(){
        return Mathf.FloorToInt(GetComponent<Renderer>().bounds.size.x);
    }

    public int GetHeight(){
        return Mathf.FloorToInt(GetComponent<Renderer>().bounds.size.z);
    }
	
}
