using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite[] sprites = null;

    private bool switchOff = true;

    [SerializeField]
    private GameObject objectToLink;

    private IActivable linkedObject = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        linkedObject = objectToLink.GetComponent<IActivable>();
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
        if (switchOff)
        {
            Enable();
        }
    }

    private void Enable()
    {
        switchOff = false;
        linkedObject.Activate();
        spriteRenderer.sprite = sprites[1];

    }
}
