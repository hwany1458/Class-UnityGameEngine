using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 미사일 객체가 생성된 이후, 3초 후에 자동으로 객체가 파괴
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // 미사일(총알) 이동  -- 날라가는 효과
        float amount = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger event is occurred.. " + other.name + " " + other.tag);

        // 충돌이 일어났으니까 .. 총알 객체는 화면에서 제거
        if (other.tag == "ItemGreen")
        {
            // 시각효과 (파티클)
            // 음향효과
            // 20점+
            Destroy(other.gameObject); // 맞춘 (대상) 객체를 제거
        }
        
        
        Destroy(gameObject);  /// 총알제거
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision event is occurred.." + collision.gameObject.name);
    }
}
