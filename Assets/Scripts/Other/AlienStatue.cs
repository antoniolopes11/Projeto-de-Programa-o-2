using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class AlienStatue : MonoBehaviour, IInteractable, IActivable
{
    [SerializeField]
    private GameObject triangle = null;

    private GameObject[] alienSigns;

    private List<bool> alienSignsOn = new List<bool>();

    [SerializeField]
    private TMP_Text congratsText = null;

    private bool canInteract = false;

    [SerializeField]
    private UnityEvent OnEnable;

    [SerializeField]
    private UnityEvent OnInteract;

    private void Awake()
    {
        alienSigns = GameObject.FindGameObjectsWithTag("Alien Sign");

        for (int i = 0; i < alienSigns.Length; i++)
        {
            alienSignsOn.Add(false);
        }
        alienSignsOn.ToArray();
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
        if (canInteract)
        {
            OnInteract.Invoke();
            congratsText.gameObject.SetActive(true);
        }
    }

    public void Activate()
    {
        for (int i = 0; i < alienSigns.Length; i++)
        {
            if (alienSignsOn[i] == false)
            {
                alienSignsOn[i] = true;
                break;
            }
            else
            {
                triangle.SetActive(true);
                OnEnable.Invoke();
                canInteract = true;
            }
        }
    }

    public void Deactivate()
    {
        triangle.SetActive(false);
    }

}
