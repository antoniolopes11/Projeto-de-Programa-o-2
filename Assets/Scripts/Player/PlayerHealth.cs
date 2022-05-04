using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int lifePoints = 100;

    [SerializeField]
    private UnityEvent OnDie;

    private int maxLifePoints;

    [SerializeField]
    private Image lifeBar = null;

    private bool isAlive = true;

    private bool canTakeDamage = true;

    private Animator playerAnimator = null;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        maxLifePoints = lifePoints;
        UpdateLifeBar();
    }

    private void UpdateLifeBar()
    {
        lifeBar.fillAmount = (float)lifePoints / maxLifePoints;
    }

    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            if (canTakeDamage)
            {
                lifePoints -= damage;
                playerAnimator.SetTrigger("Damage");
                UpdateLifeBar();
            }

            if (lifePoints < 0)
            {
                lifePoints = 0;
            }

            if(lifePoints == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isAlive = false;
        canTakeDamage = false;
        playerAnimator.SetTrigger("Die");
        OnDie.Invoke();
    }

    public void BecomeInvincible()
    {
        canTakeDamage = false;
    }
}
