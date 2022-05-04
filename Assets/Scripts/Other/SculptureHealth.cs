using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SculptureHealth : MonoBehaviour
{
    private int maxLifePoints;

    [SerializeField]
    private int lifePoints = 100;

    [SerializeField]
    private Image sculptureHealth = null;

    [SerializeField]
    private UnityEvent OnDie;

    private void Awake()
    {
        maxLifePoints = lifePoints;
        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        lifePoints -= damage;
        UpdateHealth();

        if(lifePoints < 0)
        {
            lifePoints = 0;
        }

        if(lifePoints == 0)
        {
            OnDie.Invoke();
        }
    }

    private void UpdateHealth()
    {
        sculptureHealth.fillAmount = (float)lifePoints / maxLifePoints;
    }
}
