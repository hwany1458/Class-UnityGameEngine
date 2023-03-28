using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // (�̸�����) ��ü ã�� -- return�� 1��
        GameObject obj = GameObject.Find("Sphere");
        if (obj == null) {  // ��ü�� ��ã�� ���
            Debug.LogError("Object is NOT found ..");
        } else {   // ��ü�� ã�� ���
            Debug.Log("��ġ�� " + obj.transform.position.x);
            
            // SendMessage()�� ã�� ��ü�� �Լ��� ȣ��
            obj.SendMessage("WhoAmI");  // �Ű����� ���� ��

            // �����ð����� ...
            // �Ű����� 1������, 2��¥���� ����� SendMessage()�� ȣ���� ������
        }

        // �±׷� ��ü ã��
        GameObject obj2 = GameObject.FindWithTag("userDefinedTag");
        if (obj2 == null) {  // ��ü�� ��ã�� ���
            Debug.LogError("Object is NOT found ..");
        } else {   // ��ü�� ã�� ���
            Debug.Log("��ġ�� " + obj.transform.position.x);
        }

        // �ټ��� ã��
        GameObject[] objs = GameObject.FindGameObjectsWithTag("userDefinedTag");
        if (objs == null) { Debug.LogError("Object is NOT found .."); }
        else {
            //for (int i = 0; i < objs.Length; i++) { }
            //foreach (GameObject eachObj in objs) {
            foreach (var eachObj in objs) {
                Debug.Log("�ݺ���: ��ġ " + eachObj.transform.position.x);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
