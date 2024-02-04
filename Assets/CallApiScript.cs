using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[System.Serializable]
public class dMessage
{
    public string role;
    public string content;
}

[System.Serializable]
public class dChatResponse
{
    public string model;
    public string created_at;
    public Message message;
    public bool done;
    public long total_duration;
    public long load_duration;
    public long prompt_eval_count;
    public long prompt_eval_duration;
    public long eval_count;
    public long eval_duration;
}

public class ApiCaller : MonoBehaviour
{
    // Replace this with your API endpoint
    private string apiUrl = "http://th3machine.com/api/generate";

    // Example data to send in the POST request
    private string postData = "{\"model\": \"mistral:7b-instruct-q5_K_M\",\"prompt\": \"balls in my mouth\",\"stream\": false}";


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakePostRequest(apiUrl, postData));
    }

    IEnumerator MakePostRequest(string url, string jsonData)
    {
        // Convert JSON data to bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Create a UnityWebRequest object
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(url, "POST"))
        {
            // Set the request headers
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Set the request data
            webRequest.uploadHandler = new UploadHandlerRaw(postData);

            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            // Check for errors
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                ChatResponse responseData = JsonUtility.FromJson<ChatResponse>(webRequest.downloadHandler.text);

                // Check if the "response" key exists
                if (responseData != null)
                {
                    // Print the value of the "response" key
                    Debug.Log("Response Value: " + responseData.message.content);
                }
                else
                {
                    Debug.LogError("Failed to parse JSON response or missing 'response' key.");
                }
            }
        }
    }

}
