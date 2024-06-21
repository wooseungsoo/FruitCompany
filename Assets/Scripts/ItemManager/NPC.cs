using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    /// <summary>
    /// �÷��̾� ���� ������Ʈ�� �޾ƿ��� ����
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// NPC�� ��ȭ�޴� â�� �޾ƿ��� ����
    /// </summary>
    public GameObject NPC_Menu;

    /// <summary>
    /// �÷��̾�� NPC ������ �Ÿ�
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
    /// ���콺 Ŀ���� Ȱ��ȭ & ��Ȱ��ȭ ��Ű�� �ڵ�
    /// </summary>
    public void VisibleMouse()
    {
        if (distance < 3)
        {
            // ���콺 Ŀ�� Ȱ��ȭ
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // ���콺 Ŀ�� ��Ȱ��ȭ
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// NPC�� ��ȭ �޴��� Ȱ��ȭ & ��Ȱ��ȭ �ϴ� �ڵ�
    /// </summary>
    public void ShowMenu_NPC()
    {
        if (distance < 3)
        {
            // NPC �޴� Ȱ��ȭ
            NPC_Menu.SetActive(true);
        }
        else
        {
            // NPC �޴� ��Ȱ��ȭ
            NPC_Menu.SetActive(false);
        }
    }
}
