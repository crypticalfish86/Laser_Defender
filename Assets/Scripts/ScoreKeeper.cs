using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore = 0;
    
    public int GetCurrentScore(){
        return currentScore;
    }

    public void UpdateScore(int scoreToAdd){
        currentScore += scoreToAdd;
        Debug.Log("Score updated to: " + currentScore);
    }

    public void ResetScore(){
        currentScore = 0;
    }
}
