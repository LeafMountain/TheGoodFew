using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "new Equipment", menuName = "Item")]
public class Equipment : ScriptableObject {

    [SerializeField]
    public Item body;
    public Item leftHand;
    public Item rightHand;
    public Item firstTrinket;
    public Item secondTrinket;

    private Item[] allPieces;

    void Start()
    {
        allPieces = new Item[5];
        allPieces[0] = body;
        allPieces[1] = leftHand;
        allPieces[2] = rightHand;
        allPieces[3] = firstTrinket;
        allPieces[4] = secondTrinket;
    }


    //properties
    public Item[] AllPieces { get { return allPieces; } set { allPieces = value; } }

}
