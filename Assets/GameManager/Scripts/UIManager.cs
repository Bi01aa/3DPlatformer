using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI timeValue;


    void Start()
    {
        UpdateScoreUI(0);
        UpdateTimeUI(0);
    }

    public void UpdateScoreUI(int value)
    {
        scoreValue.text = value.ToString("D5");

    }
    public void UpdateTimeUI(float time)
    {
        int seconds = (int)time;
        timeValue.text = System.TimeSpan.FromSeconds(seconds).ToString("hh':'mm':'ss");

    }




}
