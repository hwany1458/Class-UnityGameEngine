using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 30f;  // 포탄 날라가는 속도

    // Start is called before the first frame update
    void Start()
    {
        // 포탄(Bullet) 객체가 생성되면서 스크립트가 실행되고
        // 객체 생성된 다음, 2초 후에 객체를 화면(씬)에서 제거
        // 객체 제거 이유는 강의자료 73슬라이드 참조
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float bulletAmount = bulletSpeed * Time.deltaTime; // 포탄 날라가는 거리

        // 포탄(Bullet)을 전방으로 이동 (=날라가도록)
        transform.Translate(Vector3.forward * bulletAmount);
    }
}
