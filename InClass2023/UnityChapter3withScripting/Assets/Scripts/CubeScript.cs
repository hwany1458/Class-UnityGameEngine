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
            
            // ��ũ��Ʈ���� ȣ�� (1�� ���) - SendMessage()
            // �Լ��� public �̵� private �̵� ������� ȣ�� ����
            // SendMessage()�� ã�� ��ü�� �Լ��� ȣ��
            obj.SendMessage("WhoAmI");  // �Ű����� ���� ��
            // �Ű����� 2��¥���� ����� SendMessage()�� ȣ���� ������
            obj.SendMessage("WhoWeAre", "Digital Contents");

            // ��ũ��Ʈ���� ȣ�� (2�� ���) - GetComponent<>()
            // ã�� ��ü�� obj ������ �޾Ƴ�����
            // ȣ���Ϸ��� �Լ��� �ݵ�� public���� ���ٱ����� �ο��Ǿ� �־����
            // private�� ��� : ���� �߻�
            //  error CS0122: 'SphereScript.WhoAmI()' is inaccessible due to its protection level
            obj.GetComponent<SphereScript>().WhoAmI();

            // Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ���� (Slide 61)
            GameObject getObj = GameObject.Find("SnowMan");
            if (getObj != null)
            {
                Debug.Log("Object found");

                // (1) ���� ������Ʈ �ٷ� �Ʒ��� �ִ� �ڽ� ������Ʈ(�� �� �ϳ�)�� ����
                // �ڽ� ������Ʈ�� ���� �����, TransformSort �������� ���� ������ �ִ� �ڽ� ������Ʈ�� ������Ʈ�� �޾ƿ�
                Transform getChild = getObj.transform.GetChild(0);
                Debug.Log("�ڽ� ������Ʈ �̸� = " + getChild.name);

                // GetComponentInChild�� ������ ������Ʈ �ϳ��� ����
                getChild = getObj.GetComponentInChildren<Transform>();
                Debug.Log("(GetComponentInChild��) �ڽ� ������Ʈ �̸� = " + getChild.name + " �Ф�");

                // (2) ���� ������Ʈ �Ʒ��� �ִ� ��� �ڽ� ������Ʈ��� ����
                Transform[] getChildren = getObj.GetComponentsInChildren<Transform>();
                if (getChildren != null)
                {
                    Debug.Log("��ü���� ã�Ұ�, �̹����� ���� �ڽĵ��� ����� ���ڽ��ϴ�");
                    foreach (Transform child in getChildren)
                    {
                        // �ڽ� ������Ʈ���� �������µ�, (�˻���) �θ� ������Ʈ�� ���ԵǾ� ����
                        // �θ� ������Ʈ�� ���ܽ�Ű����
                        if (child.name == "SnowMan") { continue;  } // �θ� ������Ʈ �ڽ��̸� �ݺ����� Skip
                        Debug.Log("�ڽĵ� " + child.name);
                    }
                }
                else
                {
                    Debug.LogWarning("Object is found, however there is NO child ..");
                }
            }
            else
            {
                Debug.LogWarning("Object is NOT found ..");
            }
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
