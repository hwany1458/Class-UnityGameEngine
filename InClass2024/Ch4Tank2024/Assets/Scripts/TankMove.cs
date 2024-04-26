using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // --- Variables
    public float moveSpeed = 10.0f;  // 이동속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 프레임에서 이동할 거리
        float moveAmount = moveSpeed * Time.deltaTime;

        // 게임오브젝트를 전방으로 이동
        // Translate() : 현재 위치에서 지정한 방향으로 지정한 거리만큼 객체를 이동시키는 함수
        transform.Translate(Vector3.forward * moveAmount);
    }
}
