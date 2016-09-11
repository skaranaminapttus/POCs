using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJobForClarification
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            Trace.TraceInformation(DateTime.Now+":-Data received from the call: "+message);
            Trace.TraceInformation($"{DateTime.Now}:-Starting reading the Data from the storage");
            Trace.TraceInformation($"{DateTime.Now}:-Read complete");
            Trace.TraceInformation($"{DateTime.Now}:-Starting processing of the data");
            Trace.TraceInformation($"{DateTime.Now}:-Completed processing of the data");
            Trace.TraceInformation($"{DateTime.Now}:-Starting to write results to database");
            Trace.TraceInformation($"{DateTime.Now}:-Completed writing results to database");
            log.WriteLine(message);
        }
    }
}
