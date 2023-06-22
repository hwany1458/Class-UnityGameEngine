using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        //scoreText.text = "Score : " + score.ToString();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
