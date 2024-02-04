using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text.RegularExpressions;

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}

[System.Serializable]
public class ChatResponse
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

public class LLMResponse : MonoBehaviour
{
    // Replace this with your API endpoint
    private string apiUrl = "http://th3machine.com/api/chat";

    // Class that represents a persistent conversation (to the llm)
    [SerializeField]
    private string systemPrompt = "";


    [SerializeField]
    private string interactText = "Message from ";

    [SerializeField]
    private GameState gs;

    [SerializeField]
    private RoverText roverText;

    [SerializeField]
    private Sprite roverSprite;

    public string GetInteractText()
    {
        return interactText;
    }

    private string LatestResponse = "";
    public string GetLatestResponse()
    {
        return LatestResponse;
    }

    public string SystemPrompt
    {
        get { return systemPrompt; }
        set { systemPrompt = value; }
    }

    private string conversation = "";

    public string Conversation
    {
        get { return conversation; }
        set { conversation = value; }
    }

    public void InitMessage()
    {
        Conversation = "{\"role\":\"system\",\"content\":\"" + SystemPrompt + "\"}";
    }

    public void NewMessage(string newMessage)
    {
        Conversation = Conversation + ",{\"role\":\"user\",\"content\":\"" + newMessage + "\"}";
    }

    private void NewServerMessage(string newMessage)
    {
        Conversation = Conversation + ",{\"role\":\"assistant\",\"content\":\"" + newMessage + "\"}";
    }

    public string CreateBody(string messages)
    {
        string modelKV = @"""model"": ""mistral:7b-instruct-q5_K_M""";
        string streamKV = @"""stream"" : false";

        return "{" + modelKV + @",""messages"":[" + messages + @"]," + streamKV + "}";
    }

    private string PostRequest(string body)
    {
        return "";
    }

    public void GetMessage(string newMessage)
    {
        NewMessage(newMessage);
    }

    /*
    // Example data to send in the POST request
    private string postData = @"{
  ""model"": ""mistral:7b-instruct-q5_K_M"",
  ""messages"": [
    {
      ""role"": ""user"",
      ""content"": ""why is the sky blue?""
    },
    {
      ""role"": ""assistant"",
      ""content"": ""due to rayleigh scattering.""
    },
    {
      ""role"": ""user"",
      ""content"": ""how is that different than mie scattering?""
    }
  ],
  ""stream"" : false
}
";
    */

    // Start is called before the first frame update
    void Start()
    {
        InitMessage();
        StartCoroutine(MakePostRequest(apiUrl, "Hey dad."));
        //StartCoroutine(MakePostRequest(apiUrl, "I'm not feeling too good."));
    }

    public void NewLocation()
    {

        StartCoroutine(MakePostRequest(apiUrl, "I just passed by " + gs.location));
    }

    IEnumerator MakePostRequest(string url, string newMessage)
    {
        NewMessage(newMessage);
        Debug.Log(Conversation);
        // Convert JSON data to bytes
        string body = CreateBody(Conversation);
        Debug.Log(body);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(body);

        // Create a UnityWebRequest object
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(url, "POST"))
        {
            // Set the request headers
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.timeout = 60;
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
                    Debug.Log(responseData.model+ " Role: "+ responseData.message.role + "Response Value: " + responseData.message.content);
                    LatestResponse = responseData.message.content;
                    LatestResponse = Regex.Replace(LatestResponse, @"\t|\n|\r", "");
                    NewServerMessage(LatestResponse);
                    roverText.NewMessage(LatestResponse, roverSprite);
                }
                else
                {
                    Debug.LogError("Failed to parse JSON response or missing 'response' key.");
                }
            }
        }
    }

}
