using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public bool jump;
    public bool attack;
    public bool interact;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            attack = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interact = true;
        }
    }
}
