using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class UITurnOrderPortrait:MonoBehaviour {

	private Image portrait; 

	private void Awake() {
		portrait = GetComponentInChildren < Image > ();
	}

	public void SetPortrait(Sprite sprite) {
		portrait.sprite = sprite;
	}
}
