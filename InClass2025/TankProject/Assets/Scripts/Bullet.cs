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
            // 시각효과 (파티클) --- 추가됨
            // 음향효과
            // 20점+
            // 여기서 파괴되지 않고, 타켓 객체의 스크립트에서 파괴되는 걸로 변경
            // Destroy(other.gameObject); // 맞춘 (대상) 객체를 제거
            // TargetDestroy.cs 스크립트의 DestroySleft()함수를 호출해서 (그쪽에서) 타켓 객체를 제거
            other.SendMessage("DestroySelf", transform.position);
        }
        
        
        Destroy(gameObject);  /// 총알제거
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision event is occurred.." + collision.gameObject.name);
    }
}
