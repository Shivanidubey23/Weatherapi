/*******************************************************************************
 Name:        Feedback Services
 Author:      Shivani Dubey, Chrome Infotech
 Date:        02/14/2023
 Description: Service for managing feedback related actions.
 Copyright © 2023 ChromeInfotech Corporation. All Rights Reserved
 Revisions:
 02/14/2023  1.0.0  SD  Created
*******************************************************************************/

using Weather.Repository;
using System;

namespace Weather.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
        }

        public void SubmitFeedback(string comment, string rating)
        {
            try
            {
                _feedbackRepository.SubmitFeedback(comment, rating);
            }
            catch 
            {
                
                throw; // Re-throw the exception
            }
        }
    }
}
