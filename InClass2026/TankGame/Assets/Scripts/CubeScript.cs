using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // ---- variables
    public int hp = 0;
    public string playerName;
    private int playerKey = 0;

    public GameObject npc1;

    // ----  methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 100;
        playerKey = 10;
        playerName = "YongHwan";

        //npc1 = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ---- user-defined method
}
