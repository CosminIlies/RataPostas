using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NpcInteractable : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer image;
    private List<Item> items = new List<Item>();

    private void OnMouseUp()
    {
        if ( items.Count > 0)
        {
            RaycastHit2D hit;
            if (!DialogueManager.Instance.IsInDialoge())
            {
                Interact();
            }
        }
    }


    public void Activate(Item item)
    {
        items.Add(item);
        updateGfx();
    }

    public void Deactivate(Item item)
    {
        items.Remove(item);
        updateGfx();
    }

    public void Interact()
    {
        Item item = items[items.Count - 1];
        DialogueManager.Instance.StartDialogue(item.dialogue, NPCsManager.Instance.GetNpc(item.destinationNpc));
        Deactivate(item);
        InventorySystem.Instance.RemoveItem(item);
    }


    private void updateGfx()
    {
        if (items.Count > 0)
            image.color = new Color(1, 1, 1, 1);
        else
            image.color = new Color(0, 0, 0, 0);
    }

}
