using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public Transform explosion; // �ı��� ��ƼŬ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf(Vector3 pos)
    {
        // ���� +10
        // Ÿ�� ���� ���������� ��ƼŬ
        Instantiate(explosion, pos, Quaternion.identity);

        // Ÿ�� ���� ����ȿ��
        
        // Ÿ�� ����
        Destroy(gameObject);
        
        // Ÿ�� ���Žÿ� ���� �����ϰ� (������ ����) �� ��, ��ü ����
        // ���� 192������ ����
        // ���� �ٿ�������
    }

}
