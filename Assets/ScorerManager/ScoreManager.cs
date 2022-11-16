using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
