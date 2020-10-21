using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Azure.Messaging.Replication;

namespace EventHubToEventHubCopy
{
    public static class Tasks
    {
        [FunctionName("Eh1ToEh2")]
        public static Task Eh1ToEh2(
            [EventHubTrigger("eh1", ConsumerGroup = "Eh1ToEh2", Connection = "Eh1ToEh2-source-connection")] EventData[] input,
            [EventHub("eh2", Connection = "Eh1ToEh2-target-connection")] IAsyncCollector<EventData> output,
            ILogger log)
        {
            return EventHubReplicationTasks.ForwardToEventHub(input, output, log);
        }
    }
}
