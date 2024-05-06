using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    // ���� ���� : ���� ���� �̻��� ���ھ�
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

                // ��Ʈ ����
                NoteManager.Instance.OnSpawnNoteGroup();
            }
        }
        else
            this.score--;

        UIManager.Instance.OnScore(this.score, this.maxScore);
    }
}
