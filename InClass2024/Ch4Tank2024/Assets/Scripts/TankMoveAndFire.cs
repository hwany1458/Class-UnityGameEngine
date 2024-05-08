using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndFire : MonoBehaviour
{
    // --- Variables
    // ----- 탱크 이동 관련 변수
    float moveSpeed = 10.0f;  // 이동속도
    float rotateSpeed = 60.0f;  // 회전속도
    const float sprintMode = 2.0f;  // 스프린트 시에 2배 빠르게

    // ----- 탱크 미사일 발사 관련 변수
    // (1)변수선언
    public Transform spPoint;   // 포탄(미사일) 생성 위치로 지정되는 스판포인트
    public Transform missleObject;  // 포탄 프리팹 =생성 객체변수 (GameObject, Transform)

    // Start is called before the first frame update
    void Start()
    {
        // (인스팩터에서) 안 끌어넣었을 경우 .. 이런형식으로 받아낼수도 있음
        // (2)값 할당
        //spPoint = GameObject.Find("SpawnPoiny").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //----------- 탱크 이동, 회전 처리 부분
        // FPS를 고려하여 델타타임을 곱함
        float moveAmount = moveSpeed * Time.deltaTime;  // 이동거리(현재 프레임에서 이동할 거리)
        float rotateAmount = rotateSpeed * Time.deltaTime;  // 회전크기

        float vert = Input.GetAxis("Vertical");  // 키보드로부터 입력 상하 화살표(또는 ws)
        float hori = Input.GetAxis("Horizontal");  // 키보드로부터 입력 좌우 화살표 (또는 ad)
        //Debug.Log(vert.ToString());

        // GetKey() 테스트
        // 쉬프트 키를 누른 상태에서 이동 회전을 할 경우, 보다 빨라지게
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("Left Shift key is pressed ...");
            moveAmount *= sprintMode;
            rotateAmount *= sprintMode;
        }

        // 게임오브젝트를 전방으로 이동
        // Translate() : 현재 위치에서 지정한 방향으로 지정한 거리만큼 객체를 이동시키는 함수
        //transform.Translate(Vector3.forward * moveAmount);

        // 키보드로부터 (화살표키를) 입력받아 객체를 이동 확인
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // 앞뒤 이동
        transform.Translate(Vector3.forward * moveAmount * vert);
        // 좌우로 회전
        // 제자리 회전을 막고 싶으면 ... how?
        // 앞뒤이동이 없으면서 회전만 할경우 (vert=0일 경우) 회전하지 않도록
        if (vert != 0)
        {
            transform.Rotate(Vector3.up * rotateAmount * hori);
        }

        // ---- 포탄 발사 처리 부분
        // 키보드 입력 받음
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Left Control Key is pressed..");
            SingleShot();
        }

    }

    // --- User defined Methods

    private void SingleShot()
    {
        // LeftCtrl (or Mouse 0) 클릭될 때마다 함수(메소드)가 호출됨
        Debug.Log("SingleShot() method is called ..");
        // New -- 객체생성 : Instantiate()
        Instantiate(missleObject, spPoint.position, spPoint.rotation);
    }
}
