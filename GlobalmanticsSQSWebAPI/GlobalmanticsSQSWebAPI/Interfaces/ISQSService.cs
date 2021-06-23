using Amazon.SQS.Model;
using GlobalmanticsSQSWebAPI.Models;
using System.Threading.Tasks;

namespace GlobalmanticsSQSWebAPI.Interfaces
{
    public interface ISQSService
    {
        public Task<SendMessageResponse> SendMessageToQueueAsync(TicketRequest dto);
    }
}
