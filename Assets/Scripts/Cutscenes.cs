using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour, ILocationInteractable
{
    public bool cut1played = false;
    public GameObject pCam;
    public GameObject c1cam;
    // Start is called before the first frame update
    void Start()
    {
        pCam.SetActive(true);
        c1cam.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("Interact");
        if (cut1played == false)
            StartCoroutine(seq());
    }

    IEnumerator seq()
    {
        cut1played = true;
        pCam.SetActive(false);
        c1cam.SetActive(true);
        yield return new WaitForSeconds(6);
        pCam.SetActive(true);
        c1cam.SetActive(false);
        transform.gameObject.SetActive(false);
    }

    public Transform GetTransform()
    {
        return transform;
    }

}
