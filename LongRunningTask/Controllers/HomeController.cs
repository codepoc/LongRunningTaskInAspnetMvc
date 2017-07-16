using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LongRunningTask.MyTask;

namespace LongRunningTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Guid requestId = Guid.NewGuid();
            ProgressTracker.add(requestId, "Starting Long running task!!!");

            //Call Long running task
            MyLongRunningTask myTask = new MyLongRunningTask();
            myTask.RunMyTask(requestId);

            return RedirectToAction("TaskProgress", new { requestId = requestId.ToString() });            
        }

        public IActionResult TaskProgress(string requestId)
        {
            var statusMessage = string.Empty;

            if (!string.IsNullOrWhiteSpace(requestId))
            {
                statusMessage = ProgressTracker.getValue(Guid.Parse(requestId)).ToString();
                
                //The processing  has not yet finished 
                //Add a refresh header, to refresh the page in 10 seconds.
                Response.Headers.Add("Refresh", "5");
                return View("TaskProgress", statusMessage);
            }

            statusMessage = "Error: Something went wrong with process";
            return View("TaskProgress", statusMessage);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
