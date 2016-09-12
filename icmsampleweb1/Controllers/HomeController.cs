using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace icmsampleweb1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        [Route("home/startclassification/{somedata}")]
        public string StartClassification(string somedata)
        {
            TriggerWebjob(somedata);

            return "Deployment2:- Triggered classification job successfully at:" + DateTime.Now;
        }

        private static void TriggerWebjob(string somedata)
        {
            var storgaeAccout = GetStorgaeAccout();

            var queueClient = storgaeAccout.CreateCloudQueueClient();

            var queueReference = queueClient.GetQueueReference("queue");

            queueReference.CreateIfNotExists();

            queueReference.AddMessage(new CloudQueueMessage(somedata));
        }

        private static CloudStorageAccount GetStorgaeAccout()
        {
            return CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=incentivecomp3379;AccountKey=KGgmx8bzsRLA1gN4rKVp/kB82Fdlu4axSRNH2apmgW37baW9n1lxDMGqfjArLpwRXbkCfwbbY4BrRiHnGLZpdQ==");
        }
    }
}
