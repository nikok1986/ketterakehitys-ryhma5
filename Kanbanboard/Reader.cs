﻿using System;
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
        string name;
        public Reader()
        { 
            
        }
        public Reader(string nimi)
        {
            name= nimi;
        }
        public String DBEveryProjectNameReader()
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
        public String DBProjectNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_nimi, project_id FROM projects WHERE project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string projectname = String.Empty;    //Kerätään info tähän tyhjään stringiin.


                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return projectname;
            }
        }
        public String DBProjectInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_info FROM projects WHERE project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string projectinfo = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectinfo = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return projectinfo;
            }
        }
        public DateTime DBProjectStartDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_aloitus_pvm FROM projects WHERE project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime startdate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    startdate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return startdate;
            }
        }
        public DateTime DBProjectEndDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_lopetus_pvm FROM projects WHERE project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime enddate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    enddate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return enddate;
            }
        }
        public String DBSprintNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT sprints.sprint_nimi FROM projects INNER JOIN sprints ON projects.project_id = sprints.project_id WHERE projects.project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string sprintname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sprintname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return sprintname;
            }
        }
        public String DBSprintInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT sprint_info FROM sprints WHERE sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string sprintinfo = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sprintinfo = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return sprintinfo;
            }
        }
        public DateTime DBSprintStartDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_aloitus_pvm FROM sprints WHERE sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime startdate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    startdate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return startdate;
            }
        }
        public DateTime DBSprintEndDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_lopetus_pvm FROM sprints WHERE sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime enddate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    enddate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return enddate;
            }
        }
        public String DBTeamNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT team_nimi FROM projects INNER JOIN teams ON projects.project_id = teams.project_id WHERE projects.project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teams += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teams;
            }
        }
        public String DBUserNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT users.user_nimi FROM projects INNER JOIN (users INNER JOIN (teams INNER JOIN users_teams_link ON teams.team_id = users_teams_link.team_id) ON users.user_id = users_teams_link.user_id) ON projects.project_id = teams.project_id WHERE projects.project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string users = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return users;
            }
        }
        public String DBUserStoryReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_stories.user_story_nimi FROM projects INNER JOIN user_stories ON projects.project_id = user_stories.project_id WHERE projects.project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string userstories = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userstories += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userstories;
            }
        }
        public String DBBackLogReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                // SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id;
                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=0 AND sprints.sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
            }
        }
        public String DBTaskInProgressReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=1 AND sprints.sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
            }
        }
        public String DBCompleteTaskReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=2 AND sprints.sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
            }
        }
    }
}
