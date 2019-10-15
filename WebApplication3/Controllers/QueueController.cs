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
        public ActionResult AddOneItem()
        {
            // Determine how many items are already in the queue
            int countMyQueue = myQueue.Count + 1;

            // Add one item to the queue
                // Create the variable name
                string itemName = "New Entry #" + countMyQueue;

                // Add it to the queue
                myQueue.Enqueue(itemName);

            // Create the result viewbag
            ViewBag.Result = "Item added successfully to the queue.";

            // Send result back
            return View("~/Views/Queue/Index.cshtml");
        }

        // This method adds 2000 items to the queue
        public ActionResult AddHugeList()
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

            // Create the result viewbag
            ViewBag.Result = "Huges list successfully added to the queue.";

            // Send result back
            return View("~/Views/Queue/Index.cshtml");
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
            return View("~/Views/Queue/Index.cshtml");
        }

        // This method clears the queue
        public ActionResult ClearQueue()
        {
            // Clear the queue
            myQueue.Clear();

            // Create the result viewbag
            ViewBag.Result = "Queue cleared successfully.";

            // Send result back
            return View("~/Views/Queue/Index.cshtml");
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
            ViewBag.Result = searchBox + " " + searchResult + " in " + ts + ".";

            // Send the viewbag to the view
            return View("~/Views/Queue/Index.cshtml");
        }

        // This method deletes an item from the stack
        public ActionResult DeleteQueue(string searchBox)
        {
            // Declare variables
            Queue<string> myTempQueue = new Queue<string>();
            string tempVariable;

            // Make sure the item exists
            bool itemExists = false;
            for (int iCount = 0; iCount < myQueue.Count;)
            {
                // Put the item in the temporary variable
                tempVariable = myQueue.Dequeue();

                if (searchBox == tempVariable)
                {
                    // The item exists
                    itemExists = true;

                    // Create the viewbag
                    ViewBag.Result = searchBox + " was removed successfully.";

                    // Add everything back onto myQueue in order
                    while (myQueue.Count > 0)
                    {
                        myTempQueue.Enqueue(myQueue.Dequeue());
                    }
                        // Make the temp queue myQueue so that it's in order
                        myQueue = myTempQueue;
          

                    // Kick us out of the loop
                    break;
                }
                else
                {
                    // The item still does not exist
                    // Add the checked item to the temporary queue
                    myTempQueue.Enqueue(tempVariable);
                }
            }

            // Create the viewbag if the item does not exist
            if (itemExists == false)
            {
                // Create the viewbag
                ViewBag.Result = "The item could not be deleted because it could not be found.";
            }

            // Return the result
            return View("~/Views/Queue/Index.cshtml");
        }
    }
}