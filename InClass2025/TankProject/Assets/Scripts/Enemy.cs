using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //--- variables
    public Transform bullet;  // 총알 변수선언
    public Transform explosion; // 목파 파티클(불꽃)

    Transform tank;  // 자동차(여기서는 탱크) 변수선언
    Transform turret;  // 포탑
    Transform spPoint; // 적의 포탄(총알)이 만들어지는 위치
    Transform fire; // 발사 불꽃

    AudioSource gunSound;  // 발사 사운드

    const float RADIA_DIST = 12.0f;
    const float FIRE_DIST = 10.0f;

    bool canFire = true;

    // ---- Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //--------- user-defined Methods
    void InitGame()
    {
        // 자동차(여기서는 탱크)와 포탑을 검색
        tank = GameObject.Find("Tank").transform;
        turret = transform.Find("Turret");
        spPoint = transform.Find("Turret/SpPoint");

        // 발사 불꽃을 검색, 처음에 비활성화시킴
        fire = transform.Find("Turret/Fire");
        fire.gameObject.SetActive(false);

        // sound 처리
        gunSound = GetComponent<AudioSource>();
    }
}
