using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class InputPrompts
    {
        #region Pattern Declarations
        /// <summary>
        /// Stores the name pattern
        /// </summary>
        public const string namePattern = @"^([a-zA-Z-]{2,30})$";
        public const string nameError = "Please use only alpha characters and hyphens";
        /// <summary>
        /// Stores the email pattern
        /// </summary>
        public const string emailPattern = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        public const string emailError = "Invalid Email address";
        /// <summary>
        /// Stores the address line 1 pattern
        /// </summary>
        public const string address1Pattern = @"^([a-zA-Z0-9 .-]{2,50})$";
        public const string address1Error = "Please use only alphanumeric characters, periods, or hyphens";
        /// <summary>
        /// Stores the address line 2 pattern
        /// </summary>
        public const string address2Pattern = @"^([a-zA-Z0-9 .-]{0,50})*$";
        /// <summary>
        /// Stores the city pattern
        /// </summary>
        public const string cityPattern = @"^([a-zA-Z -]{2,30})$";
        /// <summary>
        /// Stores the phone pattern
        /// </summary>
        public const string phonePattern = @"^\d{10}$";
        public const string phoneError = "Invalid phone number";
        /// <summary>
        /// Stores the zip code pattern
        /// </summary>
        public const string zipPattern = @"^\d{5}$";
        /// <summary>
        /// Stores the Product name pattern
        /// </summary>
        public const string productPattern = @"^([a-zA-Z0-9 .,-]{0,300})$";
        /// <summary>
        /// Stores the Price pattern
        /// </summary>
        public const string pricePattern = @"^\d{0,8}(\.\d{2})?$";
        /// <summary>
        /// Stores the location pattern
        /// </summary>
        public const string locationPattern = @"^([a-zA-Z-. ]{2,30})$";
        /// <summary>
        /// Stores the ID pattern
        /// </summary>
        public const string idPattern = @"^\d{1,10}$";
        /// <summary>
        /// Stores the quantity pattern
        /// </summary>
        public const string quantityPattern = @"^\d{1,3}$";
        /// <summary>
        /// Stores the list of acceptable state abbreviations
        /// </summary>
        public readonly string[] stateAbbreviations = {
            "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT",
            "VT", "VI", "VA", "WA", "WV", "WI", "WY" };
    }
    #endregion
}

