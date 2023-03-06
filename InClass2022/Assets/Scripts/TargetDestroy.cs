using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    public Transform explosion;  // ���� ��ƼŬ

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
        // �ڷ�ƾ ó��
        //StartCoroutine(DestroyLazy());
    }

    IEnumerator DestroyLazy()
    {
        Material mat = GetComponent<Renderer>().material;
        Color col = mat.color;

        // ���� ���� --- ���� ���� ����
        for (float alpha=1.0f; alpha>=0; alpha -= 0.02f)
        {
            col.a = alpha;
            mat.color = col;
            mat.color = col;
            yield return null;
        }
        // 0�� �Ǹ� �ı�
        Destroy(gameObject);
    }
}
