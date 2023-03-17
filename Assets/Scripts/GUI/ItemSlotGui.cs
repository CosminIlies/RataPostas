using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlotGui : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image slotItem;
    [SerializeField]
    private TMP_Text nameText;
    private Item item;


    public void SetItem(Item item)
    {
        this.item = item;
        nameText.text = item.name;
        slotItem.sprite = item.image;
    }

    public void DeleteItem()
    {
        InventorySystem.Instance.RemoveItem(item);
        InventoryToolTipGui.Instance.ClearItem();
        Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryToolTipGui.Instance.SetItem(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryToolTipGui.Instance.ClearItem();
    }
}
