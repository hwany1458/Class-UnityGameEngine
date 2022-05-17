using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform bullet;  // 총알
    public Transform explosion; // 폭파 불꽃

    Transform car;  // 자동차
    Transform turret;  // 포탑
    Transform spPoint;  // 스판포인트
    Transform fire;  // 발사 불꽃
    AudioSource gunSound;  // 발사 사운드

    const float RADAR_DIST = 12f;  // 자동차 탐지 거리
    const float FIRE_DIST = 10f;  // 사정거리

    bool canFire = true;

    //--------------------------
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        // 자동차와의 거리 구하기
        //float dist = Vector3.Distance(car.position, transform.position);  // 두 지점의 직선거리를 구하기
        Vector3 delta = car.position - transform.position;  // 두 지점의 거리를 Vector로 구함
        float dist = delta.magnitude;   // Vector의 길이(직선거리)를 구함

        // 레이더 탐지 거리 이내인지 검사
        // 포탑을 자동차 거리로 회전
        if (dist <= RADAR_DIST) {
            //turret.LookAt(car);
            //Vector3 delta = car.position - transform.position;
            Quaternion rot = Quaternion.LookRotation(delta);
            turret.rotation = Quaternion.Slerp(turret.rotation, rot, 5 * Time.deltaTime);
        }

        // 사정거리 이내인지 검사
        if (dist <= FIRE_DIST && canFire) { 
            StartCoroutine(AutoFire()); 
        }
        if (dist > FIRE_DIST) { 
            gunSound.Stop(); 
        }
    }

    void InitGame()
    {
        // 자동차와 포탑
        car = GameObject.Find("Tank").transform;
        turret = transform.Find("Turret");
        spPoint = transform.Find("Turret/SpPoint");

        // 발사 불꽃
        fire = transform.Find("Turret/Fire");
        fire.gameObject.SetActive(false);

        // Sound 처리
        gunSound = GetComponent<AudioSource>();
    }

    // 연발사격
    IEnumerator AutoFire()
    {
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        fire.gameObject.SetActive(true);
        gunSound.Play();
        canFire = false;
        yield return new WaitForSeconds(0.5f);
        canFire = true;
    }

    // 오브젝트 제거 – 외부호출
    void DestroySelf(Vector3 pos)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        StartCoroutine(DestroyLazy());
    }

    // 투명하게 사라지기
    IEnumerator DestroyLazy()
    {
        // 오브젝트 매터리얼 읽기
        Material mat1 = turret.GetComponent<Renderer>().material;
        Material mat2 = transform.Find("Base").GetComponent<Renderer>().material;
        Material mat3 = transform.Find("Turret/Barrel").GetComponent<Renderer>().material;
        Color color = mat1.color;

        // 투명도 설정
        for (float alpha = 1; alpha >= 0; alpha -= 0.02f)
        {
            color.a = alpha;
            mat1.color = color;
            mat2.color = color;
            mat3.color = color;
            yield return null;
        }
        Destroy(gameObject);
    }
}
