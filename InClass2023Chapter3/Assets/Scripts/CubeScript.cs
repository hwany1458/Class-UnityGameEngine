using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // (이름으로) 객체 찾기 -- return이 1개
        GameObject obj = GameObject.Find("Sphere");
        if (obj == null) {  // 객체를 못찾은 경우
            Debug.LogError("Object is NOT found ..");
        } else {   // 객체를 찾은 경우
            Debug.Log("위치는 " + obj.transform.position.x);
            
            // SendMessage()로 찾은 객체의 함수를 호출
            obj.SendMessage("WhoAmI");  // 매개변수 없는 놈

            // 다음시간까지 ...
            // 매개변수 1개까지, 2개짜리를 만들고 SendMessage()로 호출해 보세요
        }

        // 태그로 객체 찾기
        GameObject obj2 = GameObject.FindWithTag("userDefinedTag");
        if (obj2 == null) {  // 객체를 못찾은 경우
            Debug.LogError("Object is NOT found ..");
        } else {   // 객체를 찾은 경우
            Debug.Log("위치는 " + obj.transform.position.x);
        }

        // 다수개 찾기
        GameObject[] objs = GameObject.FindGameObjectsWithTag("userDefinedTag");
        if (objs == null) { Debug.LogError("Object is NOT found .."); }
        else {
            //for (int i = 0; i < objs.Length; i++) { }
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
