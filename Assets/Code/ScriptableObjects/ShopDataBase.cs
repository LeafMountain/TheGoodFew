//Author: Axel Stenkrona
//Discription: Templete for what a shop should contain.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "New Shop")]
public class ShopDataBase : ScriptableObject  {

    public bool isShop;

    [HeaderAttribute("Name")]
    public string subHubName;
    public string devNotes;

    [HeaderAttribute("Dialouge")]
    public string greeting;
    public string farewell;
    public string[] dialogueTexts;

    [HeaderAttribute("Sprites")]
    public Sprite[] characterPortraits;
    public Sprite backGroundSprite;
    

    //public List<Item> items //<- This is a list of the items that the shop sells;

    [HeaderAttribute("Audio")]
    public AudioClip backGroundAudioTrack;

  


}
