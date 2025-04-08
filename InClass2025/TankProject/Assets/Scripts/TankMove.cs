using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 교재에서는 CarMove 스크립트
public class TankMove : MonoBehaviour
{
    //--- Variables
    private float moveSpeed = 10.0f;    // 이동속도를 지정하는 변수선언
    private float rotateSpeed = 60.0f;  // 회전속도를 지정하는 변수선언

    //--- Methods
    // Start is called before the first frame update
    void Start()
    {
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

    }
}
