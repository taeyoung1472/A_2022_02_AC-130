using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreText, scoreScrollView;
    [SerializeField] private Text TimeText;
    DateTime date = DateTime.Now;
    public void Start()
    {
        StartCoroutine(TimeSystem());
    }
    public void Magnification(float value)
    {
        Camera.main.fieldOfView = 60 - value;
    }
    public void ScoreRegist(int score, string direct, string activ)
    {
        GameObject obj = Instantiate(scoreText,scoreScrollView.transform);
        obj.SetActive(true);
        obj.GetComponent<ScoreText>().Set(score, direct, activ);
    }
    public IEnumerator TimeSystem()
    {
        while (true)
        {
            TimeText.text = string.Format($"{date.Day} / {date.Hour} / {date.Minute} / {date.Second}");
            yield return new WaitForSeconds(1f);
            date = DateTime.Now;
        }
    }
}