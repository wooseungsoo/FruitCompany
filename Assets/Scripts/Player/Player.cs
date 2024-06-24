using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerController conditionRun;
    public PlayerCondition condition;


    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;

        controller = GetComponent<PlayerController>();
        conditionRun = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

    }
}
