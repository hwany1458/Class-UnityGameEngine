using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ��ȯ ���������°� int�� ����� �Լ����� (��������) ��ȯ�����͸� ���ڿ��� �޾Ƽ� ���� �߻�
        //string retValue = CalculateSum(100, 200);
        // ������ �����Ϸ���
        // (1) ��ȯ ������Ÿ���� ���ڿ��� �޵���
        // Ȥ�� (2) ��ȯ�� (������) �����͸� ���ڿ��� ��ȯ�ϵ���
        // ���⼭ (2��)���� �����ϸ� ������ ����
        string retValue = CalculateSum(100, 200).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int CalculateSum(int x, int y)
    {
        return x + y;
    }

}
