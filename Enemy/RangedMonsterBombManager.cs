using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonsterBombManager : MonoBehaviour
{
    private GameObject targetEntity;
    public float damage = 2.0f;
    public float flytime;
    float deltaTime;
    
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Enter");
        //targetEntity = GameObject.Find("Base");
        GameObject target = collision.gameObject;
        
        ContactPoint contact = collision.contacts[0];
        Vector3 hitPoint =  contact.point;       // Player가 공격 받는 포지션
        Vector3 hitNormal = contact.normal;  // Player가 공격 받는 포지션의 노말
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);

        if (target.CompareTag("Base") || target.CompareTag("Tower"))
        {
            //Debug.Log("Damage the base");
            LivingEntity entity = target.GetComponent<LivingEntity>();
            entity.OnDamage(damage, hitPoint, hitNormal);
            
        }
        
        Instantiate(bombEffect, hitPoint, rot);
        Destroy(gameObject);
        
    }

    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime > flytime)
        {
            Destroy(this.gameObject);
        }
    }
    
}
