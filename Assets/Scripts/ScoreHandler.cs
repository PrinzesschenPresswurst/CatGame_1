using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int score;
    void Start()
    {
        score = 0;
        text.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        text.text = score.ToString();
    }
}
