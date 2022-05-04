using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    private Animator playerAnimator = null;

    private PlayerInput playerInput;

    [SerializeField]
    private Transform attackRange = null;

    [SerializeField]
    private GameObject attackHit = null;

    private GameObject attack= null;

    [SerializeField]
    private UnityEvent OnAttack;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.attack)
        {
            Swing();
        }
    }

    private void Swing()
    {
        OnAttack.Invoke(); 
        playerAnimator.SetTrigger("Attack");
        playerInput.attack = false;
        attack = Instantiate(attackHit, attackRange.position, attackRange.rotation);
    }

    public void Dismiss()
    {
        Destroy(attack);
    }
}
