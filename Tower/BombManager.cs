using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public float range;
    public GameObject effect;
    GameObject[] Enemylist;
    public float damage;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "Ground")
        {
            Enemylist = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemy in Enemylist)
            {
                var target = Enemy.GetComponent<LivingEntity>();
                if (Enemy.GetComponent<Transform>().position.y > 1)
                    continue;

                distance = (Enemy.GetComponent<Transform>().position - transform.position).magnitude;
                if (distance < range)
                {
                    Debug.Log(Enemy.name);
                    // ContactPoint contact = col.contacts[0];
                    var message = new DamageMessage();
                    message.amount = damage;
                    message.damager = gameObject;
                    message.hitPoint = target.transform.position;
                    message.hitNormal = transform.position - target.transform.position;
                    // Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.norm);
                    target.ApplyDamage(message);
                }
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
