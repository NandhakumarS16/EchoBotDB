//using System;
//using System.Threading.Tasks;
//using Microsoft.Bot.Builder.Models;
//using Microsoft.Bot.Connector;

//namespace EchoBotDB.Models
//{
//    [Serializable]
//    public class SpeechDialog : IDialog<object>

//    {
//        public Task StartAsync(IDialogContext context)
//        {
//            context.Wait(MessageReceivedAsync);
//        }

//        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
//        {
//            var activity = context.Activity as Activity;
//            Activity reply = activity.CreateReply(@"HIIII");
//            reply.Speak = " yess";
//            await context.PostAsnc(reply);
//        }
//    }
//}
