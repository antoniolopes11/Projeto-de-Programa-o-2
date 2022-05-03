using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite[] sprites = null;

    [SerializeField]
    private GameObject lightBeam = null;

    private bool boxOff = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interaction>().SetInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interaction>().SetInteractable(null);
        }
    }

    public void Interact()
    {
        if (boxOff)
        {
            EnableBeam();
        }
        else
        {
            DisableBeam();
        }
        
    }

    private void EnableBeam()
    {
        lightBeam.SetActive(true);
        spriteRenderer.sprite = sprites[1];
        boxOff = false;
    }

    private void DisableBeam()
    {
        lightBeam.SetActive(false);
        spriteRenderer.sprite = sprites[0];
        boxOff = true;
    }
}
