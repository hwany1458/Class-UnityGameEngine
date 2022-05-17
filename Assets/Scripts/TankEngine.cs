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
        // 이동 및 회전 키의 입력상태를 조사
        float vert = Mathf.Abs(Input.GetAxis("Vertical"));
        float horz = Mathf.Abs(Input.GetAxis("Horizontal"));

        // 큰값을 pitch로 설정
        float pitch = Mathf.Max(vert, horz);

        // 피치는 -3.0~3.0, 볼륨은 0~1.0 으로 지정
        soundEngine.pitch = pitch + 1;  // 1.0~2.0
        soundEngine.volume = soundEngine.pitch * 0.6f;  // 0.6~1.2

    }
}
