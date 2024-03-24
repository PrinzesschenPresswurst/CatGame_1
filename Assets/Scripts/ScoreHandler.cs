using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int _score;
    void Start()
    {
        _score = 0;
        text.text = _score.ToString();
    }

    public void IncreaseScore()
    {
        _score++;
        text.text = _score.ToString();
    }
}
