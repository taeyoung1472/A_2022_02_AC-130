using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamManager : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Sight sight;
    [SerializeField] private Vector2 limitAngleX;
    [SerializeField] private Vector2 limitAngleY;
    [SerializeField] private float sensevitey;
    float shakeForce;
    Vector3 rot;
    public Vector3 dir1;
    public void Start()
    {
        sight.Set(limitAngleX, limitAngleY);
    }
    public void Update()
    {
        if (shakeForce != 0)
        {
            transform.localPosition = Random.insideUnitSphere * shakeForce * Time.deltaTime;
        }
    }
    public void Turn(Vector2 dir)
    {
        dir1 = dir;
        cam.Rotate(new Vector3(0,1,0) * dir.x * sensevitey * Time.deltaTime + Vector3.right * -dir.y * sensevitey * Time.deltaTime);
        rot = cam.transform.localEulerAngles;
        rot.x = Mathf.Clamp(rot.x ,limitAngleX.x, limitAngleX.y);
        rot.y = Mathf.Clamp(rot.y, limitAngleY.x, limitAngleY.y);
        rot.z = 0;
        cam.localEulerAngles = rot;
        sight.OnControllSight(rot);
    }
    public void Shake(float time, float force)
    {
        StartCoroutine(ShakeCor(time, force));
    }
    IEnumerator ShakeCor(float time, float force)
    {
        shakeForce = force;
        yield return new WaitForSeconds(time);
        shakeForce = 0;
        transform.localPosition = Vector3.zero;
    }
}