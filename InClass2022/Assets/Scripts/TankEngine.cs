using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEngine : MonoBehaviour
{
    AudioSource soundEngine;

    // Start is called before the first frame update
    void Start()
    {
        soundEngine = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �̵� �� ȸ�� Ű�� �Է»��¸� ����
        float vert = Mathf.Abs(Input.GetAxis("Vertical"));
        float horz = Mathf.Abs(Input.GetAxis("Horizontal"));

        // ū���� pitch�� ����
        float pitch = Mathf.Max(vert, horz);

        // ��ġ�� -3.0~3.0, ������ 0~1.0 ���� ����
        soundEngine.pitch = pitch + 1;  // 1.0~2.0
        soundEngine.volume = soundEngine.pitch * 0.6f;  // 0.6~1.2

    }
}
