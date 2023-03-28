using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // 클래스명과 (유니티에서의) 스크립트명이 동일해야 한다 (슬라이드 36)
    // 다른 경우, (경고 메시지는)
    // [경고] The associated script can not be loaded. 
    // Please fix any compile errors and assign a valid script

    // 변수선언 public vs. private (slide 22)

    // default = private
    // private으로 선언될 경우, 인스팩터에 나타나지 않음
    // private으로 사용하지만, 인트팩터에 나타나게 하려면, [SerializedField]를 붙인다
    [SerializeField]
    private int cnt = 0;

    // public으로 선언될 경우, 인스팩터에 나타남
    // public으로 사용하지만, 인스팩터에 안 나타나게 하려면, [NonSerialized]를 붙인다 
    [System.NonSerialized]
    public int cnt1 = 0;

    // 키가 눌러진 카운트를 셀수 있도록
    private int keyPressedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start() function is called ..");

        // user-defined function call
        int ret = CalledFunction();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update() function is called ...");

        // 매 프레임마다 z축 값을 증가시키면, 화면에서는 앞으로 이동하게된다
        //transform.position += new Vector3(0, 0, 1);

        // (1) key press 를 실행시키려면
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A Key is pressed ..");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        */

        // (2)
        // 1번 누르면 빨간색으로, 2번 누르면 파란색으로, 또 누르면 다시 빨간색으로 ..
        // 이렇게 동작하도록 코드를 변경해 보세요
        // 실행 및 처리과정을 먼저 연필로 작성하고, 코드를 수정해 봅니다
        if (Input.GetKeyDown(KeyCode.A))
        {
            keyPressedCount++;
            Debug.Log("A key is pressed, thus count is currently " + keyPressedCount);

            if ((keyPressedCount % 2) == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }

    // 사용자 정의 함수 (user-defined function)
    int CalledFunction()
    {
        Debug.Log("CalledFunction() is called ..");
        return 0;
    }

    // 유니티 기본 내장 함수
    // On~ 계열 함수 (slide 32)
    private void OnMouseEnter()
    {
        Debug.Log("Mouse is entered ..");
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse is left ..");
    }
}
