using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 30f;  // ��ź ���󰡴� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ź(Bullet) ��ü�� �����Ǹ鼭 ��ũ��Ʈ�� ����ǰ�
        // ��ü ������ ����, 2�� �Ŀ� ��ü�� ȭ��(��)���� ����
        // ��ü ���� ������ �����ڷ� 73�����̵� ����
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float bulletAmount = bulletSpeed * Time.deltaTime; // ��ź ���󰡴� �Ÿ�

        // ��ź(Bullet)�� �������� �̵� (=���󰡵���)
        transform.Translate(Vector3.forward * bulletAmount);
    }

    // �浹 ���� �� ó�� -- collision (isTrigger is unchecked)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() " + collision.gameObject.name + "--" + collision.gameObject.tag);
    }

    // �浹 ���� �� ó�� -- trigger (isTrigger is checked)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter() " + other.name + "**" + other.tag);
        
        // ��ź(�Ѿ�)�� �浹�� �Ͼ ��� ��ü üũ
        if (other.tag == "Target10")
        {
            // ó���� ������� (�������)
            // (1) ���� +10
            // (2) Ÿ�� ���� ���������� ��ƼŬ
            // (3) Ÿ�� ���� ����ȿ��
            // (4) Ÿ�� ����
            //Destroy(other.gameObject);
            
            // ��ź(�Ѿ�)������ �浹�� �Ǻ��ϰ� �浹 ó�� �κ��� ��� ��ü���� ó���ϵ��� ����
            other.SendMessage("DestroySelf", transform.position);
            //other.GetComponent<TargetControl>().DestroySelf(transform.position);
        } 
        
        // (���󰡴� ��ź��) ������ �浹�� �Ͼ ���
        if (other.tag == "Enemy")
        {
            other.transform.root.GetComponent<TargetControl>().DestroySelf(transform.position);
        }

        // �浹 �߻� ���Ŀ�, ��ź(�Ѿ�) ����
        Destroy(gameObject);
    }
}
