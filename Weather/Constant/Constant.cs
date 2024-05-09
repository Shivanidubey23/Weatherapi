/*******************************************************************************

Name:         Constant.cs
Author:       Shivani Dubey, Chrome Infotech
Date:         02/12/2023
Description:  Weather

 Copyright © 2023 ChromeInfotech Corporation.  All Rights Reserved

Revisions:
02/12/2023 1.0.0   SD  Created

*******************************************************************************/

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Weather
{
    public class Constant
    {
        public class Messages
        {
            public const string Comment = "Tell us what you think:";
        }

        public class Layout
        {
            public const string layout = "~/Views/Shared/_Layout.cshtml";
        }
        public class Controller
        {
           public const string Home = "Home";
            public const string Feedback = "Feedback";
        }
        public class Action
        {
           public const string Home = "Home";
            public const string Feedback = "Feedback";
            public const string SubmitFeedback = "SubmitFeedback";
        }
       
        public class Keys
        {
            public const string Title = "Title";
            
        }
        public class Text
        {
            public const string Layout = "Layout";
            public const string Feedback = "Feedback";
            public const string Home = "Home";
            public const string FeedbackForm = "Feedback Form";
            public const string RateUs = "Rate Us:";
            public const string Submit = "Submit";
            public const string WeatherForecast = "Weather Forecast";
            public const string Search = "Search";
            public const string CurrentLocation = "Current Location";
            public const string CurrentWeather = "Current Forecast";
            public const string AQI = "Air Quality Index";
            public const string dayforecast = "5 Day Forecast";
          


        }
    }
}
