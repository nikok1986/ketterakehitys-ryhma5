using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Shapes;

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for ProjectReport.xaml
    /// </summary>
    public partial class ProjectReport : Window
    {
        string pjName;
        public ProjectReport(string projectName)
        {
            InitializeComponent();
            pjName = projectName;
            Loaded += UserStoryTilaSetter;
            Loaded += UpdateLists;
            Loaded += ProjectState;
        }
        public String DBUserStoryReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_stories.user_story_nimi FROM projects INNER JOIN user_stories ON projects.project_id = user_stories.project_id WHERE projects.project_nimi='" + pjName + "';");
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
        public String DBUserStoryPhaseReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_stories.user_story_tila FROM projects INNER JOIN user_stories ON projects.project_id = user_stories.project_id WHERE projects.project_nimi='" + pjName + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string userstories = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userstories += reader.GetInt32(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userstories;
            }
        }
        private String StoryState()
        {
            string phaseList = DBUserStoryPhaseReader();
            string[] stateList = phaseList.Split('\n');
            string finalList = String.Empty;

            for (int i = 0; i < stateList.Length; i++) 
            {
                if (stateList[i] == "0" || stateList[i] == "1")
                {
                    finalList += "kesken" + "\n";
                }
                if (stateList[i] == "2")
                {
                    finalList+= "valmis" + "\n";
                }
            }
            return finalList;
        }
        private void ProjectState(object sender, EventArgs e)
        {
            string[] allStories = StoryState().Split("\n");
            decimal storyCount = allStories.Count() - 1;
            decimal i = 0;
            
            for (int j = 0; j < allStories.Length; j++) 
            {
                if (allStories[j] == "valmis")
                    i++;
            }
            if (storyCount > 0)
            {
                decimal percent = i / storyCount * 100;
                CompletionState.Text = "Projekti \"" + pjName + "\" on " + Math.Round(percent, 1).ToString() + " % valmis.";
            }
            else
            {
                CompletionState.Text = "Projektia ei ole aloitettu.";
            }
        }
        private void UpdateLists(object sender, EventArgs e)
        {
            UserStoryList.Items.Clear();
            string[] stories = DBUserStoryReader().Split('\n');
            foreach (string s in stories)
                UserStoryList.Items.Add(s);

            UserStoryPhase.Items.Clear();
            string[] storyID = StoryState().Split('\n');
            foreach (string s in storyID)
                UserStoryPhase.Items.Add(s);
        }
        public void UserStoryTilaSetter(object sender, EventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())
            {
                OleDbCommand cmd;
                Reader reader = new Reader(pjName);
                string[] userstoryNames = reader.DBUserStoryReader().Split('\n');
                int aloittamatta = 0;
                int tyonAlla = 1;
                int valmis = 2;
                string result = string.Empty;

                for (int i = 0; i < userstoryNames.Length; i++)
                {
                    reader = new Reader(userstoryNames[i]);
                    result = reader.DBUserStoryTaskStateReader();

                    if (!result.Contains(tyonAlla.ToString()) && !result.Contains(valmis.ToString()))
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 0 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    if (!result.Contains(aloittamatta.ToString()) && !result.Contains(tyonAlla.ToString()))
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 2 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    else
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 1 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void UserStoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserStoryPhase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
