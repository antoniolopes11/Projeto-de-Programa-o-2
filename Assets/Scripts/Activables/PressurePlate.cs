using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, IActivable
{
    private SpriteRenderer spriteRenderer = null;

    private bool offPlate = true;

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    private GameObject objectToLink = null;

    private int onTopOfPlatform = 0;

    private IActivable linkedActivable = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        linkedActivable = objectToLink.GetComponent<IActivable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTopOfPlatform++;
        if (offPlate)
        {
            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTopOfPlatform--;
        //checks if there aren't any objects on the platform in order to deactivate it
        if (!offPlate && onTopOfPlatform == 0) 
        {
            Deactivate();
        }
    }


    public void Activate()
    {
        spriteRenderer.sprite = sprites[0];
        offPlate = false;
        linkedActivable.Activate();
    }

    public void Deactivate()
    {
        spriteRenderer.sprite = sprites[1];
        offPlate = true;
        linkedActivable.Deactivate();
    }
}
