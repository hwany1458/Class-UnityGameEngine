using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ ���� ȣ�� (slide 46)
        // (1) ��� ��ü�� (����) ã��
        // (2) (�˻���) �ش� ��ü�� ����� ��ũ��Ʈ �Լ��� ȣ��
        
        
        // �Ʒ� ���� �ڵ忡���� Cube���� Sphere�� ã�´�
        // ��ü�� ��Ȱ��ȭ �� ����, ��ü �˻��� ������ ���ϴ�
        // Find�� ��Ȱ��ȭ�� ��ü�� �˻� ����� ���� ���� (��, Ȱ��ȭ�� ��ü���� ������� ã��) (slide 53)

        // (�̸�����) ��ü ã�� -- return�� 1��
        GameObject obj = GameObject.Find("Sphere");
        //GameObject obj = GameObject.Find("Sphere1");
        // (�̸��� �ٲ㼭) �� ã�� ��츦 �׽�Ʈ �� ���ϴ�
        if (obj == null) {  // ��ü�� ��ã�� ���
            Debug.LogError("Object is NOT found ..");
        } else {   // ��ü�� ã�� ���
            Debug.Log("��ġ�� " + obj.transform.position.x);
            
            // SendMessage()�� ã�� ��ü�� �Լ��� ȣ��
            obj.SendMessage("WhoAmI");  // �Ű����� ���� ��

            // �����ð����� ...
            // �Ű����� 1������, 2��¥���� ����� SendMessage()�� ȣ���� ������
        }

        // �±׷� ��ü ã�� - return ������Ʈ�� 1�� (�����? ��)
        GameObject obj2 = GameObject.FindWithTag("userDefinedTag");
        if (obj2 == null) {  // ��ü�� ��ã�� ���
            Debug.LogError("Object is NOT found ..");
        } else {   // ��ü�� ã�� ���
            Debug.Log("��ġ�� " + obj.transform.position.x);
        }

        // ������ ��ü�� ã��
        // FindGameObjectWithTag() �� FindGameObjectsWithTag() -- ������ ����
        GameObject[] objs = GameObject.FindGameObjectsWithTag("userDefinedTag");
        if (objs == null) { Debug.LogError("Object is NOT found .."); }
        else {
            //for (int i = 0; i < objs.Length; i++) { }
            // ��ü�� �ٷ궧�� for()������ foreach() ���� ����
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
