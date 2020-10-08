using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys =  new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }
    public float attackRateTime = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;
    void Start()
    {
        timer = attackRateTime;
    }
    void Update()
    {
        UpdateEnemys();
        if (enemys.Count > 0)
        {
            timer += Time.deltaTime;
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        else timer = attackRateTime;
        if (timer >= attackRateTime && enemys.Count > 0)
        {
            timer -= attackRateTime;
            Attack();
        }
    }
    void Attack()
    {
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
    }
    void UpdateEnemys()
    {
        for(int index = enemys.Count - 1; index >= 0; --index)
        {
            if (enemys[index] == null)  enemys.RemoveAt(index);
        }
    }
}
