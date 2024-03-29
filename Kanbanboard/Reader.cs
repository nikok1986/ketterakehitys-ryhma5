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
using System.Security.Permissions;
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
        //<-----------------------------------READALL READERS------------------------------->
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
        public String DBEveryUserNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT user_nimi FROM users;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string users = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] userlist = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(userlist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            users += userlist[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
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
        public String DBEverySprintNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_nimi FROM sprints;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string sprints = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] sprintlist = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(sprintlist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            sprints += sprintlist[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return sprints;   //Palautetaan nimet sisältävä string
            }
        }
        public String DBEveryUserStoryNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT user_story_nimi FROM user_stories;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string userstories = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] userstorylist = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(userstorylist);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            userstories += userstorylist[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return userstories;   //Palautetaan nimet sisältävä string
            }
        }
        public String DBEveryTeamNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT team_nimi FROM teams;");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] teamList = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(teamList);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            teams += teamList[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
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

        //<-----------------------------------PROJECT READERS-------------------------------->
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
        public String DBProjectTeamsReader()
        { 
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT teams.team_nimi FROM projects INNER JOIN teams on teams.project_id = projects.project_id WHERE projects.project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] projectTeams = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(projectTeams);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            teams += projectTeams[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
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
        public String DBProjectUserNameReader()
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

        //<-----------------------------------SPRINT READERS------------------------------->
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

        //<-----------------------------------USER READERS---------------------------------->
        public String DBUserRoleReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_rooli FROM users WHERE user_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string username = String.Empty;    //Kerätään info tähän tyhjään stringiin.


                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    username += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return username;
            }
        }
        public String DBUserTaskReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM users INNER JOIN tasks ON tasks.user_id = users.user_id WHERE user_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string tasks = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] taskList = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(taskList);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            tasks += taskList[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
                        }
                        read = reader.Read();
                    }
                    while (read == true);
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                return tasks;   //Palautetaan nimet sisältävä string
            }
        }
        public String DBUserTeamReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT teams.team_nimi FROM users INNER JOIN (teams INNER JOIN users_teams_link ON teams.team_id = users_teams_link.team_id) ON users.user_id = users_teams_link.user_id WHERE user_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                string[] teamList = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                bool read;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    do
                    {
                        int NumberOfRows = reader.GetValues(teamList);
                        for (int i = 0; i < NumberOfRows; i++)
                        {
                            teams += teamList[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
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

        //<-----------------------------------USERSTORY READERS------------------------------>
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
        public String DBUserStoryProjectReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT projects.project_nimi FROM projects INNER JOIN user_stories ON projects.project_id = user_stories.project_id WHERE user_stories.user_story_nimi='" + name + "';");
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
        public String DBUserStoryInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_story_info FROM user_stories WHERE user_story_nimi='" + name + "';");
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
        public String DBUserStoryTaskReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT tasks.task_nimi from user_stories INNER JOIN tasks ON tasks.user_story_id = user_stories.user_story_id WHERE user_stories.user_story_nimi='" + name + "';");
                cmd.Connection = con;
                string userStoryTasks = String.Empty;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userStoryTasks += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userStoryTasks;
            }
        }
        public String DBUserStoryTaskStateReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT tasks.task_tila from user_stories INNER JOIN tasks ON tasks.user_story_id = user_stories.user_story_id WHERE user_stories.user_story_nimi='" + name + "';");
                cmd.Connection = con;
                string userStoryTasks = String.Empty;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userStoryTasks += reader.GetInt32(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userStoryTasks;
            }
        }
        public String DBUserStoryInSprintReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT DISTINCT user_stories.user_story_nimi FROM (user_stories INNER JOIN tasks ON user_stories.[user_story_id] = tasks.[user_story_id]) INNER JOIN sprints ON sprints.[sprint_id] = tasks.[sprint_id] WHERE sprints.sprint_nimi='" + name + "';");
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

        //<-----------------------------------TASK READERS------------------------------------>
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
        public String DBTaskUserStoryReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_stories.user_story_nimi FROM tasks INNER JOIN user_stories ON tasks.user_story_id = user_stories.user_story_id WHERE tasks.task_nimi='" + name + "';");
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
        public String DBTaskSprintReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT sprints.sprint_nimi FROM tasks INNER JOIN sprints ON tasks.sprint_id = sprints.sprint_id WHERE tasks.task_nimi='" + name + "';");
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
        public String DBTaskUserReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT users.user_nimi FROM tasks INNER JOIN users ON users.user_id = tasks.user_id WHERE tasks.task_nimi='" + name + "';");
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
        public String DBTaskInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT task_info FROM tasks WHERE task_nimi='" + name + "';");
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
        public String DBTaskPrioReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT task_prioriteetti FROM tasks WHERE task_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teams += reader.GetInt32(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teams;
            }
        }
        public String DBTaskStateReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT task_tila FROM tasks WHERE task_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teams += reader.GetInt32(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teams;
            }
        }
        public String DBTaskDifficultyReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT task_vaikeustaso FROM tasks WHERE task_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teams += reader.GetInt32(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teams;
            }
        }
        public String DBTaskDurationReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT task_kesto FROM tasks WHERE task_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskKesto = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskKesto += reader.GetInt32(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskKesto;
            }
        }
        public DateTime DBTaskStartDateReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT task_aloitus_pvm FROM tasks WHERE task_nimi='" + name + "';");
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
        public DateTime DBTaskEndDateReader() 
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT task_lopetus_pvm FROM tasks WHERE task_nimi='" + name + "';");
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

        //<-----------------------------------TEAM READERS------------------------------------>
        public String DBTeamUserReader()
        {
            {
                using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
                {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                    OleDbCommand cmd;
                    cmd = new OleDbCommand("SELECT users.user_nimi FROM users INNER JOIN (teams INNER JOIN users_teams_link ON teams.[team_id] = users_teams_link.[team_id]) ON users.[user_id] = users_teams_link.[user_id] WHERE teams.team_nimi ='" + name + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    string users = String.Empty;    //Kerätään nimet tähän tyhjään stringiin.

                    string[] userlist = new string[20];     //20 on ihan satunnainen numero, lopullinen numero on varmasti toinen.
                    bool read;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        do
                        {
                            int NumberOfRows = reader.GetValues(userlist);
                            for (int i = 0; i < NumberOfRows; i++)
                            {
                                users += userlist[i].ToString() + "\n"; //Nimet kerätään projectlist-taulukkoon josta ne siirretään users-stringiin omille riveilleen.
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
        public String DBTeamProjectReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_nimi FROM projects INNER JOIN teams ON projects.project_id = teams.project_id WHERE teams.team_nimi='" + name + "';");
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
        public String DBTeamInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT team_info FROM teams WHERE teams.team_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teaminfo = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teaminfo += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teaminfo;
            }
        }

        //<------------------------------------ID READERS------------------------------------->
        public Int32 ProjectIdReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_id FROM projects WHERE project_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                int i = 0;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i += reader.GetInt32(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return i; 
            }
        }
        public Int32 SprintIdReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_id FROM sprints WHERE sprint_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                int i = 0;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i += reader.GetInt32(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return i;
            }
        }
        public Int32 UserStoryIdReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT user_story_id FROM user_stories WHERE user_story_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                int i = 0;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i += reader.GetInt32(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return i;
            }
        }
        public Int32 UserIdReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT user_id FROM users WHERE user_nimi='" + name + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                int i = 0;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i += reader.GetInt32(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return i;
            }
        }
        public Int32 TeamIdReader()
        {
            {
                using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
                {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                    OleDbCommand cmd;
                    cmd = new OleDbCommand("SELECT team_id FROM teams WHERE team_nimi='" + name + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    int i = 0;

                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        i += reader.GetInt32(0);
                    }
                    reader.Close();
                    cmd.ExecuteNonQuery();

                    return i;
                }
            }
        }
    }
}
