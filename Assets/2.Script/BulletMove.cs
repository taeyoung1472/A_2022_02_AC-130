using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float explosionRange;
    [SerializeField] private float explosionForce;
    [SerializeField] private float damage;
    public float ExplosionRange { get { return explosionRange; } set { explosionRange = value; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (Collider item in cols)
        {
            if(item.CompareTag("Enemy"))
            {
                print("Enemy »Æ¿Œ");
                Enemy tgt = item.GetComponent<Enemy>();
                if (tgt.GetDamage(gameObject))
                {
                    tgt.Dead(new Vector3(transform.position.x,transform.position.y, transform.position.z),explosionForce,explosionRange);
                }
            }
        }
        GameObject obj = Instantiate(explosionEffect,transform.position,Quaternion.identity);
        obj.transform.localScale = Vector3.one * Mathf.Sqrt(damage);
        Destroy(gameObject);
    }
}