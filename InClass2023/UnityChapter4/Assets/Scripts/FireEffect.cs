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

    private void OnEnable()
    {
        // 포탄발사 효과 이미지가 보여지면 0.1초 이후에
        // Disable() 함수를 호출하여 비활성화 시킴 (SetActive를 false로)
        StartCoroutine(Disable(0.1f));
    }

    IEnumerator Disable(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
