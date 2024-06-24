using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class QuickSlotController : MonoBehaviour
{
    public Button[] slotButtons;
    public Sprite[] itemIcons;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItemToSlot(0, itemIcons[0]);
            Debug.Log("1¹ø ½½·Ô");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItemToSlot(1, itemIcons[1]);
            Debug.Log("2¹ø ½½·Ô");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItemToSlot(2, itemIcons[2]);
            Debug.Log("3¹ø ½½·Ô");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AddItemToSlot(3, itemIcons[3]);
            Debug.Log("4¹ø ½½·Ô");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AddItemToSlot(4, itemIcons[4]);
            Debug.Log("5¹ø ½½·Ô");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddItemToSlot(5, itemIcons[5]);
            Debug.Log("6¹ø ½½·Ô");
        }
    }

    void AddItemToSlot(int slotIndex, Sprite itemIcon)
    {
        if (slotIndex >= 0 && slotIndex < slotButtons.Length)
        {
            slotButtons[slotIndex].GetComponent<Image>().sprite = itemIcon;

            SlotAnimation slotAnimation = slotButtons[slotIndex].GetComponent<SlotAnimation>();
            if (slotAnimation != null)
            {
                slotAnimation.AnimationItemSlot();
            }
        }
    }
}
