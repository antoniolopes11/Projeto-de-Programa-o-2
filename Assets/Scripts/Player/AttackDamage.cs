using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 20;

    private float lifeTime = 2f;

    private void Start()
    {
        Invoke(nameof(Dismiss), lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<SculptureHealth>().TakeDamage(damage);
        }
    }

    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
