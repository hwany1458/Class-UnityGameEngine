using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Singleton : MonoBehaviour
{
    public static Scene1Singleton instance = null;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
