using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    /// <summary>
    /// NPC 구매메뉴 등록 변수
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
    /// NPC 구매메뉴 활성화 함수.
    /// </summary>
    public void ShowBuyMenu()
    {
        BuyMenu.SetActive(true);
    }

    /// <summary>
    /// NPC 구매메뉴 비활성화 함수
    /// </summary>
    public void HideBuyMenu()
    {
        BuyMenu.SetActive(false);
    }
}
