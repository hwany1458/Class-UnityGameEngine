using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 30f;  // ��ź ���󰡴� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ź(Bullet) ��ü�� �����Ǹ鼭 ��ũ��Ʈ�� ����ǰ�
        // ��ü ������ ����, 2�� �Ŀ� ��ü�� ȭ��(��)���� ����
        // ��ü ���� ������ �����ڷ� 73�����̵� ����
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float bulletAmount = bulletSpeed * Time.deltaTime; // ��ź ���󰡴� �Ÿ�

        // ��ź(Bullet)�� �������� �̵� (=���󰡵���)
        transform.Translate(Vector3.forward * bulletAmount);
    }
}
