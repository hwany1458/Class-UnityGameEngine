using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingSound : MonoBehaviour
{
    // AudioSource를 저장할 변수 선언 (전역변수)
    AudioSource ballSound;

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 컴포넌트 열기 (변수에 값 할당)
        // 씬이 로딩되면 AudioSource를 변수로 읽어 들임
        ballSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌 처리 함수
    // 오브젝트 충돌이 발생하면 호출되는 이벤트 함수
    // 충돌의 상대편 정보가 매개변수 other로 전달됨
    private void OnCollisionEnter(Collision collision)
    {
        // AudioSource에 할당된 오디오 클립을 재생
        ballSound.Play();
        Debug.Log("충돌이 일어나는 (대상)객체이름 =" + collision.gameObject.name);
    }
}
