using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    // 생성 조건 : 일정 조건 이상의 스코어
    [SerializeField] private int noteGroupSpawnCondition = 10;
    private int nextNoteGroupUnlockCnt;
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
            this.nextNoteGroupUnlockCnt++;

            if(this.nextNoteGroupUnlockCnt >= this.noteGroupSpawnCondition) {
                this.nextNoteGroupUnlockCnt = 0;

                // 노트 생성
                NoteManager.Instance.OnSpawnNoteGroup();
            }
        }
        else
            this.score--;

        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
}
