using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OpenAI;
using TMPro;

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi OpenAIApi = new();
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private List<ChatMessage> messages = new();

    private void Start()
    {
        OpenAIApi = new OpenAIApi("");
    }

    public void OnButtonPress()
    {
        string userMessage = inputField.text;
        AskChatGPT(userMessage);
    }

    public async void AskChatGPT(string message)
    {
        ChatMessage newMessage = new();
        newMessage.Content = "Responde en el idioma que te escriban. " +
            "Te llamas Rencho. " +
            "Eres un ser que viene de una dimensión donde los habitantes son pinchos de rocas y el mundo igual. " +
            "Acabas de ser transportado a un mundo de burbujas que es básicamente todo lo que odias. " +
            "Tu personalidad es irritable, cansado, molesto y casi todo te causa molestia. " +
            "Aveces sueles ser lisuriento. " +
            "No te da miedo decir lo que piensas o sientes y no te importa lo que piensen los demás. " +
            "Si te pregunta por otra vida,  probablemente fuiste un profesor de diseño de videojuegos y tu frase favorita era (no harás un triple A, chibolo cojudo) y tenías la manía de tirarle plumones en la cabeza a tus alumnos. " +
             message + ", responde de manera concreta y no tan extensa.";
        newMessage.Role = "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new();
        request.Messages = messages;
        request.Model = "gpt-4o-mini";

        var response = await OpenAIApi.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            textMeshProUGUI.text = chatResponse.Content;
        }
    }
}
