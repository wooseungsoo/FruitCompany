using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class QuickSlotController : MonoBehaviour
{
    public Button[] slotButtons;

    public void Update()
    {
        InputNumber();
    }

    void InputNumber() // ������ null �̸� ItemData�� �ҷ��ͼ� ������ ��Ų��.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItemToSlot(0);
            Debug.Log("1�� ����");
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItemToSlot(1);
            Debug.Log("2�� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItemToSlot(2);
            Debug.Log("3�� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AddItemToSlot(3);
            Debug.Log("4�� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AddItemToSlot(4);
            Debug.Log("5�� ����");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddItemToSlot(5);
            Debug.Log("6�� ����");
        }
    }

    void AddItemToSlot(int slotCount)
    {
        if (slotCount >= 0 && slotCount < slotButtons.Length)
        {
            SlotAnimation slotAnimation = slotButtons[slotCount].GetComponent<SlotAnimation>();
            if (slotAnimation != null)
            {
                slotAnimation.AnimationItemSlot();
            }
        }
    }
}
