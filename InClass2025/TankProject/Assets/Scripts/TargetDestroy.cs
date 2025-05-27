using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    // 변수선언
    public Transform explosion;  // 타켓 폭발 파티클 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 사용자-정의 메소드
    void DestroySelf(Vector3 pos)
    {
        // 시각효과
        // 매개변수로 전달받은 위치(pos)에 폭발 파티클을 생성
        Instantiate(explosion, pos, Quaternion.identity);

        // 숙제
        // (4) 음향효과 (음향파일은 인터넷에서 검색하여 다운)


        // 타켓 객체를 (씬에서) 제거
        //Destroy(gameObject);
        // 바로 파괴(제거)되지 않고, 투명도를 처리해서, 투명하게 되면 그때 파괴되도록 함수 호출
        StartCoroutine(DestroyLazy());

    }

    // 숙제(2) - 슬라이드 ??페이지
    // 타켓 객체를 바로 파괴하지 않고, 투명하게 처리한 후, 파괴하기

    // 투명하게 사라지기
    IEnumerator DestroyLazy()
    {
        // 객체 매터리얼 읽어오기
        Material mat = GetComponent<Renderer>().material;
        Color color = mat.color;

        // 투명도 설정
        for (float alpha = 1.0f; alpha >= 1.0f; alpha -= 0.02f)
        {
            color.a = alpha;
            mat.color = color;

            yield return null;
        }

        // 투명도가 0이 된 다음, 타켓 객체를 파괴
        Destroy(gameObject);
    }


}
