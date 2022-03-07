using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class HitMark : MonoBehaviour
{
    RectTransform rect;
    float size, sizeGoal;
    bool isMarking;
    public void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void Update()
    {
        size = Mathf.Lerp(size, sizeGoal, Time.deltaTime * 10);
        print(size);
        rect.sizeDelta = new Vector2(size, size);
    }
    public void Mark(float goal)
    {
        if (!isMarking)
        {
            StartCoroutine(HitMarking(goal));
        }
    }
    IEnumerator HitMarking(float goal)
    {
        isMarking = true;
        sizeGoal = goal;
        yield return new WaitForSeconds(0.25f);
        sizeGoal = 0;
        isMarking = false;
    }
}
