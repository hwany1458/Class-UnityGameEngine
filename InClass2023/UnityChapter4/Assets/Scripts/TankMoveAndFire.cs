using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndFire : MonoBehaviour
{
    float moveSpeed = 10f;  // ��ü �̵� �ӵ�
    float rotateSpeed = 60f;  // ��ü ȸ�� �ӵ�

    public Transform spPoint;  // ��ź ���� ��ġ�� �����Ǵ� ��������Ʈ
    public Transform bullet;   // Bullet(��ź) ������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �̵� & ȸ���ϴ� �κ� --------------

        // ���� �����ӿ��� �̵��� �Ÿ� ���
        float moveAmount = moveSpeed * Time.deltaTime;  // ��ü �̵� �Ÿ�
        float rotateAmount = rotateSpeed * Time.deltaTime;  // ��ü ȸ�� �Ÿ�(?)

        // Input Manager�� ���ǵ� �ڵ尪�� �޾ƿ�
        // ����(Vertical) �¿�(Horizontal) ���� ȭ��ǥŰ (�Ǵ� WASD)�� ����
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // �����̴� x-z������ Ȯ���ϱ� ���� �׽�Ʈ
        // 3���� �������� X��(�¿�), Y��(���Ʒ�), Z��(�յ�)
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // Left Shift ���� ���¿��� �̵�, ȸ�� �������� ... (���� �ٿ�������!)

        // ���Ʒ�ȭ��ǥ�� ��ü �̵�
        // ��ü�� �������� �̵�(����)
        transform.Translate(Vector3.forward * moveAmount * vert);
        // �¿�ȭ��ǥ�� ��ü ȸ��
        transform.Rotate(Vector3.up * rotateAmount * hori);


        // ��ź �߻�(Fire) ó���κ� --------------
        // �ܹ� ��� (���߿� ���� �߻縦 ó���� ����)
        if (Input.GetButtonDown("Fire1")) { SingleShot(); }
    }

    void SingleShot()
    {
        //Debug.Log("SingleShot() function is called ..");

        // ��ź ����
        // (���⼭�� ���� ��ź ������ �Ѵ�)
        // ��ź�� ���󰡴� ó���� ��ź(Bullet) ��ü�� ����� Bullet ��ũ��Ʈ���� ó��
        Instantiate(bullet, spPoint.position, spPoint.rotation);

        // ����Ʈ
        // ����
    }
}
