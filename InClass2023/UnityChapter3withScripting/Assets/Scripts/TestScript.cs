using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Ŭ������� (����Ƽ������) ��ũ��Ʈ���� �����ؾ� �Ѵ� (�����̵� 36)
    // �ٸ� ���, (��� �޽�����)
    // [���] The associated script can not be loaded. 
    // Please fix any compile errors and assign a valid script

    // �������� public vs. private (slide 22)

    // default = private
    // private���� ����� ���, �ν����Ϳ� ��Ÿ���� ����
    // private���� ���������, ��Ʈ���Ϳ� ��Ÿ���� �Ϸ���, [SerializedField]�� ���δ�
    [SerializeField]
    private int cnt = 0;

    // public���� ����� ���, �ν����Ϳ� ��Ÿ��
    // public���� ���������, �ν����Ϳ� �� ��Ÿ���� �Ϸ���, [NonSerialized]�� ���δ� 
    [System.NonSerialized]
    public int cnt1 = 0;

    // Ű�� ������ ī��Ʈ�� ���� �ֵ���
    private int keyPressedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start() function is called ..");

        // user-defined function call
        int ret = CalledFunction();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update() function is called ...");

        // �� �����Ӹ��� z�� ���� ������Ű��, ȭ�鿡���� ������ �̵��ϰԵȴ�
        //transform.position += new Vector3(0, 0, 1);

        // (1) key press �� �����Ű����
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A Key is pressed ..");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        */

        // (2)
        // 1�� ������ ����������, 2�� ������ �Ķ�������, �� ������ �ٽ� ���������� ..
        // �̷��� �����ϵ��� �ڵ带 ������ ������
        // ���� �� ó�������� ���� ���ʷ� �ۼ��ϰ�, �ڵ带 ������ ���ϴ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            keyPressedCount++;
            Debug.Log("A key is pressed, thus count is currently " + keyPressedCount);

            if ((keyPressedCount % 2) == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }

    // ����� ���� �Լ� (user-defined function)
    int CalledFunction()
    {
        Debug.Log("CalledFunction() is called ..");
        return 0;
    }

    // ����Ƽ �⺻ ���� �Լ�
    // On~ �迭 �Լ� (slide 32)
    private void OnMouseEnter()
    {
        Debug.Log("Mouse is entered ..");
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse is left ..");
    }
}
