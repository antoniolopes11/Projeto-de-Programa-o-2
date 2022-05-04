using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSign : MonoBehaviour, IActivable
{
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Activate()
    {
        spriteRenderer.sprite = sprites[1];
    }

    public void Deactivate()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
