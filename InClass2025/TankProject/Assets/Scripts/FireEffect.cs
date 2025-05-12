using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 오브젝트가 활성화될 때, 호출되어, 0.1초 후에, 
    // 자신을 다시 비활성화하므로, 불꽃 이미지는 0.1초 동안만 화면에 나타나게 됨

    // OnEnable
    // 오브젝트가 활성화될 떄 호출
    private void OnEnable()
    {
        //Invoke("Disable", 0.1f); // Invoke()함수는 지시한 시간 이후에, 지정한 함수를 호출
        // 함수 지연호출을 코루틴으로 변경
        StartCoroutine(Disable2(0.1f));
    }

    // Disable GameObject
    private void Disable()
    {
        gameObject.SetActive(false);  // 게임오브젝트를 비활성화
    }

    IEnumerator Disable2(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
