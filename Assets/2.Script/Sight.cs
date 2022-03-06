using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Sight : MonoBehaviour
{
    Vector2 limitX, limitY, zeroVec, fixVec;
    [SerializeField] private RectTransform sightArea;
    [SerializeField] private Vector2 sightLimit;
    public void Set(Vector2 X, Vector2 Y)
    {
        limitX = X;
        limitY = Y;
        zeroVec.x = (limitX.x + limitX.y) / 2;
        zeroVec.y = (limitY.x + limitY.y) / 2;
        fixVec.x = zeroVec.x - limitX.y;
        fixVec.y = zeroVec.y - limitY.y;
    }
    public void OnControllSight(Vector2 curSight)
    {
        sightArea.localPosition = new Vector2((zeroVec.y - curSight.y) / fixVec.y * sightLimit.x, -(zeroVec.x - curSight.x) / fixVec.x * sightLimit.y);
    }
}
