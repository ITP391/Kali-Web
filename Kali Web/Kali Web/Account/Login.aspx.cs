﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.Account
{
    public partial class Login : System.Web.UI.Page
    {

        public static int count = 0;
        public static String globalinputemail;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["email"] = "";
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            globalinputemail = TextBox1.Text;
            //DATABASE
            //Pull out and compare
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };


                //get email and password input
                string inputemail = TextBox1.Text;
                string inputpassword = TextBox2.Text;

                String dbEmail = "";
                String dbPassword = "";
                String dbSalt = "";
                String dbFName = "";
                String dbLName = "";
                String dbPermission = "";

                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);


                SqlDataReader reader = myCommand.ExecuteReader();

                //read data from db
                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbPassword = reader["Password"].ToString();
                    dbSalt = reader["Salt"].ToString();
                    dbFName = reader["FName"].ToString();
                    dbLName = reader["LName"].ToString();
                    dbPermission = reader["Permission"].ToString();

                }

                string passwordHash = ComputeHash(inputpassword, new SHA512CryptoServiceProvider(), Convert.FromBase64String(dbSalt));

                myConnection.Close();


                if (dbEmail.Equals(inputemail) && dbPassword.Equals(passwordHash))
                {

                    //Session["email"] = TextBox1.Text;
                    String name = dbFName + " " + dbLName;
                    String permission = dbPermission;

                    Session["name"] = name;
                    Session["permission"] = permission;
                    Session["userPermission"] = permission;
                    
                    if (dbPermission == "student")
                    {
                        Response.Redirect("/SecurityTools/HomeStud.aspx");
                    }
                    else if (dbPermission == "lecturer")
                    {
                        Response.Redirect("/SecurityTools/HomeLect.aspx");
                    }
                }

                //Either email/password wrong, shows this
                else if (dbEmail.Equals(inputemail) && !dbPassword.Equals(passwordHash))
                {
                    Label5.Text = "Invalid credentials. Please try again.";
                }
            }
        }

        public static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Combine salt and input bytes
            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }
    }
}