using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 스크립트 간의 호출 (slide 46)
        // (1) 대상 객체를 (먼저) 찾음
        // (2) (검색한) 해당 객체에 연결된 스크립트 함수를 호출
        
        
        // 아래 예제 코드에서는 Cube에서 Sphere를 찾는다
        // 객체를 비활성화 한 다음, 객체 검색을 실행해 봅니다
        // Find는 비활성화된 객체는 검색 대상이 되지 않음 (즉, 활성화된 객체만을 대상으로 찾음) (slide 53)

        // (이름으로) 객체 찾기 -- return이 1개
        GameObject obj = GameObject.Find("Sphere");
        //GameObject obj = GameObject.Find("Sphere1");
        // (이름을 바꿔서) 못 찾는 경우를 테스트 해 봅니다
        if (obj == null) {  // 객체를 못찾은 경우
            Debug.LogError("Object is NOT found ..");
        } else {   // 객체를 찾은 경우
            Debug.Log("위치는 " + obj.transform.position.x);
            
            // SendMessage()로 찾은 객체의 함수를 호출
            obj.SendMessage("WhoAmI");  // 매개변수 없는 놈

            // 다음시간까지 ...
            // 매개변수 1개까지, 2개짜리를 만들고 SendMessage()로 호출해 보세요
        }

        // 태그로 객체 찾기 - return 오브젝트는 1개 (가까운? 놈)
        GameObject obj2 = GameObject.FindWithTag("userDefinedTag");
        if (obj2 == null) {  // 객체를 못찾은 경우
            Debug.LogError("Object is NOT found ..");
        } else {   // 객체를 찾은 경우
            Debug.Log("위치는 " + obj.transform.position.x);
        }

        // 여러개 객체를 찾기
        // FindGameObjectWithTag() 와 FindGameObjectsWithTag() -- 복수에 주의
        GameObject[] objs = GameObject.FindGameObjectsWithTag("userDefinedTag");
        if (objs == null) { Debug.LogError("Object is NOT found .."); }
        else {
            //for (int i = 0; i < objs.Length; i++) { }
            // 객체를 다룰때는 for()문보다 foreach() 문이 편함
            //foreach (GameObject eachObj in objs) {
            foreach (var eachObj in objs) {
                Debug.Log("반복문: 위치 " + eachObj.transform.position.x);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
