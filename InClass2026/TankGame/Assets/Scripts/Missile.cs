using UnityEngine;

public class Missile : MonoBehaviour
{
    // --- variables
    float missileSpeed = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // 미사일(포탄) 생성된 이후, 오브젝트 이동
        float missileAmount = missileSpeed * Time.deltaTime;
        // 게임오브젝트.컴포넌트.프로퍼티
        transform.Translate(Vector3.forward *  missileAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() 메소드 발생 ..");

    }

    // is Trigger checked (ON)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter() 메소드 발생...");
        Debug.Log("충돌 일어나는 놈: " + other.name + " " + other.tag);
        
        // score10 (10점짜리 아이템) 명중
        if(other.tag == "Score10")
        {
            // 아이템 화면에서 제거 (제거? 제거후 다른위치 새로생성??)
            Destroy(other.gameObject);  // 충동대상객체

            // 점수 +10
            // 사운드 (음향효과)
            // 시각적 효과 
        }

        Destroy(gameObject); // 스크립트에 연결된 오브젝트 (= 여기서는 포탄)
    }
}
