using System;
using NServiceBus;

namespace CosmosDemoRbac
{
    public class OrderSagaData :
    ContainSagaData
    {
        public Guid OrderId { get; set; }
        public string OrderDescription { get; set; }
    }
}