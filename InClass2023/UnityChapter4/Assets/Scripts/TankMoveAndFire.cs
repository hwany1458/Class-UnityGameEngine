using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndFire : MonoBehaviour
{
    float moveSpeed = 10f;  // ��ü �̵� �ӵ�
    float rotateSpeed = 60f; // ��ü ȸ�� �ӵ�

    public Transform spPoint;   // ��ź ���� ��ġ�� �����Ǵ� ��������Ʈ
    public Transform bullet;    // Bullet(��ź) ������

    //float delayTime = 0.1f;  // �߻������ð�
    bool canFire = true;  // �߻�����ó���� ���� �ο� ���� (��ź�� �߻��� �� �ִ°�?)

    AudioSource[] gunSound;   // ������ҽ� ���� (�迭�κ���)

    Rigidbody rgBody;

    // ������� ���� ���� (���Ĵ� �Լ�) ---------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //gunSound = GetComponent<AudioSource>();  // �ܼ��϶� (1���� ����)
        gunSound = GetComponents<AudioSource>();   // �迭�� ����

        rgBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��ź �߻�(Fire) ó���κ� --------------

        // �ܹ� ��� 
        if (Input.GetButtonDown("Fire1")) { SingleShot(); }
        
        // ���� ���
        //if (Input.GetButton("Fire2")) { AutoFire(); }
        // ���� ��ݿ��� ������ ������(����)�� �ֱ� ����
        if (Input.GetButton("Fire2") && canFire) { StartCoroutine(AutoFire()); }

        // *** ���ӹ߻� ����ȿ���� (��ư�� ������) ���尡 �����ϵ���  (���� 159������ ����)
        if(!Input.GetButton("Fire2")) { gunSound[1].Stop(); }
    }

    private void FixedUpdate()
    {
        // �̵� & ȸ���ϴ� �κ� --------------
        // ���� �����ӿ��� �̵��� �Ÿ� ���
        float moveAmount = moveSpeed * Time.deltaTime;  // ��ü �̵� �Ÿ�
        float rotateAmount = rotateSpeed * Time.deltaTime; // ��ü ȸ�� �Ÿ�(?)

        // Input Manager�� ���ǵ� �ڵ尪�� �޾ƿ�
        // ����(Vertical) �¿�(Horizontal) ���� ȭ��ǥŰ (�Ǵ� WASD)�� ����
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // *** Left Shift ���� ���¿��� �̵�, ȸ�� �������� ...

        // �����̴� x-z������ Ȯ���ϱ� ����
        // 3���� �������� X��(�¿�), Y��(���Ʒ�), Z��(�յ�)
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // ���Ʒ�ȭ��ǥ�� ��ü �̵�
        // ��ü�� �������� �̵�(����)
        transform.Translate(Vector3.forward * moveAmount * vert);
        // �¿�ȭ��ǥ�� ��ü ȸ��
        transform.Rotate(Vector3.up * rotateAmount * hori);

        // �̳��ϰ� ���� ���ϰ� ���̸� üũ�غ��ô�
        //rgBody.MovePosition(rgBody.position + transform.forward * moveAmount);
        //rgBody.MoveRotation(rgBody.rotation * Quaternion.Euler(Vector3.up * rotateAmount));

    }

    void SingleShot()
    {
        Debug.Log("SingleShot() function is called ..");
        // ��ź ����
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        
        // ����Ʈ

        // ����
        //gunSound.Play();   // AudioSource�� �ϳ��� ����
        gunSound[0].Play();   // �迭�� ����
    }

    //void AutoFire()
    // ���� �߻� Coroutine
    IEnumerator AutoFire()
    {
        /*
         * �߻簣���� �ð����� ���� (���� 153������ ����)
        delayTime += Time.deltaTime;
        if (delayTime >= 0.1f) { 
            Debug.Log("AutoFire() function is called ..");
            Instantiate(bullet, spPoint.position, spPoint.rotation);
            delayTime = 0;
        }
        */

        // Coroutine�� Ȱ���Ͽ� �߻� ������ �����ϵ��� ���� (���� 154������ ����)
        // ��ź ����
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        // *** �˾Ƽ� (ã�Ƽ�), ���ӹ߻� ���� ����ȿ���� �ݿ��ϼ��� (���� 158������ ����)
        // ����
        gunSound[1].Play();

        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;

    }
}
