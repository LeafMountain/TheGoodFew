using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationButtons : MonoBehaviour {

	public void Answer()
    {
        GetComponentInParent<ShopManager>().Answer(gameObject.name);
    }
    public void AcceptNoTrade()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }
}
