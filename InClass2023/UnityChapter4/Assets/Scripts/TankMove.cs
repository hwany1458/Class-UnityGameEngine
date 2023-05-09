using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // 본 스크립트는 탱크 객체의 이동과 회전을 처리하는 스크립트
    // 이동과 회전 처리, 포탄 발사 처리를 하나의 스크립트에서 처리하기 위해
    // TankMoveAndFire 스크립트를 만들었고
    // 본 스크립트는 더이상 사용하지 않을 예정임

    float moveSpeed = 10f;
    float rotateSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        float rotateAmount = rotateSpeed * Time.deltaTime;
        
        // Input Manager의 정의된 코드값을 받아옴
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // 움직이는 x-z방향을 확인하기 위해
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // 위아래화살표로 객체 이동
        transform.Translate(Vector3.forward * moveAmount * vert);
        // 좌우화살표로 객체 회전
        transform.Rotate(Vector3.up * rotateAmount * hori);

        // 
    }
}
