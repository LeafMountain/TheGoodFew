using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEquipmentUI {
    public UpdateEquipmentUI(EquipmentManager eqpmntMngr)
    {
        if (eqpmntMngr.CurrentEquipment != null)
        {
            for (int i = 0; i < eqpmntMngr.EquipmentSlots.Length; i++)
            {
                if (eqpmntMngr.CurrentEquipment.
                    EquipmentPieces[i] != null)
                {
                    eqpmntMngr.EquipmentSlots[i].GetComponent<InventorySlot>().
                        AddItem(eqpmntMngr.CurrentEquipment.EquipmentPieces[i]);
                }
            }
        }
    }
}
