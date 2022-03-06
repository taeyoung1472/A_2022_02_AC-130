using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class Joystick : MonoBehaviour , IDragHandler , IBeginDragHandler , IEndDragHandler
{
    [SerializeField] private CamManager camManager;
    [SerializeField] private RectTransform handle;
    [SerializeField] private RectTransform handleBackground;
    [SerializeField, Range(10, 150)] private float handleRange;
    RectTransform rect;
    bool isDraging;
    Vector2 dir;
    public void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void Update()
    {
        if (isDraging)
        {
            camManager.Turn(dir);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputPos = eventData.position - rect.anchoredPosition;
        var inputVector = inputPos.magnitude < handleRange ? inputPos : inputPos.normalized * handleRange;
        handle.anchoredPosition = inputVector;
        isDraging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        var inputPos = eventData.position - rect.anchoredPosition;
        var inputVector = inputPos.magnitude < handleRange ? inputPos : inputPos.normalized * handleRange;
        handle.anchoredPosition = inputVector;
        dir = inputVector;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        isDraging = false;
    }
}