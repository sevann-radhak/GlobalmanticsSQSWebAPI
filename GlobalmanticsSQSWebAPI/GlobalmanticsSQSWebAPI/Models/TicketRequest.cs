using System;

namespace GlobalmanticsSQSWebAPI.Models
{
    public class TicketRequest
    {
        public Guid Id { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }
    }
}
