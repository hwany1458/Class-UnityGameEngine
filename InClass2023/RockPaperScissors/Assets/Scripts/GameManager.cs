using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI 처리용 라이브러리

public class GameManager:MonoBehaviour {

    Image imgYou;       // 당신의 가위바위보 이미지 표시용
    Image imgCom;       // 컴퓨터의 가위바위보 이미지 표시용

    Text txtYou;        // 당신이 승리한 횟수 표시용
    Text txtCom;        // 컴퓨터가 승리한 횟수 표시용
    Text txtResult;     // 판정 결과 표시용

    int cntYou = 0;     // 당신이 승리한 횟수
    int cntCom = 0;     // 컴퓨터가 승리한 횟수

    // Use this for initialization
    void Start () {
        InitGame();     // 게임 초기화
    }

    // Update is called once per frame
    void Update () {
        // Esc Key로 종료
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    // 승패 판정
    void CheckResult (int you) {
        int com = UnityEngine.Random.Range(1, 4);   // 1~3의 난수
        int k = you - com;

        // 공격권 0=시작(아무도없음), 1(나), 2(컴퓨터)
        //int who; 

        if (k == 0) {
            txtResult.text = "비겼습니다.";
        } else if (k == 1 || k == -2) {
            cntYou++;
            txtResult.text = "당신이 이겼습니다.";
        } else {
            cntCom++;
            txtResult.text = "컴퓨터가 이겼습니다.";
        }

        SetResult(you, com);    // 게임 결과를 UI에 반영 
    }

    // 게임 결과를 UI에 반영
    void SetResult (int you, int com) {
        // 이미지 바꾸기
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        // 컴퓨터 이미지를 x축으로 반전
        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        // 승리한 횟수
        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();

        // txtResult의 애니메이션 실행
        txtResult.GetComponent<Animator>().Play("TextScale", -1, 0);
    }

    // 버튼 Click
    public void OnButtonClick (GameObject button) {
        // 클릭한 버튼 번호 구하기
        int you = int.Parse (button.name.Substring(7, 1));
        CheckResult(you);   // 승패 판정
    }

    // Pointer Exit
    public void OnMouseExit (GameObject button) {
        Animator anim = button.GetComponent<Animator>();
        anim.Play("Normal");
    }

    // 게임 초기화
    private void InitGame () {
        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();

        txtYou = GameObject.Find("TxtYou").GetComponent<Text>();
        txtCom = GameObject.Find("TxtCom").GetComponent<Text>();
        txtResult = GameObject.Find("TxtResult").GetComponent<Text>();

        // 판정 결과 메시지 활용
        txtResult.text = "아래 버튼을 선택하세요";
    }

}
