using System.Collections;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    //--- variables ---
    public Transform explosion;  // 폭파 파티클

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //--- User Defined Methods ---
    void DestroySelf(Vector3 pos)
    {
        Instantiate(explosion, pos, Quaternion.identity);
        
        //Destroy(gameObject);
        // 폭파 효과 생성 후, 투명하게 사라지는 코루틴 실행
        // (즉시 파괴 대신, 폭파 효과를 보여준 후에 사라지도록)
        StartCoroutine(DestroyLazy());
    }

    // 투명하게 사라지기
    IEnumerator DestroyLazy()
    {
        // 오브젝트 매터리얼 읽기
        Material mat = GetComponent<Renderer>().material;
        Color color = mat.color;

        // 투명도 설정
        for (float alpha = 1; alpha >= 0; alpha -= 0.02f)
        {
            color.a = alpha;
            mat.color = color;
            yield return null;
        }
        Destroy(gameObject);
    }

}
