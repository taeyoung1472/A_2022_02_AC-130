using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private Rigidbody spine;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private NavMeshAgent nav;
    //[SerializeField] private 
    [SerializeField] private Animator animator;
    [SerializeField] HpBar hpBar;
    Collider col;
    Transform player;
    bool isDead;
    bool isCanAttack;
    float hp;
    void Start()
    {
        hp = enemyInfo.hp;
        player = GameManager.Player;
        nav.SetDestination(player.position);
        nav.speed = enemyInfo.speed;
        col = GetComponent<Collider>();
        hpBar.Set(hp);
    }
    /*public IEnumerator AttackCor()
    {
        for (int i = 0; i < enemyInfo.brustCount; i++)
        {

        }
    }
    public void Attack()
    {

    }*/
    public void Update()
    {
        
    }
    public IEnumerator Checkdistance()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.25f);
            if (Vector3.Distance(transform.position, player.position) <= enemyInfo.attackRange)
            {
                isCanAttack = true;
            }
            else
            {
                isCanAttack = false;
            }
        }
    }
    public bool GetDamage(GameObject obj)
    {
        if(isDead) { return false; }
        BulletMove bullet = obj.GetComponent<BulletMove>();
        hp -= bullet.Damage * (Vector3.Distance(transform.position,obj.transform.position) / Mathf.Sqrt(bullet.ExplosionRange));
        hpBar.HpUpdate(hp);
        if(hp <= 0)
        {
            return true;
        }
        return false;
    }
    public void Dead(Vector3 pos, float force, float range)
    {
        hpBar.HpUpdate(0);
        isDead = true;
        nav.speed = 0;
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject.GetComponent<Rigidbody>());
        ragdoll.SetActive(true);
        character.SetActive(false);
        spine.AddExplosionForce(force * Random.Range(0.75f,1.25f), pos, range, 1, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }
}