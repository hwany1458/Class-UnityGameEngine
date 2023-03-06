using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("카메라 위치, 각도, FOV--------------")]
    [SerializeField] Vector3 position = new Vector3(0, 3.6f, -7.8f);    // 카메라 초기 위치
    [SerializeField] Vector3 rotation = new Vector3(14, 0, 0);          // 카메라의 초기 회전각
    [SerializeField] [Range(10, 100)] float fov = 30f;                 // 카메라의 Field of View

    [Header("카메라 이동 및 회전 속도 --------------")]
    [SerializeField] float moveSpeed = 10f;  // 카메라 이동 속도
    [SerializeField] float turnSpeed = 10f;  // 카메라 회전 속도

    Transform target;  // 추적대상
    Transform cam;     // 카메라
    Transform pivot;   // 카메라 이동 및 회전 축
    Transform pivotRot; // 마우스로 회전할 Pivot

    // Start is called before the first frame update
    void Start()
    {
        // target 설정
        target = GameObject.Find("Tank").transform; // Target 설정 (카메라가 추적할 목표를 설정)
        if (target != null)
        { 
            Debug.Log("Target Object is found --" + target.name);
            InitCamera();  // 카메라 초기화
        }
        else
        {
            Debug.LogWarning("Target Object is NOT found ..");
        }
    }

    // Update is called once per frame
    void Update() 
    {
        // 마우스휠을 통해 줌인/줌아웃
        // zoomin (wheel up+) zoomout (wheel down-)
        float zoom = Input.GetAxis("Mouse ScrollWheel") * 20;
        fov = Mathf.Clamp(fov - zoom, 10, 100);
        cam.GetComponent<Camera>().fieldOfView = fov;

        // 오른쪽 마우스를 클릭하고 돌리면 화면 회전
        // 오른쪽 버튼을 누르고 있지 않으면 리턴
        if (!Input.GetMouseButton(1)) return;

        // 마우스 이동 방향
        float x = Input.GetAxis("Mouse Y") * 2;   // 상하 이동은 x축 회전
        float y = Input.GetAxis("Mouse X") * 2;   // 좌우이동은 y축 회전

        // 회전할 각도 계산
        Vector3 ang = pivotRot.localEulerAngles + new Vector3(x, y, 0);

        // x축의 회전각 변환 (0~360 --> -180~+180)  
        if (ang.x > 180)
        {
            ang.x -= 360;
        }

        // x축 회전 범위 제한(지면 아래와 수직을 벗어나지 않도록)
        ang.x = Mathf.Clamp(ang.x, -24, 80);

        pivotRot.localEulerAngles = ang;
        // pivotRot.localRotation = Quaternion.Euler(ang);
    }

    //void LateUpdate()
    void FixedUpdate()
    {
        // 목표값
        Vector3 pos = target.position;
        Quaternion rot = target.rotation;

        // 이동
        pivot.position = Vector3.Lerp(pivot.position, pos, moveSpeed * Time.deltaTime);

        // 회전
        pivot.rotation = Quaternion.Lerp(pivot.rotation, rot, turnSpeed * Time.deltaTime);
    }


    void InitCamera()
    {
        // 카메라 설정
        cam = Camera.main.transform;   // 메인카메라 정보를 읽음
        cam.GetComponent<Camera>().fieldOfView = fov;

        // Pivot 만들기
        pivot = new GameObject("Pivot").transform;  // Pivot라는 빈 오브젝트를 생성
        pivot.position = target.position;

        // 마우스 회전용 Pivot 만들기
        pivotRot = new GameObject("PivotRot").transform;
        pivotRot.position = target.position;
        pivotRot.parent = pivot;

        // 카메라를 피벗의 child로 설정
        // remarked by hwany - 마우스 피벗을 만들기 위해, camera의 부모를 재설정
        //cam.parent = pivot;
        cam.parent = pivotRot;
        cam.localPosition = position;
        cam.localEulerAngles = rotation;
        cam.localRotation = Quaternion.Euler(rotation); 
    }
}
