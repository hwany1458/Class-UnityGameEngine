using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed);
    }

    // �浹 ������ ó��
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger..() �̺�Ʈ �߻� " + other.name + " " + other.tag);
        if (other.tag == "Target")
        {
            // �浹�� ������Ʈ�� ���(Target) �̸� (�����Ͽ����Ƿ�) �ش� ������Ʈ�� ��ȭ�� ����
            // �Ѿ� ��ũ��Ʈ���� ��� �ı��� ���� �ʰ�, ��� ��ũ��Ʈ���� �ı��ǵ��� ����
            // ��� ��ü���� �޽��� ���� ������� ó��
            //Destroy(other.gameObject);
            other.SendMessage("DestroySelf", transform.position);
        }
        if (other.tag == "Enemy")
        {
            other.transform.root.SendMessage("DestroySelf", transform.position);
        }

        // �浹 �߻��ϸ�, �Ѿ˵� ��ü�ı�
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollision..() �̺�Ʈ �߻� " + collision.gameObject.name + " " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
