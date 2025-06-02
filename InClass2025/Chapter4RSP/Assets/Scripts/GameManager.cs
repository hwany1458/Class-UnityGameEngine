using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI처리용 라이브러리
using TMPro;

public class GameManager : MonoBehaviour
{
    //---- Variables
    Image imgYou;  //사용자(게이머) 가위바위보 이미지 표시용
    Image imgCom;  //컴퓨터 가위바위보 이미지 표시용

    // Legacy Text를 사용한 경우
    //Text txtYou;   // 사용자 승리한 회수 표시용
    //Text txtCom;   // 컴퓨터 승리한 회수 표시용
    //Text txtResult; // 가위바위보 판정 결과 표시용

    // TextMeshPro를 사용한 경우
    TextMeshProUGUI txtYou1;
    TextMeshProUGUI txtCom1;
    TextMeshProUGUI txtResult1;

    int cntYou = 0; // 사용자(게이머) 승리 회수
    int cntCom = 0; // 컴퓨터 승리 회수


    //---- Methods
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // 버튼 클릭
    public void OnButtonClick(GameObject button) 
    {
        // 클릭한 버튼 번호를 짤라온다
        // 클릭한 버튼이름 (예, Button_1 문자열에서 7번째 문자열부터 1자리를 짜름 --> 1)
        // 가위(1), 바위(2), 보(3)이 됨
        int you = int.Parse(button.name.Substring(7, 1));
        CheckResult(you);  // 승패를 판정
    }

    // Pointer Exit
    public void OnMouseExit(GameObject button)
    {
        Animator anim = button.GetComponent<Animator>();
        anim.Play("Normal");
    }

    //---- Usre-defined Methods
    // 게임 초기화
    void InitGame()
    {
        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();

        //txtYou = GameObject.Find("TxtYou").GetComponent<Text>();
        //txtCom = GameObject.Find("TxtCom").GetComponent<Text>();
        //txtResult = GameObject.Find("TxtResult").GetComponent<Text>();

        txtYou1 = GameObject.Find("TxtYou").GetComponent<TextMeshProUGUI>();
        txtCom1 = GameObject.Find("TxtCom").GetComponent<TextMeshProUGUI>();
        txtResult1 = GameObject.Find("TxtResult").GetComponent<TextMeshProUGUI>();

        // 판정결과 메시지
        //txtResult.text = "가위바위보 버튼을 클릭하세요.";
        txtResult1.text = "가위바위보 버튼을 클릭하세요.";
    }

    // 승패 판정
    void CheckResult(int you)
    {
        int com = UnityEngine.Random.Range(1, 4);  // 1~3의 난수 발생
        int k = you - com;

        if (k == 0)
        {
            txtResult1.text = "비겼습니다";
        }
        else if (k == 1 || k == -2)
        {
            cntYou++;
            txtResult1.text = "당신이 이겼습니다";
        }
        else
        {
            cntCom++;
            txtResult1.text = "컴퓨터가 이겼습니다";
        }

        // 게임 결과를 UI에 반영하는 함수 호출
        SetResult(you, com);
    }

    // 게임 결과를 UI에 반영
    void SetResult(int you, int com)
    {
        // 이미지 바꾸기
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        // 컴퓨터 이미지를 x축으로 반전
        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        // 승리한 회수 적용
        txtYou1.text = cntYou.ToString();
        txtCom1.text = cntCom.ToString();

        // txtResult 애니메이션 실행
        txtResult1.GetComponent<Animator>().Play("TextResultScaleChange", -1, 0);
    }
}

