using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunch : MonoBehaviour
{
    // -- Variables
    float moveSpeed = 30.0f;  // ��ź (���󰡴�) �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ü ���� ��, Start() �Լ��� �ѹ� ����Ǵµ�,
        // ��ü(�̻���) �����ϰ� 3�� �Ŀ� �ڵ����� ��ü�� ����(�ı�)�ǵ���
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // ��ü(�̻���)�� ���󰡵���
        // Translate() �Լ��� �Ἥ, ��ü�� �̵���Ŵ
        float moveAmount = moveSpeed * Time.deltaTime;  // ��ź (���󰡴�) �Ÿ�
        
        // ��ź(Missile)�� �������� �̵���Ŵ (���󰡵���)
        transform.Translate(Vector3.forward * moveAmount);
    }
}
