using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    /// <summary>
    /// 플레이어 게임 오브젝트를 받아오는 변수
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// NPC의 대화메뉴 창을 받아오는 변수
    /// </summary>
    public GameObject NPC_Menu;

    /// <summary>
    /// 플레이어와 NPC 사이의 거리
    /// </summary>
    public float distance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, transform.position);

        VisibleMouse();
        ShowMenu_NPC();

    }

    /// <summary>
    /// 마우스 커서를 활성화 & 비활성화 시키는 코드
    /// </summary>
    public void VisibleMouse()
    {
        if (distance < 3)
        {
            // 마우스 커서 활성화
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // 마우스 커서 비활성화
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// NPC의 대화 메뉴를 활성화 & 비활성화 하는 코드
    /// </summary>
    public void ShowMenu_NPC()
    {
        if (distance < 3)
        {
            // NPC 메뉴 활성화
            NPC_Menu.SetActive(true);
        }
        else
        {
            // NPC 메뉴 비활성화
            NPC_Menu.SetActive(false);
        }
    }
}
