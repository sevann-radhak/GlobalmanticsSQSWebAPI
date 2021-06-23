using Amazon.SQS;
using Amazon.SQS.Model;
using GlobalmanticsSQSWebAPI.Interfaces;
using GlobalmanticsSQSWebAPI.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalmanticsSQSWebAPI.Services
{
    public class SQSService : ISQSService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly AWS _settings;

        public SQSService(IAmazonSQS sqsClient,
            IOptions<AWS> settings)
        {
            _sqsClient = sqsClient;
            _settings = settings.Value;
        }

        public async Task<SendMessageResponse> SendMessageToQueueAsync(TicketRequest dto)
        {
            SendMessageRequest message = new()
            {
                MessageBody = SerializeRequest(dto),
                QueueUrl = _settings.QueueUrl
            };

            return await _sqsClient.SendMessageAsync(message);
        }

        private static string SerializeRequest(TicketRequest dto)
        {
            return JsonSerializer.Serialize(dto);
        }
    }
}
