using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // --- Variables
    public float moveSpeed = 10.0f;  // �̵��ӵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �����ӿ��� �̵��� �Ÿ�
        float moveAmount = moveSpeed * Time.deltaTime;

        // ���ӿ�����Ʈ�� �������� �̵�
        // Translate() : ���� ��ġ���� ������ �������� ������ �Ÿ���ŭ ��ü�� �̵���Ű�� �Լ�
        transform.Translate(Vector3.forward * moveAmount);
    }
}
