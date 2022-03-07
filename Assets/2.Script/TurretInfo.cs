using UnityEngine;
[CreateAssetMenu(fileName = "Info", menuName = "Turret")]
public class TurretInfo : ScriptableObject
{
    [Header("ÅÍ·¿°ü·Ã")]
    public string name;
    public Sprite profileImage;
    public Sprite crossHair;
    public GameObject bullet;
    public AudioClip shootAudio;
    public AudioClip reroadAudio;
    public float fireRate;
    public float limitFire;
    public float shakingTime;
    public float shakingForce;
    [Range(0,1)] public float accuracy;
    [Header("ÃÑ¾Ë°ü·Ã")]
    public float damage;
    public float explosionRange;
}