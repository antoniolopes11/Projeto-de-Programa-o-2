using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int lifePoints = 100;

    private int maxLifePoints;

    [SerializeField]
    private Image lifeBar = null;

    private bool isAlive = true;

    private void Awake()
    {
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
            lifePoints -= damage;

            if (lifePoints < 0)
            {
                lifePoints = 0;
            }

            UpdateLifeBar();

            if(lifePoints == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isAlive = false;
    }
}
