using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankMoveAndFire : MonoBehaviour
{
    //--- variables ---
    float moveSpeed = 10f;  // 이동속도
    float rotateSpeed = 60f;   // 회전속도(초속 60)

    //public Transform spPoint;  // SpawnPoint
    Transform spPoint;  // SpawnPoint
    public Transform bullet;   // Bullet 프리팹

    float delayTime = 0.1f;   // 발사지연시간
    bool canFire = true;  // 발사 가능 여부 (총을 발사할 수 있는가?)

    //AudioSource gunSound;  // AudioSource 변수선언
    AudioSource[] gunSound;  // AudioSource 배열 선언

    Rigidbody rgBody;
    GameObject fire;   // 발사 불꽃을 처리할 변수

    int hp = 10;  // 체력
    public Transform explosion;  // 폭발 효과 프리팹

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 시작할 때 SpawnPoint의 transform 읽기
        spPoint = GameObject.Find("SpawnPoint").transform;

        //gunSound = GetComponent<AudioSource>();  // 컴포넌트 읽기
        gunSound = GetComponents<AudioSource>();  // 다수의 컴포넌트를 배열로 읽기

        rgBody = GetComponent<Rigidbody>();

        fire = GameObject.Find("FireEffect");
        fire.SetActive(false);   // 시작 시점에서는 발사 불꽃을 비활성화

    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 현재 프레임에서 이동할 거리
        float amountMove = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 오브젝트의 전방으로 이동+회전 (전진+좌우)
        transform.Translate(Vector3.forward * amountMove * vert);
        transform.Rotate(Vector3.up * amountRotate * horz);
        */

        /*
        // (과제1)
        // 제자리에서 회전만 하는 것을 막으세요
        // [힌트] 이동할 때만 회전하게
        // (과제2)
        // 쉬프트키를 누른 상태에서 이동 회전을 하면, 속도를 더 빠르게
        // 안누르면, 정속 주행
        // (과제3)
        // 이동과 회전시에 (탱크 하위 오브젝트인) 바퀴가 회전하는 효과를 추가하세요
        */

        // 단발사격
        if (Input.GetButtonDown("Fire1")) 
        { 
            SingleShoot(); 
        }

        // 연발사격
        //if (Input.GetButton("Fire2")) { AutoFire(); }
        // 연발사격 코루틴으로 구현
        //if (Input.GetButton("Fire2") && canFire)
        if (Input.GetKey(KeyCode.LeftShift) && canFire)
        {
            StartCoroutine(AutoFire2());
        }

        // 버튼을 놓으면 (연발사격의) 사운드 정지
        //if (!Input.GetButton("Fire2")) 
        if (!Input.GetKey(KeyCode.LeftShift))
        { 
            gunSound[1].Stop(); 
        }

    }

    void FixedUpdate()
    {
        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 현재 프레임에서 이동할 거리
        float amountMove = moveSpeed * Time.fixedDeltaTime * vert;
        float amountRotate = rotateSpeed * Time.fixedDeltaTime * horz;

        // 오브젝트의 전방으로 이동+회전 (전진+좌우)
        rgBody.MovePosition(transform.position + transform.forward * amountMove);
        rgBody.MoveRotation(transform.rotation * Quaternion.Euler(Vector3.up * amountRotate));
    }

    // 충돌 판정 및 처리
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tank hit: " + other.gameObject.name);
        if (other.tag == "Bullet")
        {
            hp--;
            Debug.Log("Tank hit! HP: " + hp);
            if (hp < 0)
            {
                StartCoroutine(DestroySelf());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tank collided with: " + collision.gameObject.name);
    }
    //--- User-defined functions ---
    void SingleShoot() 
    {
        // 미사일 발사 (미사일 객체 생성, 미사일이 날라가는 동작은 Bullet 스크립트에서 처리)
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        // (이후에) 처리해야할 동작 : 사운드 재생(청각적 효과), 발사 불꽃 효과(시각적 효과)

        //gunSound.Play();  // AudioClip 재생 (사운드가 하나일 때)
        gunSound[0].Play(); // AudioClip 재생 (사운드가 여러개일 때, 배열의 첫번째 사운드 재생)
        fire.SetActive(true);  // 사격 시에 발사 불꽃을 활성화
    }

    void AutoFire() 
    {
        // 발사 지연시간 계산
        delayTime += Time.deltaTime;
        if (delayTime >= 0.1f)
        {
            delayTime = 0;
            Instantiate(bullet, spPoint.position, spPoint.rotation);
        }
    }

    // 연발사격 코루틴
    IEnumerator AutoFire2()
    {
        // 미사일 발사 (미사일 객체 생성)
        Instantiate(bullet, spPoint.position, spPoint.rotation);

        // 이후에 처리해야할 동작 : SingleShoot()에서 처리한 사운드 재생과 발사 불꽃 효과를 동일하게 처리
        gunSound[1].Play();
        fire.SetActive(true);  // 사격 시에 발사 불꽃을 활성화
        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    // Reset game
    IEnumerator DestroySelf()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);

        // 현재 실행중인 씬을 다시 불러온다. 씬의 오브젝트가 모두 초기화됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
