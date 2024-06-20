using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerCondition : MonoBehaviour //shift 눌렀을때 스태미나 감소, 가만히 있을때 스태미나 회복
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina.curValue > 5)
            {
                stamina.Subtract(stamina.curValue * Time.deltaTime);
            }
        }
        else
        {
            if (stamina.curValue < stamina.maxValue)
            {
                stamina.Add(stamina.curValue * Time.deltaTime);
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
        Debug.Log("지침");
    }

    public void Die()
    {
        Debug.Log("사망하셨습니다.");
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
