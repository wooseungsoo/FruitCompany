using UnityEngine;


public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour,IDamageable //shift �������� ���¹̳� ����, ������ ������ ���¹̳� ȸ��
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
            if (stamina.curValue > 5)        // curValue �� 5�̻��϶� 
            {
                stamina.Subtract(stamina.curValue * 0.005f); // stamina�� curValue �� Time.deltaTime ���� �پ���
            }
        }
        else
        {
            if (stamina.curValue < stamina.maxValue) // curValue �� maxValue ���� ������
            {
                stamina.Add(stamina.curValue * 0.004f); // stamina�� curValue �� Time.deltaTime ���� �����Ѵ�
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
    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
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
