using System;
using NServiceBus;

namespace CosmosDemoRbac
{
    public class StartOrder :
    IMessage
    {
        public Guid OrderId { get; set; }
    }
}