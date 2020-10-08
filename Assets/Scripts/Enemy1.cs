using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    public float speed = 50;
    public int hp = 150;
    private int totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        positions = Waypoints.positions;
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            ++index;
        }
        if(index > positions.Length - 1)
        {
            ReachDestination();
        }
    }
    void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }
    void OnDestroy()
    {
        --Enemy_Spawner.countEnemyAlive;
    }
    public void TakeDamage(int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = 1.0f * hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }
}
