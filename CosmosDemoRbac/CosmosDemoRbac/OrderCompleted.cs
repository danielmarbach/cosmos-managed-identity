using System;
using NServiceBus;

namespace CosmosDemoRbac
{
    public class OrderCompleted :
    IEvent
    {
        public Guid OrderId { get; set; }
    }
}