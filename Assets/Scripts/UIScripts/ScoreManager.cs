using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }
    public int _score { get; private set; }

    [SerializeField]
    private Text _scoreText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }
}
