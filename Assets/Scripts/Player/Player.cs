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
        // 필요한 경우, 추가 정보를 저장할 수 있습니다.
    }

    public void LoadPlayerState()
    {
        this.transform.position = savedPosition;
        // 필요한 경우, 추가 정보를 복원할 수 있습니다.
    }
}
