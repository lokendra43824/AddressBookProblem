using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBookProblem
{
    [Serializable]
    public class Contact 
    {/// <summary>
     /// Gets or sets the first name.
     /// </summary>
     /// <value>
     /// The first name.
     /// </value>

        [StringLength(25, MinimumLength = 3, ErrorMessage = "Invalid FirstName! Minimum 3 letters")]
        [RegularExpression("^[A-Z]{1}[a-zA-Z ]{2,25}$", ErrorMessage = "Invalid FirstName, First letter is capital followed by small letters")]
        public String FirstName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>

        [StringLength(25, MinimumLength = 3, ErrorMessage = "Invalid LastName! Minimum 3 letters")]
        [RegularExpression("^[A-Z]{1}[a-z]{2,25}$", ErrorMessage = "Invalid LastName, Last letter is capital followed by small letters")]
        public String LastName { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>


        [StringLength(100, MinimumLength = 3, ErrorMessage = "Invalid Address! Minimum 3 letters")]
        [RegularExpression(@"^[a-zA-Z:,.0-9]{3,100}$", ErrorMessage = "Invalid Address!")]
        public String Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid City! Minimum 3 letters")]
        [RegularExpression("^[A-Z]{1}[a-z]{2,100}$", ErrorMessage = "Invalid City! First letter should be Capital")]
        public String City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>


        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid State! Minimum 3 letters")]
        [RegularExpression("^[A-Z]{1}[a-z]{2,100}$", ErrorMessage = "Invalid State! First letter should be Capital")]
        public String State { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>

        [StringLength(25, MinimumLength = 5, ErrorMessage = "Invalid Email! Minimum 5 letters")]
        [RegularExpression(@"^[a-z]+([-+*.]?[0-9a-z])*@[a-z0-9]+\.(\.?[a-z]{2,}){1,2}$", ErrorMessage = "Invalid Emailid!")]
        public String EmailId { get; set; }

        /// <summary>
        /// Gets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>

        [StringLength(6, ErrorMessage = "Invalid Zip! Zip is 6 digits")]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Zip!")]
        public String Zip { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>

        [StringLength(25, MinimumLength = 13, ErrorMessage = "Minimum 13 letters, Use pattern: +(countycode)(phonenumber)")]
        [RegularExpression("^[+][0-9]{1,3}[\\s]*[0-9]{10}$", ErrorMessage = "Invalid PhoneNumber! Use pattern: +(countycode)(phonenumber)")]
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        public Contact() { }



        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
        public Contact(String firstName, String lastName, String address, String city, String state, string zip, string phoneNumber, String email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.PhoneNumber = phoneNumber;
            this.EmailId = email;

            Console.WriteLine("Hola!! New Contact is created");
        }


        public override string ToString()
        {
            return (($"\nName: {this.FirstName} {this.LastName}\nAddress: { this.Address}, City: { this.City}\nState: { this.State}, Zip: { this.Zip}\nEmail: { this.EmailId}, Phone Number: { this.PhoneNumber}"));

        }  
    }
}