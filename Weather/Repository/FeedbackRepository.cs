/*******************************************************************************
 Name:        Feedback Repository
 Author:      Shivani Dubey, Chrome Infotech
 Date:        02/14/2023
 Description: Repository for managing feedback related data.
 Copyright © 2023 ChromeInfotech Corporation. All Rights Reserved
 Revisions:
 02/14/2023  1.0.0  SD  Created
*******************************************************************************/

using Weather.Models;
using System;

namespace Weather.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly WeatherContext _context;

        public FeedbackRepository(WeatherContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void SubmitFeedback(string comment, string rating)
        {
            try
            {
                var feedback = new Feedback
                {
                    Comment = comment,
                    Rating = rating
                };

                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
            }
            catch 
            {
               
                throw; // Re-throw the exception
            }
        }
    }
}
