using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;

namespace Siliconvalve.FunctionDemo01
{
    /// <summary>
    /// Quote Emailer Function
    /// </summary>
    /// <remarks>Listens for new documents in Cosmos DB, and when one is created, reads it and then sends email to the recipient listed in the incoming message.</remarks>
    public static class QuoteEmailer
    {
        [FunctionName("QuoteEmailer")]
        public static void Run([CosmosDBTrigger(
            databaseName: "quotedemo",
            collectionName: "quotes",
            ConnectionStringSetting = "CosmosConnection",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, [SendGrid(From = "%NotificationsSender%")] out SendGridMessage message, TraceWriter log)
        {
            var messageRecipient = input[0].GetPropertyValue<string>("recipient");
            var messageBody = input[0].GetPropertyValue<string>("quote");

            message = new SendGridMessage();
            message.AddContent("text/plain", messageBody);
            message.AddTo(messageRecipient);
            message.Subject = "Funny Quote of the day";
        }
    }
}