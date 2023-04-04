using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingSound : MonoBehaviour
{
    // AudioSource�� ������ ���� ���� (��������)
    AudioSource ballSound;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ������Ʈ ���� (������ �� �Ҵ�)
        // ���� �ε��Ǹ� AudioSource�� ������ �о� ����
        ballSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �浹 ó�� �Լ�
    // ������Ʈ �浹�� �߻��ϸ� ȣ��Ǵ� �̺�Ʈ �Լ�
    // �浹�� ����� ������ �Ű����� other�� ���޵�
    private void OnCollisionEnter(Collision collision)
    {
        // AudioSource�� �Ҵ�� ����� Ŭ���� ���
        ballSound.Play();
        Debug.Log("�浹�� �Ͼ�� (���)��ü�̸� =" + collision.gameObject.name);
    }
}
