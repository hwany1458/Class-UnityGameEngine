using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunch : MonoBehaviour
{
    // -- Variables
    float moveSpeed = 30.0f;  // 포탄 (날라가는) 속도

    // Start is called before the first frame update
    void Start()
    {
        // 객체 생성 후, Start() 함수가 한번 실행되는데,
        // 객체(미사일) 생성하고 3초 후에 자동으로 객체가 제거(파괴)되도록
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 객체(미사일)이 날라가도록
        // Translate() 함수를 써서, 객체를 이동시킴
        float moveAmount = moveSpeed * Time.deltaTime;  // 포탄 (날라가는) 거리
        
        // 포탄(Missile)을 전방으로 이동시킴 (날라가도록)
        transform.Translate(Vector3.forward * moveAmount);
    }
}
