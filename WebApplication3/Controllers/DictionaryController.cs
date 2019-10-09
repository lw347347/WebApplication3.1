using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class DictionaryController : Controller
    {
        // Create the dictionary
        public static Dictionary<int, string> myDictionary = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        // This method adds an item to the queue
        public ActionResult AddOneItem()
        {
            // Determine how many items are already in the dictionary
            int countMyDictionary = myDictionary.Count() + 1;

            // Add one item to the dictionary
                // Create the variable value and key
                int itemKey = countMyDictionary;
                string itemValue = "New Entry # " + itemKey;

                // Add it to the dictionary
                myDictionary.Add(itemKey, itemValue);

            // Create the result viewbag
            ViewBag.Result = "Item added successfully to the dictionary.";

            // Send result back
            return View("~/Views/Dictionary/Index.cshtml");
        }

        // This method adds 2000 items to the dictionary
        public ActionResult AddHugeList()
        {
            // Clear the dictionary
            myDictionary.Clear();

            // Add 2000 items
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                // Create the variable value and key
                int itemKey = iCount + 1;
                string itemValue = "New Entry " + itemKey;

                // Add them to the dictionary
                myDictionary.Add(itemKey, itemValue);
            }

            // Create the result viewbag
            ViewBag.Result = "Huge list successfully added to the dictionary.";

            // Send result back
            return View("~/Views/Dictionary/Index.cshtml");
        }

        // This method displays the items in the dictionary
        public ActionResult DisplayDictionary()
        {
            // Create the HTML for the view
            foreach (KeyValuePair<int, string> item in myDictionary)
            {
                ViewBag.displayDictionary = ViewBag.displayDictionary + "Key: " + item.Key + " Value: " + item.Value + "<br>";
            }

            // Send it to the view
            return View();
        }

        // This method clears the queue
        public ActionResult ClearDictionary()
        {
            // Clear the queue
            myDictionary.Clear();

            // Create the result viewbag
            ViewBag.Result = "Dictionary cleared successfully.";

            // Send result back
            return View("~/Views/Dictionary/Index.cshtml");
        }

        // This method sends you to the search queue page
        public ActionResult SearchDictionaryPage()
        {
            return View();
        }

        // This method returns the results from the search page
        public ActionResult SearchDictionary(string searchBox)
        {
            // Declare variables
            string searchResult = "not found";

            // Start the stop watch
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // Start looping and checking through the queue
            foreach (KeyValuePair<int, string> item in myDictionary)
            {
                if (item.Value == searchBox)
                {
                    // The item was found
                    searchResult = "found";

                    // Kick us out of the foreach loop
                    break;
                }
                else
                {
                    // The item was not found so check the next item in the queue
                }
            }

            // Stop the stop watch
            sw.Stop();

            // Create the viewbag 
            TimeSpan ts = sw.Elapsed;
            ViewBag.Result = searchBox + " " + searchResult + " in " + ts + ".";

            // Send result back
            return View("~/Views/Dictionary/Index.cshtml");
        }
    }
}