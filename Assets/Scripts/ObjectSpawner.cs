using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnArea
{
    public Vector2 min; // ������ �ּҰ� (x, y)
    public Vector2 max; // ������ �ִ밪 (x, y)
}

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // ������ ������Ʈ ������
    public float spawnInterval = 20f; // ������Ʈ ���� ���� (��)
    public List<SpawnArea> spawnAreas;
    //public Vector2 spawnAreaMin; // ���� ������ �ּҰ� (x, y)
    //public Vector2 spawnAreaMax; // ���� ������ �ִ밪 (x, y)
    //public Vector2 spawnAreaMin2; // ���� ����2�� �ּҰ� (x, y)
    //public Vector2 spawnAreaMax2; // ���� ����2�� �ִ밪 (x, y)

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