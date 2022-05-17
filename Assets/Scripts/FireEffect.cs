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

    // OnEnable
    private void OnEnable()
    {
        // 오브젝트가 활성화 될 때 호출
        // Invoke()는 지정한 함수를 지시한 시간 후에 호출
        Invoke("Disable", 0.1f);
    }

    // Disable GameObject
    private void Disable()
    {
        // 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
