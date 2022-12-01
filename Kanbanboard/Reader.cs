using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kanbanboard
{
    internal class Reader
    {
        public String DBProjectNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_nimi FROM projects;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string projects = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] projectlist = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(projectlist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            projects += projectlist[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return projects;   //Palautetaan nimet sisältävä string
            }
        }
        public String DBTeamNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT team_nimi FROM teams;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] teamlist = new string[100]; 
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(teamlist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            teams += teamlist[i].ToString() + "\n"; //Nimet kerätään teamlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return teams;   //Palautetaan nimet sisältävä string
            }
        }
        public String DBUserNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT user_nimi FROM users;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string users = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] userlist = new string[1000];
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(userlist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            users += userlist[i].ToString() + "\n"; //Nimet kerätään userlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return users;   //Palautetaan nimet sisältävä string
            }
        }

        internal object DBSprintNameReader()
        {
            throw new NotImplementedException();
        }
    }
}
