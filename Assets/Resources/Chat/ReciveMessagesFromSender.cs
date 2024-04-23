using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.scripts.Public.Chat
{
    public class ReciveMessagesFromSender : MonoBehaviour
    {
                    [SerializeField]
                    private GameObject showMessagesParent;
                    [SerializeField]
                    private GameObject showMessageSenderPrefab;
                    [SerializeField]
                    private GameObject showMessageReciverPrefab;
                    [SerializeField]
                    private ChatUi mainChatUi = null;

                    private List<Message> Messages = new List<Message>();

            private void OnEnable()
            {
                // Connect to server
                //...
        
                // Load messages from JSON file
                
                // Get text input and send button components
                if(mainChatUi != null)
                    if(showMessagesParent)
                        if(showMessageSenderPrefab && showMessageReciverPrefab)
                        {
                            LoadMessages(showMessagesParent,showMessageSenderPrefab,showMessageReciverPrefab);
                        }
            }

            private void Start()
            {
            
                // Connect to server
                //...
        
                // Load messages from JSON file
                
                // Get text input and send button components
                if(mainChatUi != null)
                    if(showMessagesParent)
                        if(showMessageSenderPrefab && showMessageReciverPrefab)
                        {
                            LoadMessages(showMessagesParent,showMessageSenderPrefab,showMessageReciverPrefab);
                        }
            
            }


            private void LoadMessages(GameObject showMessagesParent,GameObject showMessageSenderPrefab,GameObject showMessageReciverPrefab)
        {
            //get all messages from json or server
            this.Messages = this.mainChatUi.getAllMessages();
            
            //add all messages to ui
            if (this.Messages.Count > 0)
            {
                this.clearUi();
                this.Messages.ForEach((messageT) =>
                {
                    if (messageT.sender == "username")
                    {
                        GameObject GTemp = Instantiate(showMessageSenderPrefab, showMessagesParent.transform);
                        if (GTemp.TryGetComponent(out Text T))
                        {
                            T.text = messageT.message;
                            GTemp.SetActive(true);
                        }
                        else if (GTemp.TryGetComponent(out TMP_Text TMP))
                        {
                            TMP.text = messageT.message;
                            GTemp.SetActive(true);
                        }else if (GTemp.GetComponentInChildren<Text>())
                        {
                            GTemp.GetComponentInChildren<Text>().text = messageT.message;
                            GTemp.SetActive(true);
                        }
                        else if (GTemp.GetComponentInChildren<TMP_Text>())
                        {
                            GTemp.GetComponentInChildren<TMP_Text>().text = messageT.message;
                            GTemp.SetActive(true);
                        }else
                        {
                            Destroy(GTemp);
                        }
                        
                    }
                    else
                    {
                        GameObject GTemp = Instantiate(showMessageReciverPrefab, showMessagesParent.transform);
                        if (GTemp.TryGetComponent(out Text T))
                        {
                            T.text = messageT.message;
                            GTemp.SetActive(true);
                        }
                        else if (GTemp.TryGetComponent(out TMP_Text TMP))
                        {
                            TMP.text = messageT.message;
                            GTemp.SetActive(true);
                        }else if (GTemp.GetComponentInChildren<Text>())
                        {
                            GTemp.GetComponentInChildren<Text>().text = messageT.message;
                            GTemp.SetActive(true);
                        }
                        else if (GTemp.GetComponentInChildren<TMP_Text>())
                        {
                            GTemp.GetComponentInChildren<TMP_Text>().text = messageT.message;
                            GTemp.SetActive(true);
                        }else
                        {
                            Destroy(GTemp);
                        }
                    }

                });
            }



        }

            private void clearUi()
            {
                if (showMessagesParent != null)
                {
                    for (int i = 0; i < showMessagesParent.transform.childCount; i++)
                    {
                        Destroy(showMessagesParent.transform.GetChild(i).gameObject);    
                    }

                    
                }
            }
            private void OnDestroy()
            {
                // Disconnect from server
                //...
        
                // Save messages to JSON file
                clearUi();
            }

            private void Update()
            {
                if(mainChatUi != null)
                    if(showMessagesParent != null)
                        if (showMessageSenderPrefab != null && showMessageReciverPrefab != null)
                        {
                            if (mainChatUi.getAllMessages().Count > 0)
                            {
                                
                                    this.LoadMessages(showMessagesParent, showMessageSenderPrefab,
                                        showMessageReciverPrefab);
                                }
                        }
            }
    }
}