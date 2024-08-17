using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{

    [Header("Heatlh")]
    [SerializeField] Slider heatlhSlider;
    [SerializeField] ShipHealthAndDamage playerHeatlh;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    

    private void Awake(){
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        heatlhSlider.maxValue = playerHeatlh.GetShipHealth();
    }

    // Update is called once per frame
    void Update()
    {
        heatlhSlider.value = playerHeatlh.GetShipHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("00000000");
    }
}
