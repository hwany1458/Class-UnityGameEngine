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
        // ������Ʈ�� Ȱ��ȭ �� �� ȣ��
        // Invoke()�� ������ �Լ��� ������ �ð� �Ŀ� ȣ��
        Invoke("Disable", 0.1f);
    }

    // Disable GameObject
    private void Disable()
    {
        // ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
