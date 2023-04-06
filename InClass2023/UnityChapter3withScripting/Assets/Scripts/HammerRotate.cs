using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerRotate : MonoBehaviour
{
    GameObject objHammer1 = null;
    GameObject objHammer2 = null;
    GameObject objHammer3 = null;

    // Start is called before the first frame update
    void Start()
    {
        objHammer1 = GameObject.Find("Hammer");
        objHammer2 = GameObject.Find("Head (1)");
        objHammer3 = GameObject.Find("Grip (2)");

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        if (objHammer1 != null && objHammer1.name == "Hammer")
        {
            objHammer1.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
        if (objHammer2 != null && objHammer2.name == "Head (1)")
        {
            objHammer2.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
        if (objHammer3 != null && objHammer3.name == "Grip (2)")
        {
            objHammer3.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }

    }
}
