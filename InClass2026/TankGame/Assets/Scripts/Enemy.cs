using System.Collections;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    //--- variables ---
    public Transform bullet;       // 총알
    public Transform explosion;  // 폭파 불꽃

    Transform tank;         // 탱크
    Transform turret;       // 포탑
    Transform spPoint;     // 스판포인트
    Transform fire;          // 발사 불꽃
    AudioSource gunSound;  // 발사 사운드

    const float RADAR_DIST = 12f;  // 탱크 탐지 거리
    const float FIRE_DIST = 10f;      // 사정거리

    bool canFire = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        // 탱크와의 거리 구하기
        //float dist = Vector3.Distance(tank.position, transform.position);  // 두 지점의 직선거리를 구하기
        // 중복 계산 방지 위해, 탱크와의 거리 구하기 전에 탱크가 존재하는지 검사
        Vector3 delta = tank.position - transform.position;  // 두 지점의 거리를 Vector로 구함
        float dist = delta.magnitude;   // Vector의 길이(직선거리)를 구함

        // 레이더 탐지 거리 이내인지 검사
        if (dist <= RADAR_DIST) 
        {
            //turret.LookAt(tank); // 포탑을 탱크 방향으로 회전
            // 부드럽게 회전하기 위해 LookAt 대신 Slerp 사용
            //Vector3 delta = tank.position - transform.position;
            Quaternion rot = Quaternion.LookRotation(delta); 
            turret.rotation = Quaternion.Slerp(turret.rotation, rot, 5 * Time.deltaTime);

        }

        // 사정거리 이내인지 검사
        if (dist <= FIRE_DIST && canFire) 
        { 
            StartCoroutine(AutoFire()); 
        }
        
        if (dist > FIRE_DIST) 
        { 
            gunSound.Stop(); 
        }

    }

    //--- User Defined Methods ---
    void InitGame()
    {
        // 탱크와 포탑
        tank = GameObject.Find("Tank").transform;
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

        yield return new WaitForSeconds(0.2f);
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
