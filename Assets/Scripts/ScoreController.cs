using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int score = 0;

    public static string prefix = "Score: ";
    private static Text scoreText;

    private static ScoreController instance;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        instance = this;
    }

    public static void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = prefix + score.ToString();
    }

}
