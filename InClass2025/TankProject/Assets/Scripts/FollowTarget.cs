using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    //--- variables 변수선언
    [Header("카메라 위치,각도,FOV")]
    [SerializeField] Vector3 position = new Vector3 (0, 3.6f, -7.8f); // 카메라 초기 위치
    [SerializeField] Vector3 rotation = new Vector3(14, 0, 0);  // 카메라 초기 회전각
    [SerializeField] [Range(10, 100)] float fov = 30.0f;  // 카메라 Field of VIew

    [Header("카메라 이동, 회전속도")]
    [SerializeField] float moveSpeed = 10.0f; // 카메라 이동속도
    [SerializeField] float turnSpeed = 10.0f; // 카메라 회전속도

    Transform target;  // 추적대상 (탱크)
    Transform cam;  // 카메라
    Transform pivot; // 카메라 이동/회전 포인트

    // 숙제 (1)
    // GameObject로 선언하는 것과 Transform으로 선언한 것의 차이점은?

    Transform pivotRot;  // 마우스로 회전할 Pivot 선언

    // ---- Methods
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Tank").transform;  //Target 설정 (추적할 목표를 카메라로 설정)
        InitCamera();  // 카메라 초기화
    }

    // Update is called once per frame
    void Update()
    {
        // 줌인(wheel up+), 줌아웃(wheel down-)
        float zoom = Input.GetAxis("Mouse ScrollWheel") * 20;
        fov = Mathf.Clamp(fov - zoom, 10, 100);
        cam.GetComponent<Camera>().fieldOfView = fov;

        // 오른쪽 마우스를 누르지 않으면, (아무 동작하지 않게) 리턴
        if (!Input.GetMouseButton(1)) return;

        // 마우스 이동 방향
        float x = Input.GetAxis("Mouse X") * 2;  // 상하 이동은 x축 회전으로
        float y = Input.GetAxis("Mouse Y") * 2;  // 좌우 이동은 y축 회전으로

        // 회전할 각도 계산
        Vector3 ang = pivotRot.localEulerAngles + new Vector3(x, y, 0);

        // x축의 회전각 변환 (0~360 --> -180~180)
        if (ang.x > 180) { ang.x -= 360; }

        //x축 회전 범위 제한 (지면 아래와 수직을 벗어나지 않도록)
        ang.x = Mathf.Clamp(ang.x, -24, 80);

        pivotRot.localEulerAngles = ang;
    }

    //private void LateUpdate()
    private void FixedUpdate()
    {
        // 타켓(탱크)의 위치,회전방향 : 목적값
        Vector3 pos = target.position;  // 카메라 위치
        Quaternion rot = target.rotation; // 카메라 회전

        // 피벗 위치, 회전방향을 카메라의 위치, 회전방향으로 변경
        pivot.position = Vector3.Lerp(pivot.position, pos, moveSpeed*Time.deltaTime);  // 이동
        pivot.rotation = Quaternion.Lerp(pivot.rotation, rot, turnSpeed*Time.deltaTime);  // 회전
    }


    //---- 사용자-정의 함수
    void InitCamera()  // 카메라 초기화 작업
    {
        // 카메라 설정
        cam = Camera.main.transform;   // 메인카메라 정보를 읽음
        cam.GetComponent<Camera>().fieldOfView = fov;

        // 피벗 만들기
        pivot = new GameObject("Pivot").transform;  // Pivot이라는 빈 객체를 생성
        pivot.position = target.position;  // 카메라위치를 피봇위치에 넣어줌

        // 마우스 회전용 피벗만들기
        pivotRot = new GameObject("PivotRot").transform;
        pivotRot.position = target.position;
        pivotRot.parent = pivot;

        // 카메라를 피벗의 차일드(자식)으로 설정
        //cam.parent = pivot;
        // 메인카메라의 부모를 이동/회전 피벗에서 카메라회전 피벗으로 변경
        cam.parent = pivotRot;

        cam.localPosition = position;
        cam.localEulerAngles = rotation;
        cam.localRotation = Quaternion.Euler(rotation);
    }
}
