using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class ScoreText : MonoBehaviour
{
    Text text;
    float alpha = 1;
    public void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, alpha, Time.deltaTime * 2.5f));
        if (text.color.a <= 0.05f)
        {
            Destroy(gameObject);
        }
    }
    public void Set(int score, string direct, string activ)
    {
        text = GetComponent<Text>();
        text.text = string.Format($"+{score} {direct} {activ}!");
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        alpha = 0;
    }
}