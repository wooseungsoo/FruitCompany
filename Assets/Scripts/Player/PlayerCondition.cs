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

        if (Input.GetKey(KeyCode.LeftShift)) // shift 눌렀을때
        {
            if (stamina.curValue > 0)        // curValue 가 0이상일때 
            {
                stamina.Subtract(0.4f); // stamina의 curValue 가 0.4씩 줄어든다
            }
        }
        else
        {
            if (stamina.curValue < stamina.maxValue) // curValue 가 maxValue 보다 작을때
            {
                stamina.Add(0.3f); // stamina의 curValue 가 0.3씩 증가한다
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
