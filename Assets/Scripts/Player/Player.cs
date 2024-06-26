using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action addItem;
    public Vector3 restartPosition;
    public Transform dropPosition;
    public static Player Instance { get; private set; }
    private Vector3 savedPosition;

    public void RestartSeungsoo()
    {
        this.transform.position = restartPosition;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

    }
    public void SavePlayerState()
    {
        savedPosition = this.transform.position;
        // �ʿ��� ���, �߰� ������ ������ �� �ֽ��ϴ�.
    }

    public void LoadPlayerState()
    {
        this.transform.position = savedPosition;
        // �ʿ��� ���, �߰� ������ ������ �� �ֽ��ϴ�.
    }
}
