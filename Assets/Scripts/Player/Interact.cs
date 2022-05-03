using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private IInteractable interactableObject;

    private PlayerInput inputController;

    private bool canInteract = true;

    private void Awake()
    {
        inputController = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if(inputController.interact && canInteract)
        {
            inputController.interact = false;
            if(interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }

    public void EnableInteraction()
    {
        canInteract = true;
    }

    public void DisableInteraction()
    {
        canInteract = false;
    }

    public void SetInteractable (IInteractable objectToAssign)
    {
        interactableObject = objectToAssign;
    }
}
