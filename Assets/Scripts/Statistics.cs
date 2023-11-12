using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatisticsType
{
    mainCount,
    levelCount,
    levelADR
}
public class Statistics : MonoBehaviour
{
    public StatisticsType type = StatisticsType.levelCount;
    public Text text;
    public string textBefore;
    public string textAfter;
    public string statisticsName;

    private void Start()
    {
        if (type == StatisticsType.mainCount)
        {
            text.text = textBefore + PlayerPrefs.GetInt("LevelsCount").ToString() + textAfter;
        }

        if (statisticsName == null)
            return;

        if(type == StatisticsType.levelCount)
        {
            text.text = textBefore + PlayerPrefs.GetInt($"LevelCount_{statisticsName}").ToString() + textAfter;
        }
        else if (type == StatisticsType.levelADR)
        {
            text.text = textBefore + (Mathf.RoundToInt(PlayerPrefs.GetFloat($"LevelADR{statisticsName}") * 100)).ToString() + textAfter;
        }
    }
}
