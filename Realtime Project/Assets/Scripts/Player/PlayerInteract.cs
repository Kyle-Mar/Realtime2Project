using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Camera Cam;

    private void Awake()
    {
        Cam = Camera.main;
    }
    public void Interact()
    {
        LayerMask layerMask = ~LayerMask.GetMask("Player");
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, 5f, layerMask))
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}
