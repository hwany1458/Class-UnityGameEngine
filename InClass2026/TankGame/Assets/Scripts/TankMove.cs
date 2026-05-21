using UnityEngine;

public class TankMove : MonoBehaviour
{
    //--- variables ---
    float moveSpeed = 10f;  // 이동속도
    float rotateSpeed = 60f;   // 회전속도(초속 60)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동방법(1)
        //transform의 Position에 직접 접근하여 (값을) 설정해주는 방법
        //transform.position += new Vector3(0, 0, 1);

        // 이동방법(2)
        //transform의 Translate() 함수를 이용하는 방법
        // 현재 프레임에서 이동할 거리
        float amount = moveSpeed * Time.deltaTime;
        float amountRotate = rotateSpeed * Time.deltaTime;

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 오브젝트의 전방으로 이동
        //transform.Translate(Vector3.forward * amount);
        //transform.Translate(new Vector3(horz, 0, vert) * amount);   // 전방좌우로 이동

        // 오브젝트의 전방으로 이동 (전진)
        transform.Translate(Vector3.forward * amount * vert);
        // 좌우회전
        transform.Rotate(Vector3.up * amountRotate * horz);

    }
}
