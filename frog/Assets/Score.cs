using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int targetScore;
    public int growthRate;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        targetScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score != targetScore) {
            AnimateScore();
        }
        scoreText.text = score.ToString();
    }

    public void AddScore(int addedScore) {
        targetScore += addedScore;
        
    }

    void AnimateScore() {
        if (targetScore - score > growthRate) {
            score += growthRate;
        }
        else {
            score = targetScore;
        }
    }

    void FinalScore() {

    }
}
