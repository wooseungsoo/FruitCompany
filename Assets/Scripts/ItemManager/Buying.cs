using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    /// <summary>
    /// NPC ���Ÿ޴� ��� ����
    /// </summary>
    public GameObject BuyMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// NPC ���Ÿ޴� Ȱ��ȭ �Լ�.
    /// </summary>
    public void ShowBuyMenu()
    {
        BuyMenu.SetActive(true);
    }

    /// <summary>
    /// NPC ���Ÿ޴� ��Ȱ��ȭ �Լ�
    /// </summary>
    public void HideBuyMenu()
    {
        BuyMenu.SetActive(false);
    }
}
