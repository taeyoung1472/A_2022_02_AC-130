using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
public class Turret : MonoBehaviour, ISound
{
    [SerializeField] private CamManager cam;
    [SerializeField] private TurretInfo turret;
    [SerializeField] private GameObject soundObj;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private Image crossHair;
    bool isShoot;
    public void Start()
    {
        StartCoroutine(TurretSystem());
        Change(turret);
    }
    public void Shoot(bool _isShoot)
    {
        isShoot = _isShoot;
    }
    IEnumerator TurretSystem()
    {
        while (true)
        {
            yield return new WaitUntil(() => isShoot);
            Shoot();
            PlaySound(turret.shootAudio, 0.25f);
            yield return new WaitForSeconds(turret.fireRate);
        }
    }
    public void Shoot()
    {
        GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        cam.Shake(turret.shakingTime, turret.shakingForce);
        obj.GetComponent<BulletMove>().ExplosionRange = turret.explosionRange;
        obj.GetComponent<BulletMove>().Damage = turret.damage;
        obj.GetComponent<Rigidbody>().AddForce(firePos.forward * 50 + new Vector3(Random.Range(-turret.accuracy, turret.accuracy) * 50, Random.Range(-turret.accuracy, turret.accuracy) * 50, Random.Range(-turret.accuracy, turret.accuracy) * 50), ForceMode.Impulse);
    }
    public void PlaySound(AudioClip clip, float volume = 1)
    {
        GameObject obj = Instantiate(soundObj);
        obj.GetComponent<SoundObject>().PlaySound(clip, 0.1f);
    }
    public void Change(TurretInfo info)
    {
        turret = info;
        crossHair.sprite = turret.crossHair; 
    }
}