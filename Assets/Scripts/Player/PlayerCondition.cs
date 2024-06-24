using UnityEngine;

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
        if (CharacterManager.Instance.Player.controller.dash == true)
        {
            UseStamina();
        }
        else
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);
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

    public bool UseStamina()
    {
        if (stamina.curValue - 0.25f < 0f)
        {
            return false;
        }
        stamina.Subtract(0.15f);
        return true;
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
