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
        public ActionResult AddOneItem()
        {
            // Determine how many items are already in the stack
            int countMyStack = myStack.Count + 1;

            // Add one item to the stack
                // Create the variable name
                string itemName = "New Entry #" + countMyStack;

                // Add it to the stack
                myStack.Push(itemName);

            // Create the result viewbag
            ViewBag.Result = "Item added successfully to the Stack.";

            // Send result back
            return View("~/Views/Stack/Index.cshtml");
        }

        // This method adds 2000 items to the stack
        public ActionResult AddHugeList()
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

            // Create the result viewbag
            ViewBag.Result = "Huge list successfully added to the Stack.";

            // Send result back
            return View("~/Views/Stack/Index.cshtml");
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
        public ActionResult ClearStack()
        {
            // Clear the stack
            myStack.Clear();

            // Create the result viewbag
            ViewBag.Result = "Stack successfully cleared.";

            // Send result back
            return View("~/Views/Stack/Index.cshtml");
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
            ViewBag.Result = searchBox + " " + searchResult + " in " + ts + ".";

            // Send result back
            return View("~/Views/Stack/Index.cshtml");
        }

        // This method sends you to the delete stack page
        public ActionResult DeleteStackPage()
        {
            return View();
        }

        // This method deletes an item from the stack
        public ActionResult DeleteStack(string searchBox)
        {
            // Declare variables
            Stack<string> myTempStack = new Stack<string>();
            string tempVariable;

            // Make sure the item exists
            bool itemExists = false;
            for (int iCount = 0; iCount < myStack.Count; )
            {
                // Put the item in the temporary variable
                tempVariable = myStack.Pop();

                if (searchBox == tempVariable)
                {
                    // The item exists
                    itemExists = true;

                    // Create the viewbag
                    ViewBag.Result = searchBox + " was removed successfully.";

                    // Add everything back onto myStack
                    while (myTempStack.Count > 0)
                    {
                        myStack.Push(myTempStack.Pop());
                    }                     

                    // Kick us out of the loop
                    break;
                }
                else
                {
                    // The item still does not exist
                    // Add the checked item to the temporary stack
                    myTempStack.Push(tempVariable);
                }
            }

            // Create the viewbag if the item does not exist
            if (itemExists == false)
            {
                // Create the viewbag
                ViewBag.Result = "The item could not be deleted because it could not be found.";
            }

            // Return the result
            return View("~/Views/Stack/Index.cshtml");
        }
    }
}