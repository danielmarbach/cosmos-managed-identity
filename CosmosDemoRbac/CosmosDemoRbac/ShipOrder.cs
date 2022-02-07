using System;
using NServiceBus;

namespace CosmosDemoRbac
{
    public class ShipOrder :
    IMessage
    {
        public Guid OrderId { get; set; }
    }
}