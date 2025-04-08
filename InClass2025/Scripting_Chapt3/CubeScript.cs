using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    //--------- Variables (변수선언)
    // 전역변수
    public int speed = 200;
    public string nameOfBox = "candy box";
    public bool isFound = false;
    public int isColor;

    // public으로 선언된 변수는 (기본적으로) 인스팩터에 속성으로 나타남
    // 나타나지 않게 하려면, NonSerialized
    [System.NonSerialized]  
    public int hp;
    // private으로 선언된 변수는 (기본적으로) 인스팩터에 나타나지 않음
    // 나타나게 하려면, SerializeField
    [SerializeField]
    private float moveAmount = 0.5f;

    //--------- Methods (메소드 선언)

    // 맨 처음, 한번 실행 (초기화시킬 때 주로 사용)
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        Debug.Log("Start() method is called ...");
        isColor = 1;

        // 씬에 있는 객체를 찾으려면 GameObject.Find() 함수 사용
        // 객체를 찾을 때는 활성화되어 있는 객체만을 대상으로 탐색한다
        GameObject foundObj = GameObject.Find("Sphere");

        // 객체를 찾은 경우와 못찾은 경우를 구분해서 코딩 -- 좋은 습관
        if (foundObj == null) // 못찾은 경우
        {
            Debug.Log("객체를 못찾았습니다");
        }
        else // 찾은 경우
        {
            Debug.Log(foundObj.transform.position.x);
            // Quiz
            // 동일한 이름의 객체가 여러개 있는 경우,
            // (여러 개의 찾은 객체들 중에서) 마지막으로 찾은 객체를 대상으로 함

            // ----- 찾은 객체에 연결된 스크립트의 함수를 호출하는 방법
            // (방법1) SendMessage() 함수 이용
            // public이든 private이든 상관없이 메소드 호출 가능
            //foundObj.SendMessage("WhoAreYou");

            // (방법2) (찾은 객체의) 컴포넌트로 접근해서 실행
            // public으로 선언된 메소드만 접근이 가능
            foundObj.GetComponent<SphereScript>().WhoAreYou();
            // Quiz
            // 만약 private로 선언되어 있을 경우, 메시지 [보호 수준 때문에 SphereScript.WhoAreYou()에 액세스할 수 없습니다]
        }
    }

    // 게임씬에서 매 프레임마다 실행
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update() method is called ..");

        /*----------
        // 키보드에서 특정키를 눌렀을 때, if문의 조건이 참이 되어, 이벤트 발생
        if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        ---------- */

        // Practice 
        // 현재의 색깔 상태를 저장해야 하므로, isColor 변수를 선언하여 현재 상태를 저장
        // 한번 누르면 빨간색으로, 다시 한번(더) 누르면 파란색으로 변경
        if (Input.GetKeyDown(KeyCode.R) && isColor==1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            isColor = 2;
        } 
        else if (Input.GetKeyDown(KeyCode.R) && isColor == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            isColor = 1;
        }

        // Debug.Log() 함수를 써서, 콘솔에 내용을 뿌려본다 (실행중에 값을 확인하
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("U pressed A key..");
        }


        /* --------------
        // (스크립트가 연결된) 객체 이동
        // (방법1) 위치값(속성)을 조정하는 방법
        // a = a+1; (=) a+=1;
        // 현재 위치에서 z축을 기준으로, 1만큼 앞으로 이동
        transform.position += new Vector3(0, 0, 1);
        // (방법2) 이동하라는 명령(함수) 호출
        transform.Translate(Vector3.forward * moveAmount);
        ------------ */

    }

    // 마우스 클릭을 누를 때, 이벤트 발생(함수 호출됨)
    void OnMouseDown()
    {
        Debug.Log("Mouse click");
    }

    // 마우스 클릭을 띨 때, 이벤트 발생(함수 호출됨)
    void OnMouseUp()
    {
        Debug.Log("Mouse UP");
    }

    // 마우스 (이동하면서) 객체 범위로 들어갈 때, 이벤트 발생(함수 호출됨)
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    // 마우스 (이동하면서) 객체 범위에서 빠져나갈 때, 이벤트 발생(함수 호출됨)
    void OnMouseExit()
    {
        Debug.Log("Mouse out ");
    }


    // MonoBehaviour 참조
    //https://docs.unity3d.com/kr/2023.2/ScriptReference/MonoBehaviour.html

    // 유니티에서 스크립트 이름을 변경하여 (클래스 이름과) 같지 않을 때, 메시지
    // (인스팩터에) 경고창이 나오고 수정하라고 나옴
    // [The associated script can not be loaded. Please fix any compile errors and assign a valid script] 


    //---------- User-defined Methods (사용자 정의 메소드)
}
