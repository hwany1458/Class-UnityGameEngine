using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    //--- variables ---
    float speed = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 2f); // 2초 후에 객체 Destroy
    }

    // Update is called once per frame
    void Update()
    {
        float amount = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);

    }

    // 충돌 판정과 처리
    // Collider가 Trigger로 설정된 경우 충돌 판정이 발생하면 호출
    void OnTriggerEnter(Collider other)  
    {
        Debug.Log("(OnTriggerEnter)Bullet hit: " + other.gameObject.name);

        // Target 태그가 붙은 오브젝트와 충돌했을 때
        if (other.tag == "Target") {
            //Destroy(other.gameObject);
            // 여기서 직접 오브젝트 파괴 대신, 메시지를 보내서 TargetDestroy 스크립트의 DestroySelf() 메서드를 호출하도록 함
            other.SendMessage("DestroySelf", transform.position);
        }
        // Enemy 태그가 붙은 오브젝트와 충돌했을 때
        else if (other.tag == "Enemy")
        {
            other.transform.root.SendMessage("DestroySelf", transform.position);
        } 
        else
        {

        }

        Destroy(gameObject);  // 포탄은 충돌 후 즉시 파괴
    }

    // Collider가 Trigger로 설정되지 않은 경우 충돌 판정이 발생하면 호출
    void OnCollisionEnter(Collision collision)  
    {
        Debug.Log("(OnCollisionEnter)Bullet collided with: " + collision.gameObject.name);
    }
}
