using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApiSampleProject.database
{
    class DB
    {



        private MySqlConnection connection;


        private string server;
        private string database;

        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        private string uid;
        private string password;

        //Constructor
        public DB()
        {
            Initialize();
        }


        //Initialize values
        private void Initialize()
        {

            server = "127.0.0.1";
            database = "base pfe";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }




        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }


        public string OpenConnection()
        {
            string status = "Echec";
            try
            {
                connection.Open(); // ouverture de la connexion
                status = "success";
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        status = "Cannot connect to server.  Contact administrator";
                        break;

                    case 1045:
                        status = "Invalid username/password, please try again";
                        break;
                }
                return "Erreur inattendu";
            }

            return status;
        }




        public string CloseConnection()
        {
            string status = "echec";
            try
            {
                connection.Close();
                status = "success";
            }
            catch (MySqlException ex)
            {
                status = ex.Message;

            }
            return status;
        }



        //excuter requete  select

       public DataTable executerSelect(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                if (OpenConnection() == "success")
                {
                 
                    MySqlCommand cmd = new MySqlCommand(query, Connection);

                    MySqlDataAdapter dataadapter = new MySqlDataAdapter(cmd);

                    dataadapter.Fill(dt);
                    CloseConnection();
                }
                return dt;
            }
           catch(Exception ex)
            {
                return null;
           }

        }


        //fonction excuter une  requete (insert, update  ,delete)
       public bool executeCUD(string query)
       {
           try
           {

               //open connection
               if (OpenConnection() == "success")
               {
                   //create command and assign the query and connection from the constructor
                   MySqlCommand cmd = new MySqlCommand(query, Connection);

                   //Execute command
                   cmd.ExecuteNonQuery();


                   //close connection
                   CloseConnection();
                   return true;

               }
               return false;
           }

           catch (Exception ex)
           {
               return false;
             
           }

       }






    }
}
