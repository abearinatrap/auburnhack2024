using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoverText : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TextMeshProUGUI missionTextMeshProUGUI;
    [SerializeField] public SpriteRenderer image;


    /*
    void Start()
    {
        StartCoroutine(Thoughts());
    }
    */

    public void NewMessage(string text, Sprite nimage)
    {
        missionTextMeshProUGUI.text = text;
        image.sprite = nimage;
        StartCoroutine(Thoughts());
    }

    IEnumerator Thoughts()
    {
        containerGameObject.SetActive(true);
        yield return new WaitForSeconds(15);
        //yield return null
        containerGameObject.SetActive(false);

    }
};
