using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Selling : MonoBehaviour
{
    /// <summary>
    /// NPC 판매메뉴 등록 변수
    /// </summary>
    public GameObject SellMenu;


    public List<GameObject> SellItems;

    public List<GameObject> SoldOutList;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// NPC 판매메뉴 활성화 함수
    /// </summary>
    public void ShowSellMenu()
    {
        SellMenu.SetActive(true);
    }


    /// <summary>
    /// NPC 판매메뉴 비활성화 함수
    /// </summary>
    public void HideSellMenu()
    {
        SellMenu.SetActive(false);
    }

}
