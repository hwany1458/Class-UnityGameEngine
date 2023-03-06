using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed);
    }

    // 충돌 판정과 처리
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger..() 이벤트 발생 " + other.name + " " + other.tag);
        if (other.tag == "Target")
        {
            // 충돌한 오브젝트가 대상물(Target) 이면 (명중하였으므로) 해당 오브젝트에 변화를 가함
            // 총알 스크립트에서 대상물 파괴를 하지 않고, 대상물 스크립트에서 파괴되도록 수정
            // 대상 객체에게 메시지 전달 방식으로 처리
            //Destroy(other.gameObject);
            other.SendMessage("DestroySelf", transform.position);
        }
        // 충돌 대상이 enemy일 경우,
        // 벙커는 3개 부분으로 되어 있지만,
        // 총알이 어느 부분이든 명중하면 파괴됨으로 간주하여 enemy의 최상위 객체에서 (스크립트로) 제거함
        if (other.tag == "Enemy")
        {
            other.transform.root.SendMessage("DestroySelf", transform.position);
        }

        // 충돌 발생하면, 총알도 객체파괴
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollision..() 이벤트 발생 " + collision.gameObject.name + " " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
