using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{

    public Conditions health;
   // public Conditions hunger;
    public Conditions stamina;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
        CharacterManager.Instance.Player.conditionRun.runConditions = this;
    }
}
