using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 반환 데이터형태가 int로 선언된 함수에서 (돌려받은) 반환데이터를 문자열로 받아서 오류 발생
        //string retValue = CalculateSum(100, 200);
        // 오류를 수정하려면
        // (1) 반환 데이터타입을 문자열로 받든지
        // 혹은 (2) 반환된 (정수형) 데이터를 문자열로 변환하든지
        // 여기서 (2번)으로 수정하면 다음과 같음
        string retValue = CalculateSum(100, 200).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int CalculateSum(int x, int y)
    {
        return x + y;
    }

}
