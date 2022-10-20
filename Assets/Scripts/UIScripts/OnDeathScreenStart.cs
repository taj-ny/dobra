using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDeathScreenStart : MonoBehaviour
{

    [SerializeField] 
    private Text _scoreText;

    void Start()
    {
        _scoreText.text = "Score: " + ScoreManager.Instance._score;
    }
}
