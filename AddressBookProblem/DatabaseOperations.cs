using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AddressBookProblem
{
    public class DatabaseOperations
    {


        public static string connectionString = @" Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void InsertDataInDatabase(AddressBook addressBook, string addressBookName)
        {
            try
            {
                using (this.connection)
                {
                    foreach (Contact contact in addressBook.contactsList)
                    {
                        SqlCommand command = new SqlCommand("spInsertContacts", this.connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                        command.Parameters.AddWithValue("@LastName", contact.LastName);
                        command.Parameters.AddWithValue("@Email", contact.EmailId);
                        command.Parameters.AddWithValue("@Address", contact.Address);
                        command.Parameters.AddWithValue("@City", contact.City);
                        command.Parameters.AddWithValue("@State", contact.State);
                        command.Parameters.AddWithValue("@Zip", contact.Zip);
                        command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                        command.Parameters.AddWithValue("@addressBookName", addressBookName);
                        this.connection.Open();
                        var result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result != 0)
                        {
                            Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} insertion unsuccessfull");
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }


        public void retrieveContactData(string addressBookName)
        {
            try
            {
                Contact contact = new Contact();

                using (this.connection)
                {
     
                    SqlCommand cmd = new SqlCommand("spRetrieveData", this.connection);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@addressBookName", addressBookName);


                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contact.FirstName = dr.GetString(0);
                            contact.LastName = dr.GetString(1);
                            contact.EmailId = dr.GetString(2);
                            contact.Address = dr.GetString(3);
                            contact.City = dr.GetString(4);
                            contact.State = dr.GetString(5);
                            contact.Zip = dr.GetString(6);
                            contact.PhoneNumber = dr.GetString(7);
                            Console.WriteLine(contact.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                    dr.Close();

                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }


    }

       
}
