using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public bool cut1played = false;
    public GameObject pCam;
    public GameObject c1cam;

    public AudioSource cam;
    public GameObject pic;
    [SerializeField]
    private string interactText = "Pick me up";
    public void Interact(Transform interactorTransform)
    {
        if (cut1played == false)
            StartCoroutine(seq());
    }

    public GameObject wp;
    IEnumerator seq()
    {
        if (pCam != null)
        {
            wp.SetActive(false);
            cut1played = true;
            pCam.SetActive(false);
            c1cam.SetActive(true);
            yield return new WaitForSeconds(6);
            pCam.SetActive(true);
            c1cam.SetActive(false);
        }
        cam.Play();
        pic.SetActive(true);
        yield return new WaitForSeconds(5);
        pic.SetActive(false);
        transform.gameObject.SetActive(false);
    }
    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
