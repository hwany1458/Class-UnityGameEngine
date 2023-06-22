using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform bullet;    // �Ѿ�
    public Transform explosion; // ���� �Ҳ�

    Transform tank;         // ��ũ
    public Transform turret;      // ��ž
    public Transform spPoint;     // ��������Ʈ
    public Transform fire;        // �߻� �Ҳ�
    
    AudioSource gunSound;  // �߻� ����

    const float RADAR_DIST = 12f;  // �ڵ��� Ž�� �Ÿ�
    const float FIRE_DIST = 10f;   // �����Ÿ�

    bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.Find("TankFree_Blue").transform;
        //turret = transform.Find("P_Turret");
        //spPoint = transform.Find("Enemy/EnemySpawnPoint");
        //fire = transform.Find("Enemy/FireEffect (1)");
        fire.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ��ũ�� (��) ��ü���� �Ÿ� ���
        float dist = Vector3.Distance(tank.position, transform.position);

        if (dist <= RADAR_DIST) 
        {
            //Debug.Log("���̴� Ž�� �Ÿ� �̳��� ������ ..");
            
            // *** ���� 197~198�������� �����Ͽ� ���� �����⸦ �ε巴�� ���� (����)
            // ���� ������
            turret.LookAt(tank);
        }

        // ��ũ(�Ʊ�)�� �����Ÿ� ���� ������ (AND) (������) �߻��� �� ���� ��
        if (dist <= FIRE_DIST && canFire)  
        {
            //Debug.Log("�߻� �����Ÿ� �̳��� ������ ..");
            // ��ź�߻� (��ź ����, �ð�ȿ��, ȿ����)
            StartCoroutine(EnemyFire());
        }
    }


    IEnumerator EnemyFire()
    {
        // ��ź�߻� (��ź ����, �ð�ȿ��, ȿ����)
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        fire.gameObject.SetActive(true);
        // ���� ó���� ���� ...
        canFire = false;
        yield return new WaitForSeconds(0.5f);
        canFire = true;
    }

}
