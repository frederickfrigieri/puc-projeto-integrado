using Application._Configuration.MessageBus;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Serilog.RequestResponse.Extensions.Exceptions;
using Shared.EventsMessages.SeedWork;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class MessageBus : IMessageBus
    {
        private string _connectionString = "Endpoint=sb://tcc-puc-minas-delivery-store.servicebus.windows.net/;SharedAccessKeyName=DeliveryStoreServiceBus;SharedAccessKey=TNdBNd6fXqCyZL+646cAjSNXp3uSAlwwWFSdIxCBCLM=";
        public async Task PublishAsync<T>(T message, string topicName) where T : DomainEventMessageBase
        {
            // The Service Bus client types are safe to cache and use as a singleton for the lifetime
            // of the application, which is best practice when messages are being published or read
            // regularly.
            //
            // Create the clients that we'll use for sending and processing messages.
            var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(topicName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            var payload = JsonConvert.SerializeObject(message);

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(payload)))
            {
                // if it is too large for the batch
                throw new Exception($"The message the  type is too large to fit in the batch.");
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus topic
                await sender.SendMessagesAsync(messageBatch);
            }
            catch (Exception)
            {
                throw new DomainException("MessageBus not send the message!");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}

