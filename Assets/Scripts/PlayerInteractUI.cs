using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private RoverInteract roverInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        if (roverInteract.GetInteractableObject() != null)
        {
            Show(roverInteract.GetInteractableObject());
        }
        else
        {
            Hide(roverInteract.GetInteractableObject());
        }
    }
    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();

    }

    private void Hide(IInteractable interactable)
    {
        containerGameObject.SetActive(false);
    }
}
