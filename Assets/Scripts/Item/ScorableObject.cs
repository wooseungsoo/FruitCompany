using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    public int scoreValue = 10; // �� ��ü�� ������ ����
    

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� 'Fruit' �±װ� ���ԵǾ� �ִ��� Ȯ��
        if (other.CompareTag("Fruit"))
        {
            // GameManager�� AddScore �޼��带 ȣ���Ͽ� ������ �߰�
            GameManager.Instance.AddScore(scoreValue);

            // �ʿ信 ���� ��ü�� ��Ȱ��ȭ�ϰų� �ı�
            Destroy(other.gameObject);
        }
    }
}