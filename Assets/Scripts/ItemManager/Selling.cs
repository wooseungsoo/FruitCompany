using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Selling : MonoBehaviour
{
    /// <summary>
    /// NPC �ǸŸ޴� ��� ����
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
    /// NPC �ǸŸ޴� Ȱ��ȭ �Լ�
    /// </summary>
    public void ShowSellMenu()
    {
        SellMenu.SetActive(true);
    }


    /// <summary>
    /// NPC �ǸŸ޴� ��Ȱ��ȭ �Լ�
    /// </summary>
    public void HideSellMenu()
    {
        SellMenu.SetActive(false);
    }

}
