using Newtonsoft.Json;

namespace Resources.scripts.Public.Chat
{
    
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;

    [System.Serializable]
    public class Message
    {
        public string sender;
        public string receiver;
        public string message;
        public string timestamp;
    }

    public class ChatUi : MonoBehaviour
    {
        public string username = "username";
        public string password;
        public string serverAddress;
        public int serverPort;

        public List<Message> messages = new List<Message>();
        public string dataPath;

        private void Start()
        {
            // Connect to server
            //...

            // Load messages from JSON file
            
            dataPath = Path.Combine(Application.dataPath, "Data/Chat");
            // dataPath = Path.Combine(Application.persistentDataPath, "Data");
            // Debug.LogError(dataPath);
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            LoadFileData();
            // string json = File.ReadAllText("messages.json");
            // messages = JsonUtility.FromJson<List<Message>>(json);
        }
        public void LoadFileData()
        {
            if (!(messages.Count > 0))
            {
                string jsonPath = Path.Combine(dataPath, "messages.jn");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    json = json.DeCoderBaseUTF8();
                    messages = JsonConvert.DeserializeObject<List<Message>>(json);
                }
                else
                {
                    messages = new List<Message>();
                }
            }
        }
        public void SaveFileData()
        {
            string json = JsonConvert.SerializeObject(messages);
            File.WriteAllText(Path.Combine(dataPath, "messages.jn"), json.EnCoderBaseUTF8());
        }
        private void OnDestroy()
        {
            // Disconnect from server
            //...

            // Save messages to JSON file
            // string json = JsonUtility.ToJson(messages);
            // File.WriteAllText("messages.json", json);
            SaveFileData();
        }

        public void SendMessageToResiver(string receiver, string message)
        {
            // Send message to server
            //...

            // Add message to list
            Message newMessage = new Message();
            newMessage.sender = username;
            newMessage.receiver = receiver;
            newMessage.message = message;
            newMessage.timestamp = System.DateTime.Now.ToString();
            this.messages.Add(newMessage);
            
            SaveFileData();
        }

        public void ReceiveMessageFromSender(Message message)
        {
            // Add message to list
            this.messages.Add(message);
        }
        public List<Message> getAllMessages()
        {
            return this.messages;
        }
        
    }

}