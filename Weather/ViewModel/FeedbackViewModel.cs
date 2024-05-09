/*******************************************************************************
 Name:        Feedback view model
 Author:       Shivani Dubey, Chrome Infotech
 Date:         02/13/2023
 Description:  Weather
 Copyright © 2023 ChromeInfotech Corporation.  All Rights Reserved
 Revisions:
 02/13/2023  1.0.0   SD  Created
*******************************************************************************/
namespace Weather.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid ID { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
