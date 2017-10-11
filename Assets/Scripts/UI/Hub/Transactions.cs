using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transactions  {

    private ShopManager shopManager;
    private Item itemInQuestion;
    private bool buying;


    private Transactions() { }
    public Transactions(ShopManager shopManager)
    {
        this.shopManager = shopManager;
    }


}
