using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSign : MonoBehaviour, IActivable
{
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    private GameObject objectToLink = null;

    private IActivable linkedObject = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        linkedObject = objectToLink.GetComponent<IActivable>();
    }
    public void Activate()
    {
        linkedObject.Activate();
        spriteRenderer.sprite = sprites[1];
    }

    public void Deactivate()
    {
        linkedObject.Deactivate();
        spriteRenderer.sprite = sprites[0];
    }
}
