using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Concurrent;
using System;

public class RoverText : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TextMeshProUGUI missionTextMeshProUGUI;
    [SerializeField] public SpriteRenderer image;

    ConcurrentQueue<Tuple<string, Sprite>> messages;
    
    void Start()
    {
        StartCoroutine(Thoughts());
    }
    

    public void NewMessage(string text, Sprite nimage)
    {
        messages.Enqueue(Tuple.Create(text, nimage));
        //StartCoroutine(Thoughts());
    }

    IEnumerator Thoughts()
    {
        while (true)
        {
            Tuple<string, Sprite> result;
            if (messages.TryDequeue(out result))
            {
                missionTextMeshProUGUI.text = result.Item1;
                image.sprite = result.Item2;
                containerGameObject.SetActive(true);
                yield return new WaitForSeconds(result.Item1.Length/14);
                //yield return null
                containerGameObject.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(3);
            }
        }
        
        
    }
};
