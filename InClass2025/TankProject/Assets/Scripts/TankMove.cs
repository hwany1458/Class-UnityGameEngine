using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

// 교재에서는 CarMove 스크립트
public class TankMove : MonoBehaviour
{
    //--- Variables
    private float moveSpeed = 10.0f;    // 이동속도를 지정하는 변수선언
    private float rotateSpeed = 60.0f;  // 회전속도를 지정하는 변수선언

    public Transform bullet;  // 미사일 변수
    private Transform spPoint; // 스판포인트 변수

    // 하나쓸때, 변수로
    //AudioSource gunSound;  // 따콩소리(음향효과) 단발소리 변수선언
    // 2개 이상일때, 배열로
    AudioSource[] gunSound;  // 소리를 가져온 배열변수 선언

    float delayTime = 0.1f;  // 발사지연시간
    bool canFire = true;   // 총알발사 가능여부를 체크하는 변수선언

    //--- Methods
    // Start is called before the first frame update
    void Start()
    {
        // 변수선언한 후, 초기값 할당
        // spPoint = GameObject.Find()...
        // 이방법 대신에, 인스팩터에서 드래그해서 값을 할당하였음

        // 바꾸는 방법으로 ...
        // private 선언을 바꾸고, 값할당을 Start()함수에서 객체 찾기로 할당
        spPoint = GameObject.Find("SpawnPoint").transform;
        // 컴포넌트가 하나일떄
        //gunSound = GetComponent<AudioSource>();
        // 2개 이상의 컴포넌트를 가져오려면
        gunSound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 프레임에서 이동할 거리 산출하는 변수
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // 키보드 입력을 테스트 (PPT 슬라이드 ?쪽)
        /* 여기서는 테스트만 해보고 .. 동작여부를 확인한 다음, 주석처리
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump, Space Bar is pressed..");
        }
        */

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // 탱크 오브젝트를 전방(앞, forward)으로 이동
        transform.Translate(Vector3.forward * amount * vert);
        // 탱크 오브젝트를 전방(앞, forward)으로 이동 (상대좌표) -- 전방좌우 이동하는 것만 확인하고 주석처리
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // 좌우회전
        transform.Rotate(Vector3.up * amountRotate * hori);

        // 숙제
        // (1) 현재는 (전후 이동을 하지 않으면서) 좌우 회전도 가능하다.
        // 전후 이동하면서만 좌우 회전이 가능하도록 스크립트를 수정하세요

        // (2) 앞뒤로 이동하면서 4개의 바퀴 객체가 함께 돌아가도록 스크립트를 수정하세요

        // (3) (이동하면서) 회전할 경우,
        // 2개 앞 바퀴 객체를 함께 돌아가도록 스크립트를 수정하세요

        // Fire1(Left Ctrl key)가 눌렸는지 안눌렸는지
        if (Input.GetButtonDown("Fire1"))
        {
            // 미사일 객체를 씬에 생성, 발사(날라가게)
            // 미사일이 날아가는 것은 Bullet.cs 에서 처리
            // 단발사격
            SingleShut();
        }
        
        // Fire2(Left Alt key)가 눌렸고, 발사가능할 떄(canFire) 연발사격
        if (Input.GetButton("Fire2") && canFire)
        {
            // 연발사격 (그냥 실행)
            //AutoFire();
            // 발사 지연을 주기 위해, 코루틴으로 호출
            StartCoroutine(AutoFire2());
        }

        // 연속발사 버튼을 때는 순간, (사운드 효과를 제거하기 위해) 사운드 멈춤
        if (!Input.GetButton("Fire2"))
        {
            gunSound[1].Stop();
        }

    }

    //-- 사용자 정의 함수
    // 미사일 발사 함수 (단발)
    void SingleShut()
    {
        // 미사일 객체를 씬에 생성, 발사(날라가게)
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        // 시각효과, 음향효과(따콩)
        // 사운드가 하나일떄 (변수로 사용할때)
        //gunSound.Play();
        // 지금은 2개 이상 오디오사운드가 연결되서, 배열을 사용
        gunSound[0].Play();
    }

    // 연발사격 (일반함수)
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
    // 연발사격 (코루팀함수)
    IEnumerator AutoFire2()
    {
        Instantiate(bullet, spPoint.position, spPoint.rotation);
        gunSound[1].Play();
        canFire = false;  // 총알 발사, canFIre를 거짓으로 바꿔서 총알 발사를 막음

        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }



    // 숙제 (159페이지, 4.4.3 자동차엔진 사운드처리 - 2슬라이드)
    // 4.7 총구발사 화염 4슬라이드


}
