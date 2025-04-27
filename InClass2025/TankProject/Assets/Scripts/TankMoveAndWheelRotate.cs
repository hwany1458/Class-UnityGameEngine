using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndWheelRotate : MonoBehaviour
{
    //--- Variables
    private float moveSpeed = 10.0f;    // 이동속도를 지정하는 변수선언
    private float rotateSpeed = 60.0f;  // 회전속도를 지정하는 변수선언

    // 바퀴 객체를 받아낼 변수선언
    private GameObject frontLeftWheel;  // 앞 왼쪽 바퀴
    private GameObject frontRightWheel; // 앞 오른쪽 바퀴
    private GameObject backLeftWheel;   // 뒤 왼쪽 바퀴
    private GameObject backRightWheel;  // 뒤 오른쪽 바퀴
    //private float rotateWheelSpeed = 45.0f;

    // 탱크 회전 시, 앞 2개 바퀴의 회전 각도를 지정하는 변수선언
    private float frontWheelMaxAngle = 30.0f;  // 앞 바퀴 회전 최대 각도
    private float currentWheelAngle = 0.0f;    // 현재 앞 바퀴의 누적 회전 각도

    //--- Methods
    // Start is called before the first frame update
    void Start()
    {
        frontLeftWheel = GameObject.Find("TankFree_Wheel_f_left");
        frontRightWheel = GameObject.Find("TankFree_Wheel_f_right");
        backLeftWheel = GameObject.Find("TankFree_Wheel_b_left");
        backRightWheel = GameObject.Find("TankFree_Wheel_b_right");

        if (frontLeftWheel == null || frontRightWheel == null || backLeftWheel == null || backRightWheel == null)
        {
            Debug.LogWarning("[경고] 바퀴를 찾지 못했습니다.");
        }
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

        // 숙제
        // (1) 현재는 (전후 이동을 하지 않으면서) 좌우 회전도 가능하다.
        // 전후 이동하면서만 좌우 회전이 가능하도록 스크립트를 수정하세요
        // (2) 앞뒤로 이동하면서 4개의 바퀴 객체가 함께 돌아가도록 스크립트를 수정하세요
        // (3) (이동하면서) 회전할 경우,
        // 2개 앞 바퀴 객체를 함께 돌아가도록 스크립트를 수정하세요


        // (Sol 1) 앞뒤 이동이 없을 경우에는 회전도 안하도록
        // (=) 앞뒤 이동이 있는 경우에만 회전하도록
        if (vert != 0)  // 화살표 전후 키로 입력받아, 탱크가 이동하게 되면
        {
            // (탱크) 좌우회전 
            transform.Rotate(Vector3.up * amountRotate * hori);


            // (Sol 2) 바퀴 4개를 찾아서, (바퀴가 굴러가는 방향으로) 회전을 시킨다
            // 바퀴 회전 구현
            if (frontLeftWheel != null && frontRightWheel != null && backLeftWheel != null && backRightWheel != null)
            {
                // 바퀴가 회전할 각도 설정 (이동방향 고려)
                float wheelRotateAmount = vert * 360.0f * Time.deltaTime;

                frontLeftWheel.transform.Rotate(Vector3.right * wheelRotateAmount, Space.Self);
                backLeftWheel.transform.Rotate(Vector3.right * wheelRotateAmount, Space.Self);

                frontRightWheel.transform.Rotate(Vector3.right * wheelRotateAmount, Space.Self);
                backRightWheel.transform.Rotate(Vector3.right * wheelRotateAmount, Space.Self);
            }
        }

        // (Sol 3) 
        // 
        if (frontLeftWheel != null && frontRightWheel != null && hori != 0 && vert != 0)
        {
            float rotationStep = hori * rotateSpeed * Time.deltaTime;
            float newWheelAngle = currentWheelAngle + rotationStep;

            // 회전 범위 제한
            newWheelAngle = Mathf.Clamp(newWheelAngle, -frontWheelMaxAngle, frontWheelMaxAngle);
            float deltaRotation = newWheelAngle - currentWheelAngle;

            // 실제 바퀴 회전
            frontLeftWheel.transform.Rotate(Vector3.up * deltaRotation, Space.Self);
            frontRightWheel.transform.Rotate(Vector3.up * deltaRotation, Space.Self);

            // 각도 갱신
            currentWheelAngle = newWheelAngle;
        }
        else if (hori == 0)
        {
            // 좌우 입력이 없을 때 바퀴를 원위치로 되돌리기 (자연스러운 복원)
            float returnSpeed = 60.0f * Time.deltaTime;
            float deltaRotation = Mathf.MoveTowards(currentWheelAngle, 0, returnSpeed) - currentWheelAngle;

            frontLeftWheel.transform.Rotate(Vector3.up * deltaRotation, Space.Self);
            frontRightWheel.transform.Rotate(Vector3.up * deltaRotation, Space.Self);
            currentWheelAngle += deltaRotation;
        }

    }
}
