using UnityEngine;

public class DisableGameObjectOnStart : MonoBehaviour {

	void Start () {
        if (gameObject.activeSelf) gameObject.SetActive(false);		
	}
	
}
