using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerCondition : MonoBehaviour //shift �������� ���¹̳� ����, ������ ������ ���¹̳� ȸ��
{
    public UIConditions uiCondition;

    //public float noHungerHealthDecay;
    Conditions health { get { return uiCondition.health; } }
    // Conditions hunger { get { return uiCondition.hunger; } }
    Conditions stamina { get { return uiCondition.stamina; } }


    // Update is called once per frame
    void Update()
    {
        //hunger.Subtract(hunger.passiveValue * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)) // shift ��������
        {
            if (stamina.curValue > 0)        // curValue �� 0�̻��϶� 
            {
                stamina.Subtract(0.4f); // stamina�� curValue �� 0.4�� �پ���
            }
        }
        else
        {
            if (stamina.curValue < stamina.maxValue) // curValue �� maxValue ���� ������
            {
                stamina.Add(0.3f); // stamina�� curValue �� 0.3�� �����Ѵ�
            }
        }

        if (health.curValue == 0f)
        {
            Die();
        }

        if (stamina.curValue < 5f)
        {
            Run();
        }

    }
    public void Run()
    {
        Debug.Log("��ħ");
    }

    public void Die()
    {
        Debug.Log("����ϼ̽��ϴ�.");
    }

    //public void Heal(float amount)
    //{
    //    health.Add(amount);
    //}

    //public void Eat(float amount)
    //{
    //    hunger.Add(amount);
    //}

}
