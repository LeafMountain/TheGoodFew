using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEquipmentData
{

    private bool devMode;
    private PlayerData playerData;

    private LoadEquipmentData() { }
    public LoadEquipmentData(bool devMode, PlayerData playerData)
    {
        this.devMode = devMode;
        this.playerData = playerData;
    }
    private void LoadDeveloperEquipment()
    {
        new LoadEquipmentDevMode(playerData);
    }
    private void LoadSaveFileEquipment()
    {
        //Put a class that loads the equipment from a savefile here! 
    }
}
	
