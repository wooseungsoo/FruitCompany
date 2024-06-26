using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    public int scoreValue = 10; // 오브젝트가 주는 점수
    public Transform targetPosition; // 오브젝트를 놓아야 할 위치

    private bool isScored = false;

    void Update()
    {
        if (!isScored && Vector3.Distance(transform.position, targetPosition.position) < 1f)
        {
            GameManager.Instance.AddScore(scoreValue);
            isScored = true;
            // 오브젝트를 비활성화하거나 파괴
            gameObject.SetActive(false);
        }
    }
}