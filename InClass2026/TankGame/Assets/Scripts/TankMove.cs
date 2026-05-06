using System.Collections;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // ----- variables
    private float moveSpeed = 10f;  // 이동속도
    private float rotateSpeed = 60f; // 회전속도

    //public Transform spPoint;  // 포탄 생성 위치(스판포인트)
    private Transform spPoint;  // 포탄 생성 위치(스판포인트)

    public Transform missile; // 미사일 객체 

    private bool canFire = true;

    //사운드처리를 위한 변수
    //private AudioSource shotAudio;  // 오디오소스가 하나일 때
    private AudioSource[] shotAudio;   // 여러개일때 배열로 받음

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 값 할당 (2번째 방법)
        // private 접근권한으로, 인스팩터에 안 나타날때
        spPoint = GameObject.Find("SpawnPoint").transform;
        //shotAudio = GetComponent<AudioSource>();  // 하나일때
        shotAudio = GetComponents<AudioSource>();   // 여러개일때 (복수)
    }

    // Update is called once per frame
    void Update()
    {
        // --- 객체 이동
        // 속성(좌표)을 변경하는 방법
        //transform.position += new Vector3(0, 0, 1);

        // 화살표키를 입력 받음
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float amountSpeed = moveSpeed * vert * Time.deltaTime;
        float amountRotate = rotateSpeed * hori * Time.deltaTime;

        // (과제1)
        // 제자리에서 회전만 하는 것을 막으세요
        // [힌트] 이동할 때만 회전하게
        // (과제2)
        // 쉬프트키를 누른 상태에서 이동 회전을 하면, 속도를 더 빠르게
        // 안누르면, 정속 주행

        // 함수(동작 명령)을 사용하는 방법
        // 앞뒤로 이동
        transform.Translate(Vector3.forward * amountSpeed);
        // 앞뒤좌우 이동
        //transform.Translate(new Vector3(hori,0,vert) * amountSpeed);
        transform.Rotate(Vector3.up * amountRotate);

        // 키 눌리면 인식해서 해당 함수 호출
        // (단발 발사) -- Down/Up 1번 발생
        if(Input.GetButtonDown("Fire1"))
        {
            SingleShot();
        }

        /*
        if(Input.GetButton("Fire3"))  // Fire3 키가 눌렸을 때
        {
            AutoShot();
        }
        */

        if (Input.GetButton("Fire3") && canFire) // Fire3키가 눌렸을 때 그리고 발사가능할 때
        {
            StartCoroutine(AutoShot2());   // 코루틴함수 호출
        }
        if (!Input.GetButton("Fire3")) { shotAudio[1].Stop(); }

        // -- 키보드 입력 예
        if (Input.GetButtonDown("Jump")) {Debug.Log("점프할래요");}
    }

    //----- 사용자 정의 함수


    // 단발 발사 기능
    void SingleShot()
    {
        // 미사일 생성
        Instantiate(missile, spPoint.position, spPoint.rotation);
        // 처리해야할 놈들
        // 소리 (음향효과) 처리
        //shotAudio.Play();  // 하나일때
        shotAudio[0].Play();  // 여러개일때

        // 시각적 효과 (불꽃, 연기 ...)
    }

    // 연속 발사 기능
    void AutoShot()
    {
        Debug.Log("연속발사 함수 호출됨");
        Instantiate(missile, spPoint.position, spPoint.rotation);
    }

    IEnumerator AutoShot2()
    {
        Debug.Log("연속발사 함수 호출됨 -- 코루틴사용");
        Instantiate(missile, spPoint.position, spPoint.rotation);  // 발사(미사일 생성)
        canFire = false;  // (너) 발사못해...
        // 사운드 효과
        shotAudio[1].Play();
        // 시각적 효과
        yield return new WaitForSeconds(0.1f);  // 빠져 나감, 0.1초 뒤에 다시 들어옴

        // 0.1초 후에 돌아와서 ...
        canFire = true;  // (너) 발사할수 있어 ..
    }
}
