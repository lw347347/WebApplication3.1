using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class QueueController : Controller
    {
        // Create the queue
        public static Queue<string> myQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            return View();
        }
        
        // This method adds an item to the queue
        public string AddOneItem()
        {
            // Determine how many items are already in the queue
            int countMyQueue = myQueue.Count + 1;

            // Add one item to the queue
                // Create the variable name
                string itemName = "New Entry #" + countMyQueue;

                // Add it to the queue
                myQueue.Enqueue(itemName);

            // Send result back
            return "Item added successfully to queue.";
        }

        // This method adds 2000 items to the queue
        public string AddHugeList()
        {
            // Clear the queue
            myQueue.Clear();

            // Add 2000 items
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                // Create the variable name
                string itemName = "New Entry " + (iCount + 1);

                // Add it to the queue
                myQueue.Enqueue(itemName);
            }

            // Send result back
            return "Huge list successfully added to queue.";
        }

        // This method displays the items in the queue
        public ActionResult DisplayQueue()
        {
            // Create the HTML for the view
            foreach(string item in myQueue)
            {
                ViewBag.displayQueue = ViewBag.displayQueue + item + "<br>";
            }

            // Send it to the view
            return View();
        }

        // This method clears the queue
        public string ClearQueue()
        {
            // Clear the queue
            myQueue.Clear();

            // Send result back
            return "Queue cleared successfully.";
        }

        // This method sends you to the search queue page
        public ActionResult SearchQueuePage()
        {
            return View();
        }

        // This method returns the results from the search page
        public ActionResult SearchQueue(string searchBox)
        {
            // Declare variables
            string searchResult = "not found";
            
            // Start the stop watch
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // Start looping and checking through the queue
            foreach (string item in myQueue)
            {
                if (item == searchBox)
                {
                    // The item was found
                    searchResult = "found";

                    // Kick us out of the foreach loop
                    break;
                } else
                {
                    // The item was not found so check the next item in the queue
                }
            }

            // Stop the stop watch
            sw.Stop();

            // Create the viewbag 
            TimeSpan ts = sw.Elapsed;
            ViewBag.searchResult = searchBox + " " + searchResult + " in " + ts + ".";

            // Send the viewbag to the view
            return View();
        }
    }
}