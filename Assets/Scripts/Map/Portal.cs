using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad; // 이동할 씬의 이름
    public Vector3 spawnPosition; // 이동할 위치
    private GameObject player;
    private Camera mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            mainCamera = Camera.main;

            SavePlayerInfo();
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LoadPlayerInfo();
        player.transform.position = spawnPosition;

       
    }

    private void SavePlayerInfo()
    {
        Player.Instance.SavePlayerState();
        // 필요한 경우, 추가 정보를 저장할 수 있습니다.
    }

    private void LoadPlayerInfo()
    {
        player = Player.Instance.gameObject;
        // 필요한 경우, 추가 정보를 복원할 수 있습니다.
    }
}











//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Portal : MonoBehaviour
//{
//    public string sceneToLoad;
//    public Vector3 spawnPosition;
//    private GameObject player;
//    private Camera mainCamera;
//    //public GameObject toPortal;
//    private void OnTriggerEnter(Collider other)
//    {
//        if(other.CompareTag("Player"))
//        {
//            player = other.gameObject;
//            mainCamera = Camera.main;

//            SavePlayerInfo();
//            SceneManager.sceneLoaded += OnSceneLoaded;
//            SceneManager.LoadScene(sceneToLoad);
//            //other.transform.position = toPortal.transform.position;
//        }
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        player.transform.position = spawnPosition;
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//        LoadPlayerInfo();


//        // 카메라가 플레이어를 따라가도록 설정

//    }
//    private void SavePlayerInfo()
//    {
//        CharacterManager.Instance.Player = player.GetComponent<Player>();
//        // 필요한 경우, 추가 정보를 저장할 수 있습니다.
//    }

//    private void LoadPlayerInfo()
//    {
//        player = CharacterManager.Instance.Player.gameObject;
//        // 필요한 경우, 추가 정보를 복원할 수 있습니다.
//    }

//}
