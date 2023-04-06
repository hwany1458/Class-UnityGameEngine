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

    // 접근권한자를 안썼음 default (private)
    public void WhoAmI()
    {
        Debug.Log("My name is " + gameObject.name);
    }

    private void WhoWeAre(string name)
    {
        Debug.Log("We are " + gameObject.name + " and " + name);
    }

    
}
