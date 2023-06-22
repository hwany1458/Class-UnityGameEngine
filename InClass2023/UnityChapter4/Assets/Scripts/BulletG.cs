using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletG : MonoBehaviour
{
    float bulletSpeed = 30f;  // 포탄 날라가는 속도

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 충돌 판정 및 처리 -- collision (isTrigger is unchecked)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() " + collision.gameObject.name + "--" + collision.gameObject.tag);
    }

    // 충돌 판정 및 처리 -- trigger (isTrigger is checked)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter() " + other.name + "**" + other.tag);
        
        // 포탄(총알)과 충돌이 일어난 대상 객체 체크
        if (other.tag == "Target10")
        {
            // 처리할 내용들은 (예를들어)
            // (1) 점수 +10
            // (2) 타켓 제거 시점에서의 파티클
            // (3) 타켓 제거 음향효과
            // (4) 타켓 제거
            //Destroy(other.gameObject);
            
            // 포탄(총알)에서는 충돌만 판별하고 충돌 처리 부분은 대상 객체에서 처리하도록 수정
            other.SendMessage("DestroySelf", transform.position);
            //other.GetComponent<TargetControl>().DestroySelf(transform.position);
        } 
        
        // (날라가는 포탄이) 적군과 충돌이 일어난 경우
        if (other.tag == "Enemy")
        {
            other.transform.root.GetComponent<TargetControl>().DestroySelf(transform.position);
        }

        // 충돌 발생 이후에, 포탄(총알) 제거
        Destroy(gameObject);
    }
}
