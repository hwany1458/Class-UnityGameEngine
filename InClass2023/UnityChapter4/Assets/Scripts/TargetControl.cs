using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public Transform explosion; // 파괴시 파티클

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf(Vector3 pos)
    {
        // 점수 +10
        // 타켓 제거 시점에서의 파티클
        Instantiate(explosion, pos, Quaternion.identity);

        // 타켓 제거 음향효과
        
        // 타켓 제거
        Destroy(gameObject);
        
        // 타켓 제거시에 점점 투명하게 (투명도를 조절) 한 후, 객체 제거
        // 교재 192페이지 참조
        // 각자 붙여보세요
    }

}
