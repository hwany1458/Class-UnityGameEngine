using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // �� ��ũ��Ʈ�� ��ũ ��ü�� �̵��� ȸ���� ó���ϴ� ��ũ��Ʈ
    // �̵��� ȸ�� ó��, ��ź �߻� ó���� �ϳ��� ��ũ��Ʈ���� ó���ϱ� ����
    // TankMoveAndFire ��ũ��Ʈ�� �������
    // �� ��ũ��Ʈ�� ���̻� ������� ���� ������

    float moveSpeed = 10f;
    float rotateSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        float rotateAmount = rotateSpeed * Time.deltaTime;
        
        // Input Manager�� ���ǵ� �ڵ尪�� �޾ƿ�
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // �����̴� x-z������ Ȯ���ϱ� ����
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // ���Ʒ�ȭ��ǥ�� ��ü �̵�
        transform.Translate(Vector3.forward * moveAmount * vert);
        // �¿�ȭ��ǥ�� ��ü ȸ��
        transform.Rotate(Vector3.up * rotateAmount * hori);

        // 
    }
}
