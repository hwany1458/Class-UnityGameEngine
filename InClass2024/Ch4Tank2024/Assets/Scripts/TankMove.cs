using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // --- Variables
    float moveSpeed = 10.0f;  // �̵��ӵ�
    float rotateSpeed = 60.0f;  // ȸ���ӵ�
    const float sprintMode = 2.0f;  // ������Ʈ �ÿ� 2�� ������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // FPS�� ����Ͽ� ��ŸŸ���� ����
        float moveAmount = moveSpeed * Time.deltaTime;  // �̵��Ÿ�(���� �����ӿ��� �̵��� �Ÿ�)
        float rotateAmount = rotateSpeed * Time.deltaTime;  // ȸ��ũ��

        float vert = Input.GetAxis("Vertical");  // Ű����κ��� �Է� ���� ȭ��ǥ(�Ǵ� ws)
        float hori = Input.GetAxis("Horizontal");  // Ű����κ��� �Է� �¿� ȭ��ǥ (�Ǵ� ad)
        //Debug.Log(vert.ToString());

        // GetKey() �׽�Ʈ
        // ����Ʈ Ű�� ���� ���¿��� �̵� ȸ���� �� ���, ���� ��������
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("Left Shift key is pressed ...");
            moveAmount *= sprintMode;
            rotateAmount *= sprintMode;
        }

        // ���ӿ�����Ʈ�� �������� �̵�
        // Translate() : ���� ��ġ���� ������ �������� ������ �Ÿ���ŭ ��ü�� �̵���Ű�� �Լ�
        //transform.Translate(Vector3.forward * moveAmount);

        // Ű����κ��� (ȭ��ǥŰ��) �Է¹޾� ��ü�� �̵� Ȯ��
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // �յ� �̵�
        transform.Translate(Vector3.forward * moveAmount * vert);
        // �¿�� ȸ��
        // ���ڸ� ȸ���� ���� ������ ... how?
        // �յ��̵��� �����鼭 ȸ���� �Ұ�� (vert=0�� ���) ȸ������ �ʵ���
        if (vert != 0)
        {
            transform.Rotate(Vector3.up * rotateAmount * hori);
        }

        // Ű���� �Է� ����
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Left Control Key is pressed..");
        }

    }
}
