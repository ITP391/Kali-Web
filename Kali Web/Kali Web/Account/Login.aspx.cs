using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Services;
using System.Collections.Specialized;
using System.IO;
using System.Web.Script.Serialization;

namespace Kali_Web.Account
{
    public partial class Login : System.Web.UI.Page
    {

        public static int count = 0;
        public static String globalinputemail;
        public static String globaldbpermission;
        protected static string ReCaptcha_Key = "6Le2QysUAAAAAJuMqCdo8wDVETXyrDPTtP4LjeRc";
        protected static string ReCaptcha_Secret = "6Le2QysUAAAAAHhD4Y36WruQR807tLRlI-y0UJZO";

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

                String dbId = "";
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
                    dbId = reader["Id"].ToString();
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
                    String name = dbFName + " " + dbLName;
                    String permission = dbPermission;

                    Session["id"] = dbId;
                    Session["email"] = dbEmail;
                    Session["name"] = name;
                    Session["permission"] = permission;
                    Session["userPermission"] = permission;
                    globaldbpermission = dbPermission;
                    globalinputemail = dbEmail;

                    bool result = CaptchaValidate();

                    if (result == true)
                    {
                        if (dbPermission == "student")
                        {
                            Response.Redirect("/SecurityTools/HomeStud.aspx");
                        }
                        else if (dbPermission == "lecturer")
                        {
                            Response.Redirect("/SecurityTools/HomeLect.aspx");
                        }
                    }

                    else
                    {
                        error.Visible = true;
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

        public bool CaptchaValidate()
        {
            string Response = Request["g-recaptcha-response"];//Getting Response String Append to Post Method
            bool Valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            (" https://www.google.com/recaptcha/api/siteverify?secret=6Le2QysUAAAAAHhD4Y36WruQR807tLRlI-y0UJZO&response=" + Response);
            try
            {
                //Google recaptcha Response
                using (WebResponse wResponse = req.GetResponse())
                {

                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        MyObject data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json

                        Valid = Convert.ToBoolean(data.success);
                    }
                }

                return Valid;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public class MyObject
        {
            public string success { get; set; }
        }
    }
}