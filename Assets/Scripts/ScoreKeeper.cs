using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper instance;
    private int currentScore = 0;

    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton(){
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
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
