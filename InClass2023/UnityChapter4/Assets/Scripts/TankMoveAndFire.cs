using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndFire : MonoBehaviour
{
    float moveSpeed = 10f;  // 객체 이동 속도
    float rotateSpeed = 60f;  // 객체 회전 속도

    public Transform spPoint;  // 포탄 생성 위치로 지정되는 스판포인트
    public Transform bullet;   // Bullet(포탄) 프리팹

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 이동 & 회전하는 부분 --------------

        // 현재 프레임에서 이동할 거리 계산
        float moveAmount = moveSpeed * Time.deltaTime;  // 객체 이동 거리
        float rotateAmount = rotateSpeed * Time.deltaTime;  // 객체 회전 거리(?)

        // Input Manager의 정의된 코드값을 받아옴
        // 상하(Vertical) 좌우(Horizontal) 값을 화살표키 (또는 WASD)로 받음
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // 움직이는 x-z방향을 확인하기 위해 테스트
        // 3차원 공간에서 X축(좌우), Y축(위아래), Z축(앞뒤)
        //transform.Translate(new Vector3(hori, 0, vert) * amount);

        // Left Shift 누른 상태에서 이동, 회전 빨라지게 ... (각자 붙여보세요!)

        // 위아래화살표로 객체 이동
        // 객체의 전방으로 이동(전진)
        transform.Translate(Vector3.forward * moveAmount * vert);
        // 좌우화살표로 객체 회전
        transform.Rotate(Vector3.up * rotateAmount * hori);


        // 포탄 발사(Fire) 처리부분 --------------
        // 단발 사격 (나중에 연속 발사를 처리할 예정)
        if (Input.GetButtonDown("Fire1")) { SingleShot(); }
    }

    void SingleShot()
    {
        //Debug.Log("SingleShot() function is called ..");

        // 포탄 생성
        // (여기서는 현재 포탄 생성만 한다)
        // 포탄이 날라가는 처리는 포탄(Bullet) 객체에 연결된 Bullet 스크립트에서 처리
        Instantiate(bullet, spPoint.position, spPoint.rotation);

        // 이팩트
        // 사운드
    }
}
