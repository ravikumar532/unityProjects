using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;
    private void Start() {
       RefreshUI(); 
    }
    private void Awake() {
        scoreText=GetComponent<TextMeshProUGUI>();
    }
    public void Increase(int increment){
        score+=increment;
        RefreshUI();
    }
    private void RefreshUI(){
        scoreText.text="Score"+score;
    }
}
