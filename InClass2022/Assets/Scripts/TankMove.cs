using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    float speed = 5.0f;     // 이동속도
    //Rigidbody rigidbody;
    float vArrow;
    float vert, hori;
    float speedR = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 프레임에서 이동할 거리
        float moveSpeed = speed * Time.deltaTime;
        float rotateSpeed = speedR * Time.deltaTime;

        // ------------------------ 키 입력 테스트
        if (Input.GetButton("Jump")) { Debug.Log("Jump, Space bar is pressed .."); }
        vArrow = Input.GetAxis("Vertical");
        if (vArrow != 0.0) { Debug.Log("Vertical : " + vArrow); }
        if (Input.GetKey(KeyCode.Space)) { Debug.Log("GetKey : Space bar is pressed .."); }

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // 상하좌우 이동
        //transform.Translate(new Vector3(hori, 0, vert) * moveSpeed);

        // 상하이동-전진, 좌우회전
        transform.Translate(Vector3.forward * moveSpeed * vert);
        transform.Rotate(Vector3.up * rotateSpeed * hori);

        // ------------------------ 오브젝트 이동
        // Translate() 함수 이용
        //transform.Translate(Vector3.forward * moveSpeed, Space.Self);
        //transform.Translate(new Vector3(0,0,1) * moveSpeed);

        // 오브젝트의 위치 값 이용
        //transform.position += new Vector3(0, 0, 1) * moveSpeed;

        // 리지드바디 이용 (속도 또는 힘)
        // RigidBody를 설정한 후, 속도값을 설정
        //rigidbody.velocity = new Vector3(0, 0, 1);
        // RigidBody에 Force를 적용하여 움직임
        //rigidbody.AddForce(new Vector3(0, 0, 1));

    }
}
