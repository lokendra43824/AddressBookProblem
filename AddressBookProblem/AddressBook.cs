using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace AddressBookProblem
{
    [Serializable]
    public class AddressBook 
    {
        public static ValidationContext context;
        public static List<ValidationResult> result = new List<ValidationResult>();
        public static bool isValid;

        public List<Contact> contactsList;

        public AddressBook()
        {
            contactsList = new List<Contact>();
        }


        static void Validate(Contact contact, string fieldName)
        {

            Type userType = contact.GetType();

            MethodInfo method = userType.GetMethod("set_" + fieldName);

            string input;

            while (true)
            {
                //getting input from user
                input = Console.ReadLine();

                //invoke the setter method to intialise variables

                method.Invoke(contact, new object[] { input });

                isValid = Validator.TryValidateObject(contact, context, result, true);

                //valdating the input
                if (!isValid)
                {
                    Console.WriteLine(result[result.Count - 1].ErrorMessage);
                    Console.WriteLine("Please Enter your " + fieldName + " Again!!");
                }
                else
                {
                    break;
                }
            }

        }

        // to fetch Contact details

        public Contact GetDetails()
        {
            Contact contact = new Contact();

            context = new ValidationContext(contact, null, null);

            Console.WriteLine("Enter your First Name");
            Validate(contact, "FirstName");


            Console.WriteLine("\nEnter your Last Name");
            Validate(contact, "LastName");

            if(IsContactExist(contact.FirstName, contact.LastName))
            {
                return null;
            }

            Console.WriteLine("\nEnter your Address");
            Validate(contact, "Address");

            Console.WriteLine("\nEnter your City");
            Validate(contact, "City");

            Console.WriteLine("\nEnter your State");
            Validate(contact, "State");

            Console.WriteLine("\nEnter your Zip");
            Validate(contact, "Zip");

            Console.WriteLine("\nEnter your EmailId");
            Validate(contact, "EmailId");


            Console.WriteLine("\nEnter your Phone Number");
            Validate(contact, "PhoneNumber");

            return contact;
        }

        // to Adding contact

        public void AddContact()
        {
            Contact contact = GetDetails();

            if (contact != null)
            {
                contactsList.Add(contact);
            }

        }

        public bool IsContactExist(string FirstName, string LastName)
        {
            bool isContactExist = false;
            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(FirstName) && contact.LastName.Equals(LastName))
                {
                    Console.WriteLine("\nContact Already exists with same name. Try again!!");

                    isContactExist = true;
                }
            }
            return isContactExist;
        }

        // edit contact
        public void EditContact()
        {
            Console.WriteLine("Enter First Name: ");
            String firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            String lastName = Console.ReadLine();

            bool isEdited = false;

            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
                {
                    Console.WriteLine("Select the detail to be Edited");
                    Console.WriteLine("1.First Name");
                    Console.WriteLine("2.Last Name");
                    Console.WriteLine("3.Address");
                    Console.WriteLine("4.City");
                    Console.WriteLine("5.State");
                    Console.WriteLine("6.Zip");
                    Console.WriteLine("7.Email ID");
                    Console.WriteLine("8.Phone Number");


                    while (true)
                    {
                        int choice;
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Validate(contact, "FirstName");
                                    break;
                                case 2:
                                    Validate(contact, "LastName");
                                    break;
                                case 3:
                                    Validate(contact, "Address");
                                    break;
                                case 4:
                                    Validate(contact, "City");
                                    break;
                                case 5:
                                    Validate(contact, "State");
                                    break;
                                case 6:
                                    Validate(contact, "Zip");
                                    break;
                                case 7:
                                    Validate(contact, "EmailId");
                                    break;
                                case 8:
                                    Validate(contact, "PhoneNumber");
                                    break;
                                default:
                                    break;


                            }

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input..Enter a digit");
                        }

                    }

                    isEdited = true;
                }

            }
            if (isEdited)
            {
                Console.WriteLine("\nDetails Updated SuccessFully!!\n");
            }
            else
            {
                Console.WriteLine("\nNo contact exits with this name\n");
            }


        }


        public void ViewContact()
        {
            Console.WriteLine("Enter First Name: ");
            String firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            String lastName = Console.ReadLine();

            bool isShown = false;

            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
                {
                    Console.WriteLine(contact.ToString());
                    isShown = true;
                    break;
                }
            }

            if (isShown == false)
            {
                Console.WriteLine("\nNo contact exits with this name\n");
            }
        }

        public void ViewAllContacts()
        {
            Console.WriteLine("View Contacts Sorted by: ");
            Console.WriteLine("1.Name, \n2.City, \n3.State, \n4.Zip");
            string sortby = Console.ReadLine();

            if(sortby.Equals("2"))
            {
                this.SortByCity();
            }
            else if (sortby.Equals("3"))
            {
                this.SortByState();
            }
            else if (sortby.Equals("4"))
            {
                this.SortByZip();
            }
            else
            {
                this.SortByName();
            }


            
            foreach (Contact contact in this.contactsList)
            {
                Console.WriteLine(contact.ToString());

            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter First Name: ");
            String firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            String lastName = Console.ReadLine();

            bool isDeleted = false;

            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
                {
                    contactsList.Remove(contact);
                    isDeleted = true;
                    break;
                }
            }

            if (isDeleted == false)
            {
                Console.WriteLine("\nNo contact exits with this name\n");
            }
            else
            {
                Console.WriteLine("\nContact Deleted successfully with name: " + firstName + " " + lastName + "\n");
            }
        }

        public void SortByName()
        {
            this.contactsList = this.contactsList.OrderBy(o => o.FirstName).ToList();
        }

        public void SortByCity()
        {
            this.contactsList = this.contactsList.OrderBy(o => o.City).ToList();
        }
        public void SortByState()
        {
            this.contactsList = this.contactsList.OrderBy(o => o.State).ToList();
        }

        public void SortByZip()
        {
            this.contactsList = this.contactsList.OrderBy(o => o.Zip).ToList();
        }


        

    }
}