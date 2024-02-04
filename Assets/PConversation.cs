using UnityEngine;

[CreateAssetMenu(fileName = "NewStringData", menuName = "Custom/String Data")]
public class PConversation : ScriptableObject
{
    // Class that represents a persistent conversation (to the llm)
    [SerializeField]
    private string systemPrompt = "";

    public string SystemPrompt
    {
        get { return systemPrompt; }
        set { systemPrompt = value; }
    }

    [SerializeField]
    private string stringValue = "";

    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }

    public void InitMessage()
    {
        StringValue = "{\"role\":\"system\",\"content\":\"" + SystemPrompt + "\"}";
    }

    public void NewMessage(string newMessage)
    {
        StringValue = StringValue + ",{\"role\":\"user\",\"content\":\"" + newMessage + "\"}";
    }

    public string CreateBody(string messages)
    {
        string modelKV = @"""model"": ""mistral:7b-instruct-q5_K_M""";
        string streamKV = @"""stream"" : false";

        return "{"+modelKV+@",""messages"":[" + messages + @"]," + streamKV;
    }

    private string PostRequest(string body)
    {

        return "";
    }

    public void SendMessage(string newMessage)
    {
        NewMessage(newMessage);
    }

  
}