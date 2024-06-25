using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 spawnPosition;
    private GameObject player;
    private Camera mainCamera;
    //public GameObject toPortal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            mainCamera = Camera.main;

            SavePlayerInfo();
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneToLoad);
            //other.transform.position = toPortal.transform.position;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LoadPlayerInfo();
        player.transform.position = spawnPosition;

        // ī�޶� �÷��̾ ���󰡵��� ����
        
    }
    private void SavePlayerInfo()
    {
        CharacterManager.Instance.Player = player.GetComponent<Player>();
        // �ʿ��� ���, �߰� ������ ������ �� �ֽ��ϴ�.
    }

    private void LoadPlayerInfo()
    {
        player = CharacterManager.Instance.Player.gameObject;
        // �ʿ��� ���, �߰� ������ ������ �� �ֽ��ϴ�.
    }

}
