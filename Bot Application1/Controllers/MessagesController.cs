using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            Random Rnd = new Random(); // initialisiert die Zufallsklasse
            
           int x = Rnd.Next(1000,1400);
            UInt32 i = 0;
            while (i < 100000000*x)
            {
                i++;
            }
            i = 0;
            if (message.Type == "Message")
            {
                if(message.Text == "Hallo" || message.Text == "Hi")
                {
                    int Antwort = Rnd.Next(1, 8);
                    switch (Antwort)
                    {
                        case 1:
                            return message.CreateReplyMessage("Hi Wie gehts dir ?");
                            break;
                        case 2:
                            return message.CreateReplyMessage("Moin");
                            break;
                        case 3:
                            return message.CreateReplyMessage("Hi");
                            break;
                        case 4:
                            return message.CreateReplyMessage("Hallo");
                            break;
                        case 5:
                            return message.CreateReplyMessage("Na was machst du so ?");
                            break;
                        case 6:
                            return message.CreateReplyMessage("Was geht ab ?");
                            break;
                        case 7:
                            return message.CreateReplyMessage("Alles klar bei dir ?");
                            break;
                        case 8:
                            return message.CreateReplyMessage("Hallöchen");
                            break;
                        default:
                            return message.CreateReplyMessage("Hallo");
                            break;



                    }
                    

                }
                else if (message.Text == "Kannst du mir helfen ?")
                {
                    return message.CreateReplyMessage($"Nein");

                }
                else
                {       
                    // calculate something for us to return
                    int length = (message.Text ?? string.Empty).Length;

                    // return our reply to the user
                    //return message.CreateReplyMessage($"Du hast {length} Zeichen gesendet");
                     return message.CreateReplyMessage($"Sorry ich habe gerade keine Zeit ich meldem ich später nochmal ");

                }

            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}