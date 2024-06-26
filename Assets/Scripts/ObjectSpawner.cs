using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnArea
{
    public Vector2 min; // 구역의 최소값 (x, y)
    public Vector2 max; // 구역의 최대값 (x, y)
}

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // 스폰할 오브젝트 프리팹
    public float spawnInterval = 20f; // 오브젝트 스폰 간격 (초)
    public List<SpawnArea> spawnAreas;
    //public Vector2 spawnAreaMin; // 스폰 영역의 최소값 (x, y)
    //public Vector2 spawnAreaMax; // 스폰 영역의 최대값 (x, y)
    //public Vector2 spawnAreaMin2; // 스폰 영역2의 최소값 (x, y)
    //public Vector2 spawnAreaMax2; // 스폰 영역2의 최대값 (x, y)

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            SpawnArea selectedArea = spawnAreas[Random.Range(0, spawnAreas.Count)];
            Vector2 spawnPosition = new Vector2(
               Random.Range(selectedArea.min.x, selectedArea.max.x),
               Random.Range(selectedArea.min.y, selectedArea.max.y)
           );
            //Vector2 spawnPosition = new Vector2(
            //    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            //    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            //);
            //Vector2 spawnPosition2 = new Vector2(
            //    Random.Range(spawnAreaMin2.x, spawnAreaMax2.x),
            //    Random.Range(spawnAreaMin2.y, spawnAreaMax2.y)
            //    );

            //x= spawnPosition.x+spawnPosition2.x;
            //y= spawnPosition.y+spawnPosition2.y;
            Instantiate(objectPrefab, spawnPosition , Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}