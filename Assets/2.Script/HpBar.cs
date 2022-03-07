using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    Transform trans;
    float hp,maxHp;
    [SerializeField] private Vector3 hpBarScale;
    [SerializeField] private Transform fill, backGround;
    void Start()
    {
        trans = GameManager.MainCam;
    }
    public void Set(float _maxHp)
    {
        maxHp = _maxHp;
        fill.transform.localPosition = new Vector3(hpBarScale.x * 0.5f, 0, 0);
        fill.localScale = new Vector3(hpBarScale.x, hpBarScale.y, hpBarScale.z);
        backGround.localScale = new Vector3(hpBarScale.x, hpBarScale.y * 1.1f,hpBarScale.z * 0.9f);
    }
    public void HpUpdate(float _hp)
    {
        if(_hp <= 0)
        {
            gameObject.SetActive(false);
        }
        hp = _hp;
        fill.localScale = new Vector3(hpBarScale.x * (hp / maxHp), hpBarScale.y, hpBarScale.z);
        print(hpBarScale.x * (hp / maxHp));
    }
    void Update()
    {
        transform.LookAt(trans.position);
    }
}
