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
            
            // 스크립트간의 호출 (1번 방법) - SendMessage()
            // 함수가 public 이든 private 이든 상관없이 호출 가능
            // SendMessage()로 찾은 객체의 함수를 호출
            obj.SendMessage("WhoAmI");  // 매개변수 없는 놈
            // 매개변수 2개짜리를 만들고 SendMessage()로 호출해 보세요
            obj.SendMessage("WhoWeAre", "Digital Contents");

            // 스크립트간의 호출 (2번 방법) - GetComponent<>()
            // 찾은 객체를 obj 변수로 받아놓았음
            // 호출하려는 함수가 반드시 public으로 접근권한이 부여되어 있어야함
            // private인 경우 : 에러 발생
            //  error CS0122: 'SphereScript.WhoAmI()' is inaccessible due to its protection level
            obj.GetComponent<SphereScript>().WhoAmI();

            // 특정 오브젝트의 자식 오브젝트로 접근 (Slide 61)
            GameObject getObj = GameObject.Find("SnowMan");
            if (getObj != null)
            {
                Debug.Log("Object found");

                // (1) 선택 오브젝트 바로 아래에 있는 자식 오브젝트(들 중 하나)만 접근
                // 자식 오브젝트가 여러 개라면, TransformSort 기준으로 가장 상위에 있는 자식 오브젝트의 컴포넌트를 받아옴
                Transform getChild = getObj.transform.GetChild(0);
                Debug.Log("자식 오브젝트 이름 = " + getChild.name);

                // GetComponentInChild는 지정한 컴포넌트 하나만 추출
                getChild = getObj.GetComponentInChildren<Transform>();
                Debug.Log("(GetComponentInChild는) 자식 오브젝트 이름 = " + getChild.name + " ㅠㅠ");

                // (2) 선택 오브젝트 아래에 있는 모든 자식 오브젝트들로 접근
                Transform[] getChildren = getObj.GetComponentsInChildren<Transform>();
                if (getChildren != null)
                {
                    Debug.Log("객체들을 찾았고, 이번에는 여러 자식들을 출력해 보겠습니다");
                    foreach (Transform child in getChildren)
                    {
                        // 자식 오브젝트들을 가져오는데, (검색한) 부모 오브젝트도 포함되어 있음
                        // 부모 오브젝트를 제외시키려면
                        if (child.name == "SnowMan") { continue;  } // 부모 오브젝트 자신이면 반복문을 Skip
                        Debug.Log("자식들 " + child.name);
                    }
                }
                else
                {
                    Debug.LogWarning("Object is found, however there is NO child ..");
                }
            }
            else
            {
                Debug.LogWarning("Object is NOT found ..");
            }
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
