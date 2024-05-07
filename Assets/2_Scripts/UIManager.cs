using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scoreImg = null;
    [SerializeField] private TMPro.TextMeshProUGUI scoreTmp = null;

    [SerializeField] private Image timerImg = null;
    [SerializeField] private TMPro.TextMeshProUGUI timerTmp = null;

    private void Awake()
    {
        Instance = this;
    }
    
    public void OnScore(int _currentScore, int _maxScore)
    {
        this.scoreTmp.text = $"{_currentScore}/{_maxScore}";

        this.scoreImg.fillAmount = (float)_currentScore / _maxScore;
    }
    public void OnTimer(float _currentTimer, float _maxTimer)
    {
        this.timerTmp.text = $"{_currentTimer.ToStringN(1)}/{_maxTimer.ToStringN(1)}";

        this.timerImg.fillAmount = (float)_currentTimer / _maxTimer;
    }
}
