using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : CombatElement {

    private void Start(){
        SetSize();
    }

    private void SetSize(){
        Renderer renderer = GetComponent<Renderer>();
        int width = (int)renderer.bounds.size.x;
        int height = (int)renderer.bounds.size.z;
        App.Controller.Board.Setup.SetupBoard(width, height);
    }
	
}
