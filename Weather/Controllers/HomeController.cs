/*******************************************************************************
 Name:        Home Controller
 Author:      Shivani Dubey, Chrome Infotech
 Date:        02/12/2023
 Description: Controller for managing home-related actions.
 Copyright © 2023 ChromeInfotech Corporation. All Rights Reserved
 Revisions:
 02/12/2023  1.0.0  SD  Created
*******************************************************************************/

using Microsoft.AspNetCore.Mvc;
using System;

namespace Weather.Controllers
{
    /// <summary>
    /// Controller for managing home-related actions.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Action method for displaying the home page.
        /// </summary>
        /// <returns>The view for the home page.</returns>
        public ActionResult Home()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Exception occurred: {ex.Message}");
               
            }
            // Ensure a return statement outside of the try-catch block
            return RedirectToAction(Constant.Action.Home, Constant.Controller.Home);
        }
    }
}
