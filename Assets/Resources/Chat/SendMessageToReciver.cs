using UnityEngine;
using UnityEngine.UI;

namespace Resources.scripts.Public.Chat
{
    public class SendMessageToReciver:MonoBehaviour
    {
            [SerializeField]
            private InputField inputField;
            [SerializeField]
            private Button sendButton;
            [SerializeField]
            private ChatUi mainChatUi;

    private void OnEnable()
    {
        // Connect to server
        //...

        // Load messages from JSON file
        
        // Get text input and send button components
        if(inputField == null)
        {
            inputField = GetComponentInChildren<InputField>();
        }

        if (sendButton == null)
        {
            sendButton = GetComponentInChildren<Button>();
        }

        // Add event listener to send button
        if(sendButton != null)
            sendButton.onClick.AddListener(SendMessage);
        if(inputField != null)
            inputField.text = "";
        
    }



    private void OnDestroy()
    {
        // Disconnect from server
        //...

        // Save messages to JSON file
        if (sendButton != null)
        {
            sendButton.onClick.RemoveAllListeners();
        }
    }

    public void SendMessage()
    {
        // Get message from text input
        string message = inputField.text;

        // Send message to server
        //...

        // Add message to list
        if(! string.IsNullOrEmpty(message))
            mainChatUi.SendMessageToResiver("All",message);

        // Clear text input
        inputField.text = "";
        
    }
    }
}