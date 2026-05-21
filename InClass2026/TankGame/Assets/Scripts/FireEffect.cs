using System.Collections;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnEnable
    //void OnEnable() { Invoke("Disable", 0.1f); }  // 오브젝트가 활성화될 때 호출
    // Invoke()는 지정한 함수를 지시한 시간 후에 호출 

    void OnEnable() 
    { 
        StartCoroutine(Disable(0.1f)); 
    }  // 코루틴을 사용하여 지연 후에 Disable() 함수를 호출

    // Disable GameObject
    void Disable() 
    { 
        gameObject.SetActive(false); 
    }  // 오브젝트를 비활성화

    // Disable GameObject
    IEnumerator Disable(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
