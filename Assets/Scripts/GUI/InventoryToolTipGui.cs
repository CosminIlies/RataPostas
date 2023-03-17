using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryToolTipGui : MonoBehaviour
{
    #region Singleton
    public static InventoryToolTipGui Instance;
    #endregion

    [SerializeField]
    private GameObject toolTip;


    [SerializeField]
    private Image displayImage;
    [SerializeField]
    private new TMP_Text name;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private TMP_Text weight;

    private Item item;
    private void Awake()
    {
        Instance = this;
        ClearItem();    
    }

    private void Update()
    {
        if (toolTip.activeSelf)
        {
            toolTip.transform.position = new Vector2(Input.mousePosition.x-150f, Input.mousePosition.y-150f);
        }
    }

    public void SetItem(Item item)
    {
        this.item = item;
        displayImage.sprite = item.image;   
        name.text = item.name;
        description.text = item.description;
        weight.text = item.weight.ToString();
        toolTip.SetActive(true);
    }

    public void ClearItem()
    {
        this.item = null;
        displayImage.sprite = null;
        name.text = "";
        description.text = "";
        weight.text = "";
        toolTip.SetActive(false);
    }


}
