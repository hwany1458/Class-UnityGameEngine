using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // --- 사용자 정의 함수 (user-defined methods)
    public void WhoAmI(string parName)
    {
        Debug.Log("My name is " + parName);
    }
    public void WhoAreYou()
    {
        Debug.Log("My name is " + gameObject.name);
    }

}
