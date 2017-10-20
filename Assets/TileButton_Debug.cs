using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton_Debug : MonoBehaviour {

	public TileModel Tile { get; private set; }

	private void Awake(){
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	public void SetTile(TileModel tile){
		Tile = tile;
	}

	private void OnClick(){
		Debug.Log(Tile.Position);
	}
}
