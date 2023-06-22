using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // 씬 전환을 위해서 필요함
using UnityEngine.UI;  // (Legacy)Text를 쓸때 필요함
//using TMPro;   // TextMeshPro를 쓸때 필요함

public class TankMoveAndFire : MonoBehaviour
{
    float moveSpeed = 10f; // 객체 이동 속도
    float rotateSpeed = 60f; // 객체 회전 속도

    public Transform spPoint; // 포탄 생성 위치로 지정되는 스판포인트
    public Transform bullet; // Bullet(포탄) 프리팹

    //float delayTime = 0.1f;  // 발사지연시간
    bool canFire = true; // 발사지연처리를 위한 부울 변수 (포탄을 발사할 수 있는가?)

    AudioSource[] gunSound;   // 오디오소스 선언 (배열로변경)

    Rigidbody rgBody;

    GameObject fire;  // 포탄발사 시에 효과이미지(조명)

    int hp = 10;
    //int score = 0;

    public GameObject explosion;  // 탱크(아군) 폭파시의 파티클
    public Text countText;
    //public TMP_Text hpText;  //hpText라는 이름으로 TMP_Text 데이타타입의 변수를 선언

    //public int a;  //a라는 이름으로 정수형 변수를 선언 (접근권한 모두에게)

    public Transform rigidbodyBulletG;
    public Transform rigidbodySpawnPointG;
    int powerBulletG = 500;

    // 여기까지 변수 선언 (이후는 함수) 
    //---------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //gunSound = GetComponent<AudioSource>();  // 단수일떼 (1개만 쓸때)
        gunSound = GetComponents<AudioSource>();   // 배열로 쓸때

        rgBody = GetComponent<Rigidbody>();

        // 포탄 발사시에 보여지는 효과이미지를 (처음 시작할 때) 비활성화 시킴
        fire = GameObject.Find("FireEffect");
        fire.SetActive(false);
        //hp = 10;
        countText.text = "HP : " + hp.ToString();
        //hpText.text = "HP : " + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 발사(Fire) 처리부분 --------------

        // 단발 사격
        if (Input.GetButtonDown("Fire1")) { SingleShot(); }
        //if (Input.GetButton("Fire2")) { AutoFire(); }

        // 연속 사격

        // 연속 사격에서 일정한 딜레이(지연)을 주기 위해
        //if (Input.GetButton("Fire2") && canFire) { StartCoroutine(AutoFire()); }

        // *** 연속발사 사운드효과를 (버튼을 놓으면) 사운드가 중지하도록  (교재 159페이지 참조)
        //if (!Input.GetButton("Fire2")) { gunSound[1].Stop(); }

        // 오른쪽 마우스 클릭을 (키보드) 왼쪽 쉬프트로 변경
        if (Input.GetKey(KeyCode.LeftShift) && canFire) { StartCoroutine(AutoFire()); }
        if (!Input.GetKey(KeyCode.LeftShift)) { gunSound[1].Stop(); }

        // (리지드바디가 있는 포탄) 발사
        //if (Input.GetKey(KeyCode.A)) { SingleShotG(); }
        if (Input.GetButtonDown("Jump")) { SingleShotG(); }
    }

    private void FixedUpdate()
    {
        // 이동 & 회전하는 부분 --------------
        // 현재 프레임에서 이동할 거리 계산
        float moveAmount = moveSpeed * Time.deltaTime; // 객체 이동 거리
        float rotateAmount = rotateSpeed * Time.deltaTime; // 객체 회전 거리(?)

        // Input Manager의 정의된 코드값을 받아옴
        // 상하(Vertical) 좌우(Horizontal) 값을 화살표키 (또는 WASD)로 받음
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        //
        // *** Left Shift 누른 상태에서 이동, 회전 빨라지게 ...
        //

        // 움직이는 x-z방향을 확인하기 위해
        // 3차원 공간에서 X축(좌우), Y축(위아래), Z축(앞뒤)
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // 위아래화살표로 객체 이동
        // 객체의 전방으로 이동(전진)
        transform.Translate(Vector3.forward * moveAmount * vert);
        // 좌우화살표로 객체 회전
        transform.Rotate(Vector3.up * rotateAmount * hori);

        // 이놈하고 위의 놈하고 차이를 체크해봅시다
        //rgBody.MovePosition(rgBody.position + transform.forward * moveAmount);
        //rgBody.MoveRotation(rgBody.rotation * Quaternion.Euler(Vector3.up * rotateAmount));

    }

    void SingleShot()
    {
        Debug.Log("SingleShot() function is called ..");
        // 포탄 생성
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        
        // 이팩트
        fire.SetActive(true);

        // 사운드
        //gunSound.Play();   // AudioSource를 하나만 쓸때
        gunSound[0].Play();   // 배열로 쓸때
    }

    // 연속 발사 Coroutine
    //void AutoFire()
    IEnumerator AutoFire()
    {
        /*
         *  발사간격을 시간으로 설정 (교재 153페이지 참조)
        delayTime += Time.deltaTime;
        if (delayTime >= 0.1f) { 
            Debug.Log("AutoFire() function is called ..");
            Instantiate(bullet, spPoint.position, spPoint.rotation);
            delayTime = 0;
        }
        */

        // Coroutine로 활용하여 발사 간격을 조정하도록 수정 (교재 154페이지 참조)
        // 포탄 생성
        Instantiate(bullet, spPoint.position, spPoint.rotation);

        // *** 알아서 (찾아서) 연속발사 시의 사운드효과를 반영하세요
        // 사운드
        gunSound[1].Play();

        // *** 찾아서 연속발사 시의 효과이미지를 반영하세요
        fire.SetActive(true);

        canFire = false;

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("탱크 -- OnTriggerEnter() 함수 발생 " + other.tag);

        if (other.tag == "Pickupitem20")  // 탱크가 아이템과 부딪쳤을 때
        {
            // 무슨 작업?
            // 점수 업 (score +20)
            // GameManager 오브젝트를 검색.GetComponent<GameManager>().score
            // 아이템 오브젝트 화면에서 제거
            other.gameObject.SetActive(false);
            // 사운드 (음향효과)
            // 파티클 (시각효과)
        }

        if (other.tag == "Bullet") // 탱크가 포탄을 맞았을 때
        { 
            hp--;
            countText.text = "HP : " + hp.ToString();
            //hpText.text = "HP : " + hp.ToString();
            if (hp < 0)
            {
                Debug.Log("You died, Game Over..");
                // 게임오버 씬 호출
                StartCoroutine(DestroySelf());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() 함수 발생 " + collision.gameObject.tag);

        // PickupItem 충돌발생 ...
        // (1) score +10, +20
        // (2) item 오브젝트 제거 
        // (3) 파티클 추가
        // (4) 사운드 플레이
    }

    IEnumerator DestroySelf()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        // 게임종료 사운드
        yield return new WaitForSeconds(2f);

        // 씬 re-load (현재 실행중인 씬을 다시 불러옴)
        // 씬 전환하기 위해서는 프로젝트 설정에서 씬을 등록시켜줘야 함
        //SceneManager.LoadScene("WorkingScene");  // 직업 문자열로 씬 이름을 줄수있고
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 리지드바디가 있는 포탄 발사
    void SingleShotG()
    {
        // 포탄 생성
        Transform initBulletG = Instantiate(
            rigidbodyBulletG, rigidbodySpawnPointG.position, rigidbodySpawnPointG.rotation) as Transform;
        initBulletG.GetComponent<Rigidbody>().AddForce(rigidbodySpawnPointG.forward * powerBulletG);

        // 사운드(음향효과)
        // 파티클(시각효과)
    }
}
