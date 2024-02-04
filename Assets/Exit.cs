using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");

    }
}
