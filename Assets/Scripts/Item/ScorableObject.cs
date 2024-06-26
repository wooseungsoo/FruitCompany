using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    public int scoreValue = 10; // 이 물체가 제공할 점수
    

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체에 'Fruit' 태그가 포함되어 있는지 확인
        if (other.CompareTag("Fruit"))
        {
            // GameManager의 AddScore 메서드를 호출하여 점수를 추가
            GameManager.Instance.AddScore(scoreValue);

            // 필요에 따라 물체를 비활성화하거나 파괴
            Destroy(other.gameObject);
        }
    }
}