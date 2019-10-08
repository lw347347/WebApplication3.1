using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class StackController : Controller
    {
        // Create the stack
        public static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        // This method adds an item to the stack
        public string AddOneItem()
        {
            // Determine how many items are already in the stack
            int countMyStack = myStack.Count + 1;

            // Add one item to the stack
                // Create the variable name
                string itemName = "New Entry #" + countMyStack;

                // Add it to the stack
                myStack.Push(itemName);

                // Send result back
                return "Item added successfully to stack.";
        }

        // This method adds 2000 items to the stack
        public string AddHugeList()
        {
            // Clear the stack
            myStack.Clear();

            // Add 2000 items
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                // Create the variable name
                string itemName = "New Entry " + (iCount + 1);

                // Add it to the stack
                myStack.Push(itemName);
            }

            // Send result back
            return "Huge list successfully added to stack.";
        }

        // This method displays the items in the stack
        public ActionResult DisplayStack()
        {
            // Create the HTML for the view
            foreach (string item in myStack)
            {
                ViewBag.displayStack = ViewBag.displayStack + item + "<br>";
            }

            // Send it to the view
            return View();
        }

        // This method clears the stack
        public string ClearStack()
        {
            // Clear the stack
            myStack.Clear();

            // Send result back
            return "Stack cleared successfully.";
        }

        // This method sends you to the search stack page
        public ActionResult SearchStackPage()
        {
            return View();
        }

        // This method returns the results from the search page
        public ActionResult SearchStack(string searchBox)
        {
            // Declare variables
            string searchResult = "not found";

            // Start the stop watch
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // Start looping and checking through the stack
            foreach (string item in myStack)
            {
                if (item == searchBox)
                {
                    // The item was found
                    searchResult = "found";

                    // Kick us out of the foreach loop
                    break;
                }
                else
                {
                    // The item was not found so check the next item in the stack
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