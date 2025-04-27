using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 총알 프리팹이 씬에 나타나는 것은 탱크스크립트에서 키보드 입력을 받을 때 생성
// 총알스크립트에서는 생성된 총알 프리팹이 날라가도록 동작시킴 -- Update() 함수에서

public class Bullet : MonoBehaviour
{
    float speed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 객체가 생성된 다음, 3초 후에 (자동으로) 객체가 파괴되도록
        Destroy(gameObject, 3.0f);
    }


    // Update is called once per frame
    void Update()
    {
        float amount = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);
    }

    // Is Trigger가 ON 일때 발생
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger 발생 " + other.name);
    }

    // Is Trigger가 OFF 일때 발생
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision 발생 " + collision.gameObject.name);
    }

}
