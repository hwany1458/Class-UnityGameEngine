using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform bullet;    // 총알
    public Transform explosion; // 폭파 불꽃

    Transform tank;         // 탱크
    public Transform turret;      // 포탑
    public Transform spPoint;     // 스판포인트
    public Transform fire;        // 발사 불꽃
    
    AudioSource gunSound;  // 발사 사운드

    const float RADAR_DIST = 12f;  // 자동차 탐지 거리
    const float FIRE_DIST = 10f;   // 사정거리

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
        // 탱크와 (적) 객체와의 거리 계산
        float dist = Vector3.Distance(tank.position, transform.position);

        if (dist <= RADAR_DIST) 
        {
            //Debug.Log("레이다 탐지 거리 이내에 들어왔음 ..");
            
            // *** 교재 197~198페이지를 참조하여 방향 돌리기를 부드럽게 보완 (각자)
            // 방향 돌리기
            turret.LookAt(tank);
        }

        // 탱크(아군)가 사정거리 내에 들어오고 (AND) (적군이) 발사할 수 있을 때
        if (dist <= FIRE_DIST && canFire)  
        {
            //Debug.Log("발사 사정거리 이내에 들어왔음 ..");
            // 포탄발사 (포탄 생성, 시각효과, 효과음)
            StartCoroutine(EnemyFire());
        }
    }


    IEnumerator EnemyFire()
    {
        // 포탄발사 (포탄 생성, 시각효과, 효과음)
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        fire.gameObject.SetActive(true);
        // 사운드 처리는 각자 ...
        canFire = false;
        yield return new WaitForSeconds(0.5f);
        canFire = true;
    }

}
