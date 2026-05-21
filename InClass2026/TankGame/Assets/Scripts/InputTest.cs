using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class InputTest : MonoBehaviour
{
    // --- variables ---
    float v;  // 수직축 입력값

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump -GetButtonDown, Space Bar is pressed.");
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump -GetButton, Space Bar is pressing");
        }
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Jump -GetButtonUp, Space Bar is released.");
        }

        //-------
        v = Input.GetAxis("Vertical");
        if (v != 0.0)
        {
            Debug.Log("Vertical: " + v);
        }

        // ----
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q Key is pressed.");
        }
    }
}
