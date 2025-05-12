using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEngine : MonoBehaviour
{
    AudioSource soundEngine;  // 오디오소스 변수선언

    // Start is called before the first frame update
    void Start()
    {
        soundEngine = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 이동 및 회전 키의 입력상태를 받아냄
        // 키입력은 -1.0 ~ 1.0 사이의 값이므로, (사운드 볼륨을 조정하기 위해) 양수로 변환(절대값)
        float vert = Mathf.Abs(Input.GetAxis("Vertical"));
        float hori = Mathf.Abs(Input.GetAxis("Horizontal"));

        // 큰값을 pitch로 설정
        float pitch = Mathf.Max(vert, hori);

        // 피치는 -3.0 ~ 3.0, 볼륨은 0 ~ 1.0으로 지정
        soundEngine.pitch = pitch + 1.0f;  // 1.0 ~ 2.0으로 만들기 위해 +1 시킴
        soundEngine.volume = soundEngine.pitch * 0.6f;  // 0.6 ~ 1.2
    }
}
