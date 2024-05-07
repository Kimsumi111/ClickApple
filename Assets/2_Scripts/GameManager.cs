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
    [SerializeField] private GameObject gameClearObj = null;
    [SerializeField] private GameObject gameOverObj = null;
    private int nextNoteGroupUnlockCnt;
    private int score;

    [SerializeField] private float maxTime = 30f;

    void Awake()
    {
        Instance = this;  
    }
    private void Start()
    {
        UIManager.Instance.OnScore(this.score, this.maxScore);

        NoteManager.Instance.Activate();

        this.gameClearObj.SetActive(false);
        this.gameOverObj.SetActive(false);

        StartCoroutine(this.OnTimer());

    }
    IEnumerator OnTimer()
    {
        float _currentTime = 0f;

        while (this.maxTime > _currentTime)
        {
            _currentTime += Time.deltaTime;

            UIManager.Instance.OnTimer(_currentTime, this.maxTime);

            yield return null;
        }

        // GameOver

        this.gameOverObj.SetActive(true);
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
            if(this.maxScore <= this.score)
            {
                // Game Clear
                this.gameClearObj.SetActive(true);
            }
        }
        else
            this.score--;

        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
    public void CallBtn_Restart()
    {

    }
}
