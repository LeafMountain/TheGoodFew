using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksButton : MonoBehaviour {

    private BarracksManager barracksManager;

    void Start()
    {
        barracksManager = transform.GetComponentInParent<BarracksManager>();
    }

    public void CharacterButtonCLicked()
    {
        barracksManager.SetCharacterEquipment(transform.GetSiblingIndex());
        barracksManager.OpenCharacter(transform.GetSiblingIndex());
        
    }
}
