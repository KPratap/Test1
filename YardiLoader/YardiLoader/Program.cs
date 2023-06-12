using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace YardiLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Clients.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("client");
            string keyword;
            String RrsId = "";
            Boolean Enb = false;
            Boolean Auto = false;
            String Url = "";
            String UserId = "";
            String Password = "";
            String Server = "";
            String DatabaseId = "";
            String Platform = "";
            String YardiPropID = "";
            String PmcName = "";
            string insertQuery = "INSERT INTO dbo.YardiClients (RrsId, Enabled, Automate, Url, UserId, Password, Server, DatabaseId, Platform, YardiPropId, PmcName) " +
                "VALUES  (@RrsId, @Enabled, @Automate, @Url, @UserId, @Password, @Server, @DatabaseId, @Platform, @YardiPropId, @PmcName)";
            string queryString = "SELECT * FROM  [dbo].[YardiClients]";
            string connectionString = "Data Source =.\\SQLEXP2022; Initial Catalog = RRSDashboard; Integrated Security = SSPI; User ID = beep; Password = beep";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(insertQuery, conn);
            conn.Open();

            foreach (XmlNode node in nodes)
            {
                keyword = "";
                var attribute = node.Attributes["keyword"];
                if (attribute != null)
                {
                    keyword = attribute.Value;
                }
                //Console.WriteLine("Client Keyword: " + keyword);
                var childrenNodes = node.ChildNodes;

                foreach (XmlNode ch in childrenNodes)
                {
                    if(ch.Name.ToLower() == "RrsId".ToLower())
                        RrsId = ch.InnerText;
                    if (ch.Name.ToLower() == "Enabled".ToLower())
                        Enb = Convert.ToBoolean(ch.InnerText);
                    if (ch.Name.ToLower() == "Automate".ToLower())
                        Auto = Convert.ToBoolean(ch.InnerText);
                    if (ch.Name.ToLower() == "Url".ToLower())
                        Url = ch.InnerText;
                    if (ch.Name.ToLower() == "UserId".ToLower())
                        UserId = ch.InnerText;
                    if (ch.Name.ToLower() == "Password".ToLower())
                        Password = ch.InnerText;
                    if (ch.Name.ToLower() == "Server".ToLower())
                        Server = ch.InnerText;
                    if (ch.Name.ToLower() == "DatabaseId".ToLower())
                        DatabaseId = ch.InnerText;
                    if (ch.Name.ToLower() == "Platform".ToLower())
                        Platform = ch.InnerText;
                    if (ch.Name.ToLower() == "YardiPropId".ToLower())
                        YardiPropID = ch.InnerText;
                    if (ch.Name.ToLower() == "PmcName".ToLower())
                        PmcName = ch.InnerText;
                }
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@RrsId", RrsId);
                command.Parameters.AddWithValue("@Enabled", Enb);
                command.Parameters.AddWithValue("@Automate", Auto);
                command.Parameters.AddWithValue("@Url", Url);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Server", Server);
                command.Parameters.AddWithValue("@DatabaseId", DatabaseId);
                command.Parameters.AddWithValue("@Platform", Platform);
                command.Parameters.AddWithValue("@YardiPropId", YardiPropID);
                command.Parameters.AddWithValue("@PmcName", PmcName);
                command.ExecuteNonQuery();
                
            }

            
            try
            
            {                

                //SqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    Console.WriteLine($"{reader["RrsId"]}, {reader["Enabled"]}, {reader["Automate"]}, {reader["Url"]}, {reader["UserId"]}, " +
                //        $"{reader["Password"]}, {reader["Server"]}, {reader["DatabaseId"]}, {reader["Platform"]}, {reader["YardiPropId"]}, {reader["PmcName"]}");

                //}
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        //public void InsertClient(String rrsid, int enb, int auto, String url, String username, String pswd, String serverName, String dbID, String platform, String propID, String pmcName)
        //{
        //    command.Parameters.AddWithValue("@RrsId", rrsid);
        //    command.Parameters.AddWithValue("@Enabled", enb);
        //    command.Parameters.AddWithValue("@Automate", auto);
        //    command.Parameters.AddWithValue("@Url", url);
        //    command.Parameters.AddWithValue("@UserId", username);
        //    command.Parameters.AddWithValue("@Password", pswd);
        //    command.Parameters.AddWithValue("@Server", serverName);
        //    command.Parameters.AddWithValue("@DatabaseId", dbID);
        //    command.Parameters.AddWithValue("@Platform", platform);
        //    command.Parameters.AddWithValue("@YardiPropId", propID);
        //    command.Parameters.AddWithValue("@PmcName", pmcName);
        //    command.ExecuteNonQuery();
        //}
    }
}
