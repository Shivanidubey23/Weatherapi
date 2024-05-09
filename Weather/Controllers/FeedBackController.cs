/*******************************************************************************
 Name:        Feedback Controller
 Author:      Shivani Dubey, Chrome Infotech
 Date:        02/14/2023
 Description: Controller for managing feedback related actions.
 Copyright © 2023 ChromeInfotech Corporation. All Rights Reserved
 Revisions:
 02/14/2023  1.0.0  SD  Created
*******************************************************************************/

using Microsoft.AspNetCore.Mvc;
using Weather.Service;
using System;

namespace Weather.Controllers
{
    /// <summary>
    /// Controller for managing feedback related actions.
    /// </summary>
    public class FeedBackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedBackController"/> class.
        /// </summary>
        /// <param name="feedbackService">The feedback service.</param>
        public FeedBackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
        }

        /// <summary>
        /// Action method for displaying the feedback form.
        /// </summary>
        /// <returns>The view for providing feedback.</returns>
        public ActionResult Feedback()
        {
            return View();
        }

        /// <summary>
        /// Action method for submitting feedback.
        /// </summary>
        /// <param name="comment">The feedback comment.</param>
        /// <param name="rating">The rating given by the user.</param>
        /// <returns>Redirects to the home page after submission.</returns>
        [HttpPost]
        public IActionResult SubmitFeedback(string comment, string rating)
        {
            try
            {
                _feedbackService.SubmitFeedback(comment, rating);
                return RedirectToAction(Constant.Action.Home, Constant.Controller.Home); // Redirect to home page after submission
            }
            catch (Exception ex)
            {
                // Print the exception message
                Console.WriteLine($"Exception occurred: {ex.Message}");
                
            }
            // Ensure a return statement outside of the try-catch block
            return RedirectToAction("Feedback");
        }
    }
}
