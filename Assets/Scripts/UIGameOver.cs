using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    private void Awake() {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("00000000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
