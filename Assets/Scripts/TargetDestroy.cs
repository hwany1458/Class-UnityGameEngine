using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    public Transform explosion;  // 폭파 파티클

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySelf(Vector3 pos)
    {
        Instantiate(explosion, pos, Quaternion.identity);
        Destroy(gameObject);
        // 코루틴 처리
        //StartCoroutine(DestroyLazy());
    }

    IEnumerator DestroyLazy()
    {
        Material mat = GetComponent<Renderer>().material;
        Color col = mat.color;

        // 투명도 설정 --- 점점 투명도 낮춤
        for (float alpha=1.0f; alpha>=0; alpha -= 0.02f)
        {
            col.a = alpha;
            mat.color = col;
            mat.color = col;
            yield return null;
        }
        // 0이 되면 파괴
        Destroy(gameObject);
    }
}
