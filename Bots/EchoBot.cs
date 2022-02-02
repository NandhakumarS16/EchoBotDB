// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.15.0

using System;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EchoBotDB.Models;
using System.Text;


namespace EchoBotDB.Bots
{
    public class EchoBot : ActivityHandler

    {
        REGISTERUSERContext context;
        public REGISTERUSERContext Context { get { return context; } }
        public EchoBot()
        {
            context = new REGISTERUSERContext();
        }
        public Queries FetchResponse(string req)
        {
            // throw new NotImplementedException();
            Queries queries;

            

           // var check = context.Query.FirstOrDefault(s=> s.UserReq == req);

            try
            {
                queries = (from e in Context.Queries where e.Request == req select e).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            return queries;
        }

        public Userquery SetReq(string req)
        {
            Userquery _query;
            try
            {
                _query = (from e in Context.Userquery
                          where e.UserReq == req
                          select e).FirstOrDefault();
               // _query = context.Query.FirstOrDefault(s => s.UserReq == req);
                if (_query == null)
                {
                    _query = new Userquery();
                    _query.UserReq = req;
                    context.Userquery.Add(_query);
                    context.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
            return _query;
        }


        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
           // var replyText = $"Echo: {turnContext.Activity.Text}";
            var a = turnContext.Activity.Text;
            Queries queries = FetchResponse(a);
            if(queries != null)
            {
                var replyText = queries.Response;
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
            }
            else
            {


                var request = turnContext.Activity.Text;
                Userquery _req = SetReq(request);
                var replyText = "Sorry,I can't understand.Try after sometime.";
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
                
                return;
            }
        
           
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }

        
    }
}
