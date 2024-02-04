using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChatController : MonoBehaviour
{
    public Transform chatHolder;
    public GameObject msgElement;
    public TMP_InputField playerMessage;
    Queue<GameObject> q = new Queue<GameObject>();
    // // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Console.WriteLine(q.Count);
            // if (q.Count == 6)
            // {
            //     Destroy(q.Dequeue());
            //     Debug.Log("Deleting");
            // }
            SendMessage();
        }
    }

    private void SendMessage()
    {
        GameObject msg = Instantiate(msgElement, chatHolder);
        Debug.Log("Adding");
        q.Enqueue(msg);
        msg.GetComponent<TextMeshProUGUI>().text = "Courage: " + playerMessage.text;
        playerMessage.text = "";
    }
}
