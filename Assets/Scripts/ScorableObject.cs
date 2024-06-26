using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    public int scoreValue = 10; // ������Ʈ�� �ִ� ����
    public Transform targetPosition; // ������Ʈ�� ���ƾ� �� ��ġ

    private bool isScored = false;

    void Update()
    {
        if (!isScored && Vector3.Distance(transform.position, targetPosition.position) < 1f)
        {
            GameManager.Instance.AddScore(scoreValue);
            isScored = true;
            // ������Ʈ�� ��Ȱ��ȭ�ϰų� �ı�
            gameObject.SetActive(false);
        }
    }
}