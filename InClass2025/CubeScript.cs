using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    //--------- Variables (��������)
    // ��������
    public int speed = 200;
    public string nameOfBox = "candy box";
    public bool isFound = false;
    public int isColor;

    // public���� ����� ������ (�⺻������) �ν����Ϳ� �Ӽ����� ��Ÿ��
    // ��Ÿ���� �ʰ� �Ϸ���, NonSerialized
    [System.NonSerialized]  
    public int hp;
    // private���� ����� ������ (�⺻������) �ν����Ϳ� ��Ÿ���� ����
    // ��Ÿ���� �Ϸ���, SerializeField
    [SerializeField]
    private float moveAmount = 0.5f;

    //--------- Methods (�޼ҵ� ����)

    // �� ó��, �ѹ� ���� (�ʱ�ȭ��ų �� �ַ� ���)
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        Debug.Log("Start() method is called ...");
        isColor = 1;

        // ���� �ִ� ��ü�� ã������ GameObject.Find() �Լ� ���
        // ��ü�� ã�� ���� Ȱ��ȭ�Ǿ� �ִ� ��ü���� ������� Ž���Ѵ�
        GameObject foundObj = GameObject.Find("Sphere");

        // ��ü�� ã�� ���� ��ã�� ��츦 �����ؼ� �ڵ� -- ���� ����
        if (foundObj == null) // ��ã�� ���
        {
            Debug.Log("��ü�� ��ã�ҽ��ϴ�");
        }
        else // ã�� ���
        {
            Debug.Log(foundObj.transform.position.x);
            // Quiz
            // ������ �̸��� ��ü�� ������ �ִ� ���,
            // (���� ���� ã�� ��ü�� �߿���) ���������� ã�� ��ü�� ������� ��

            // ----- ã�� ��ü�� ����� ��ũ��Ʈ�� �Լ��� ȣ���ϴ� ���
            // (���1) SendMessage() �Լ� �̿�
            // public�̵� private�̵� ������� �޼ҵ� ȣ�� ����
            //foundObj.SendMessage("WhoAreYou");

            // (���2) (ã�� ��ü��) ������Ʈ�� �����ؼ� ����
            // public���� ����� �޼ҵ常 ������ ����
            foundObj.GetComponent<SphereScript>().WhoAreYou();
            // Quiz
            // ���� private�� ����Ǿ� ���� ���, �޽��� [��ȣ ���� ������ SphereScript.WhoAreYou()�� �׼����� �� �����ϴ�]
        }
    }

    // ���Ӿ����� �� �����Ӹ��� ����
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update() method is called ..");

        /*----------
        // Ű���忡�� Ư��Ű�� ������ ��, if���� ������ ���� �Ǿ�, �̺�Ʈ �߻�
        if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        ---------- */

        // Practice 
        // ������ ���� ���¸� �����ؾ� �ϹǷ�, isColor ������ �����Ͽ� ���� ���¸� ����
        // �ѹ� ������ ����������, �ٽ� �ѹ�(��) ������ �Ķ������� ����
        if (Input.GetKeyDown(KeyCode.R) && isColor==1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            isColor = 2;
        } 
        else if (Input.GetKeyDown(KeyCode.R) && isColor == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            isColor = 1;
        }

        // Debug.Log() �Լ��� �Ἥ, �ֿܼ� ������ �ѷ����� (�����߿� ���� Ȯ����
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("U pressed A key..");
        }


        /* --------------
        // (��ũ��Ʈ�� �����) ��ü �̵�
        // (���1) ��ġ��(�Ӽ�)�� �����ϴ� ���
        // a = a+1; (=) a+=1;
        // ���� ��ġ���� z���� ��������, 1��ŭ ������ �̵�
        transform.position += new Vector3(0, 0, 1);
        // (���2) �̵��϶�� ���(�Լ�) ȣ��
        transform.Translate(Vector3.forward * moveAmount);
        ------------ */

    }

    // ���콺 Ŭ���� ���� ��, �̺�Ʈ �߻�(�Լ� ȣ���)
    void OnMouseDown()
    {
        Debug.Log("Mouse click");
    }

    // ���콺 Ŭ���� �� ��, �̺�Ʈ �߻�(�Լ� ȣ���)
    void OnMouseUp()
    {
        Debug.Log("Mouse UP");
    }

    // ���콺 (�̵��ϸ鼭) ��ü ������ �� ��, �̺�Ʈ �߻�(�Լ� ȣ���)
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    // ���콺 (�̵��ϸ鼭) ��ü �������� �������� ��, �̺�Ʈ �߻�(�Լ� ȣ���)
    void OnMouseExit()
    {
        Debug.Log("Mouse out ");
    }


    // MonoBehaviour ����
    //https://docs.unity3d.com/kr/2023.2/ScriptReference/MonoBehaviour.html

    // ����Ƽ���� ��ũ��Ʈ �̸��� �����Ͽ� (Ŭ���� �̸���) ���� ���� ��, �޽���
    // (�ν����Ϳ�) ���â�� ������ �����϶�� ����
    // [The associated script can not be loaded. Please fix any compile errors and assign a valid script] 


    //---------- User-defined Methods (����� ���� �޼ҵ�)
}
