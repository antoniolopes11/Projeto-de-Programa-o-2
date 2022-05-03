using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private IInteractable interactableObject;

    private bool canInteract = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& canInteract)
        {
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
