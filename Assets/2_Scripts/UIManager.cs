using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Image scoreImg = null;
    [SerializeField] private TMPro.TextMeshProUGUI scoreTmp = null;

    private void Awake()
    {
        Instance = this;
    }
    
    public void OnScore(int _currentScore, int _maxScore)
    {
        this.scoreTmp.text = $"{_currentScore}/{_maxScore}";

        this.scoreImg.fillAmount = (float)_currentScore / _maxScore;
    }
}
