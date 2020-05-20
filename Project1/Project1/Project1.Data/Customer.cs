using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Project1.BusinessLogic;

namespace Project1.Data
{
    /// <summary>
    /// Model for the Customer class
    /// </summary>
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("First Name")]
        [RegularExpression(InputPrompts.namePattern, ErrorMessage = InputPrompts.nameError)]
        public string FName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [RegularExpression(InputPrompts.namePattern, ErrorMessage = InputPrompts.nameError)]
        public string LName { get; set; }
        [DisplayName("Address Line 1")]
        [RegularExpression(InputPrompts.address1Pattern, ErrorMessage = InputPrompts.address1Error)]
        public string Address1 { get; set; }
        [DisplayName("Address Line 2")]
        [RegularExpression(InputPrompts.address1Pattern, ErrorMessage = InputPrompts.address1Error)]
        public string Address2 { get; set; }
        public string City { get; set; }
        [UsStateTwoCharacterAbbreviation]
        public string State { get; set; }
        [RegularExpression(InputPrompts.zipPattern, ErrorMessage = InputPrompts.zipError)]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        [RegularExpression(InputPrompts.phonePattern,ErrorMessage =InputPrompts.phoneError)]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = InputPrompts.emailError)]
        public string Email { get; set; }

        /// <summary>
        /// No argument constructor
        /// </summary>
        public Customer() { }

    }
}
