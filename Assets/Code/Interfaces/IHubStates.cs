//Author: Axel Stenkrona
//Description: The archtype for every menu/ state in the questhub. A scriptable object, <HubMenuData>, contains the information.
using UnityEngine;

public interface IHubStates  {

   

	GameObject Menu { get; set; }

   
    Sprite[] CharacterPortraits { get; set; }
    

   
    Sprite[] MenuVisuals { get; set; }

 
    AudioClip BackGroundTrack { get; set; }

    
    string[] DialogueTexts { get; set; }

    void MoveCamera();
    
}
