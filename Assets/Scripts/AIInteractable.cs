using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private LLMResponse llm;

    [SerializeField]
    private string landmarkName;

    [SerializeField]
    private GameState gs;

    public void Interact(Transform interactorTransform)
    {
        Debug.Log("HELP" + gs.location);
        gs.location = landmarkName;
        // call llm new message
        Debug.Log("Landmark name: " + gs.location);
        llm.NewLocation();
        transform.gameObject.SetActive(false);
    }

    public string GetInteractText()
    {
        return llm.GetInteractText();
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
