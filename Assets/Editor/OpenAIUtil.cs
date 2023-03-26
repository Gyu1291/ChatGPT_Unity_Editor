using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Text;

namespace AICommand {

static class OpenAIUtil
{
    static string CreateChatRequestBody(string prompt)
    {
        var msg = new OpenAI.RequestMessage();
        msg.role = "user";
        msg.content = prompt; //prompt

        var req = new OpenAI.Request();
        req.model = "gpt-3.5-turbo";
        req.messages = new [] { msg };

        return JsonUtility.ToJson(req);
    }

    public static string InvokeChat(string prompt)
    {
        var settings = AICommandSettings.instance;
        using var post = UnityWebRequest.Post(OpenAI.Api.Url, CreateChatRequestBody(prompt)); //, "application/json"

        byte[] sendData = new UTF8Encoding().GetBytes(CreateChatRequestBody(prompt));
        post.uploadHandler = new UploadHandlerRaw(sendData);
            // Request timeout setting
        post.timeout = settings.timeout;

            // API key authorization
        post.SetRequestHeader("Content-Type", "application/json");
        post.SetRequestHeader("Authorization", "Bearer " + settings.apiKey);

        // Request start
        var req = post.SendWebRequest();

        // Progress bar (Totally fake! Don't try this at home.)
        for (var progress = 0.0f; !req.isDone; progress += 0.01f)
        {
            EditorUtility.DisplayProgressBar
              ("AI Command", "Generating...", progress);
            System.Threading.Thread.Sleep(100);
            progress += 0.01f;
        }
        EditorUtility.ClearProgressBar();

        // Response extraction
        var json = post.downloadHandler.text;
            Debug.Log($"{post.downloadHandler.text}");
        var data = JsonUtility.FromJson<OpenAI.Response>(json);
            Debug.Log($"{data}");
            Debug.Log($"{data.choices[0].message.content}");
            return data.choices[0].message.content;
    }
}

} // namespace AICommand
