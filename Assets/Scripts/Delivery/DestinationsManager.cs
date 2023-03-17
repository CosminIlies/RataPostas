using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationsManager : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");

        foreach (Item item in InventorySystem.Instance.GetAllItems())
        {
            foreach (NPC npc in NPCsManager.Instance.npcs)
            {
                if (npc.name != item.destinationNpc)
                    continue;
                npc.npcInteractable.Activate(item);
            }
        }
    }

}
