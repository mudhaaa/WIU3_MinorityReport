using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] private Item item;

    public Item ITEM
    {
        get { return item; }
        set { item = value; }
    }

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        //Debug.Log(transform.parent);
        transform.SetParent(transform.root.GetChild(0));
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool TextActive = count > 1;
        countText.gameObject.SetActive(TextActive);

        if (count < 1)
        {
            Destroy(gameObject);
        }
    }
    public void InitialiseItem(Item newitem/*, bool QuestCompletion*/)
    {
        item = newitem.Clone();
        image.sprite = newitem.image;

        if (item.ItemInteractScript != null)
        {
            item.ItemInteractScript.Init(item);
        }
        //float QuestBonus = 0;

        //if (QuestCompletion)
        //{
        //    QuestBonus = 8;
        //}
        //if (item.type == ItemType.Armour)
        //{
        //    item.Defence = (int)Random.Range(2 + QuestBonus, 15);
        //    Debug.Log("New Defence:" + item.Defence);
        //}
        //else if (item.type == ItemType.Weapon)
        //{
        //    item.AttackDmg = (int)Random.Range(6 + QuestBonus, 15);
        //}
        RefreshCount();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialiseItem(item);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
