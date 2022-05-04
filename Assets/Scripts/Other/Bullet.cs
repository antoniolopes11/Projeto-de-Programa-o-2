using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 40;

    [SerializeField]
    private float bulletLifeTime = 3f;

    private void Start()
    {
        Invoke(nameof(Dismiss), bulletLifeTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Dismiss();
        }
    }
    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
