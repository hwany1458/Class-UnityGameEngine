using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    float speed = 5.0f;     // �̵��ӵ�
    //Rigidbody rigidbody;
    float vArrow;
    float vert, hori;
    float speedR = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �����ӿ��� �̵��� �Ÿ�
        float moveSpeed = speed * Time.deltaTime;
        float rotateSpeed = speedR * Time.deltaTime;

        // ------------------------ Ű �Է� �׽�Ʈ
        if (Input.GetButton("Jump")) { Debug.Log("Jump, Space bar is pressed .."); }
        vArrow = Input.GetAxis("Vertical");
        if (vArrow != 0.0) { Debug.Log("Vertical : " + vArrow); }
        if (Input.GetKey(KeyCode.Space)) { Debug.Log("GetKey : Space bar is pressed .."); }

        // ����(Vertical) �¿�(Horizontal) �̵�Ű�� ����
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // �����¿� �̵�
        //transform.Translate(new Vector3(hori, 0, vert) * moveSpeed);

        // �����̵�-����, �¿�ȸ��
        transform.Translate(Vector3.forward * moveSpeed * vert);
        transform.Rotate(Vector3.up * rotateSpeed * hori);

        // ------------------------ ������Ʈ �̵�
        // Translate() �Լ� �̿�
        //transform.Translate(Vector3.forward * moveSpeed, Space.Self);
        //transform.Translate(new Vector3(0,0,1) * moveSpeed);

        // ������Ʈ�� ��ġ �� �̿�
        //transform.position += new Vector3(0, 0, 1) * moveSpeed;

        // ������ٵ� �̿� (�ӵ� �Ǵ� ��)
        // RigidBody�� ������ ��, �ӵ����� ����
        //rigidbody.velocity = new Vector3(0, 0, 1);
        // RigidBody�� Force�� �����Ͽ� ������
        //rigidbody.AddForce(new Vector3(0, 0, 1));

    }
}
