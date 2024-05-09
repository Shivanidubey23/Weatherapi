/*******************************************************************************
 Name:        Feedback Services interface
 Author:      Shivani Dubey, Chrome Infotech
 Date:        02/14/2023
 Description: Interface for managing feedback related actions.
 Copyright © 2023 ChromeInfotech Corporation. All Rights Reserved
 Revisions:
 02/14/2023  1.0.0  SD  Created
*******************************************************************************/

namespace Weather.Service
{
    /// <summary>
    /// Interface for managing feedback related actions.
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// Submits feedback with a comment and rating.
        /// </summary>
        /// <param name="comment">The feedback comment.</param>
        /// <param name="rating">The rating given by the user.</param>
        void SubmitFeedback(string comment, string rating);
    }
}
