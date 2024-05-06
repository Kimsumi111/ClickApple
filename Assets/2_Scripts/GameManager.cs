using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    private int score;

    void Awake()
    {
        Instance = this;  
    }
    private void Start()
    {
        UIManager.Instance.OnScore(this.score, this.maxScore);
        NoteManager.Instance.Activate();
    }

    public void OnScore(bool _isCorrect)
    {
        if (_isCorrect)
        {
            this.score++;
        }
        else
            this.score--;

        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
}
