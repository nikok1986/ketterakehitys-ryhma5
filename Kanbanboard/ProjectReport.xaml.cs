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
        public String StoryState()
        {
            string phaseList = DBUserStoryPhaseReader();    //tämä metodi vaihtaa tilaa kuvaavia numeroita täynnä olevan stringin stringiksi, jossa numerot on esitetty sanoina
            string[] stateList = phaseList.Split('\n');
            string finalList = String.Empty;

            for (int i = 0; i < stateList.Length; i++) 
            {
                if (stateList[i] == "0")
                {
                    finalList += "backlogissa" + "\n";
                }
                if (stateList[i] == "1")
                {
                    finalList += "sprintissä" + "\n";
                }
                if (stateList[i] == "2")
                {
                    finalList+= "valmis" + "\n";
                }
            }
            return finalList;
        }
        public void ProjectState(object sender, EventArgs e)   //lasketaan valmiiden tehtävien määrä ja jaetaan se tehtävien kokonaismäärällä,saadaan projektin valmiusaste
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
        public void UpdateLists(object sender, EventArgs e)
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
                OleDbCommand cmd; //ideana on asettaa user storyn tila tietokannassa 0, 1 tai 2 sen perusteella missä tilassa siihen liitetyt tehtävät ovat
                Reader reader = new Reader(pjName); //tehdään reader-sivu ja syötetään sille tälle sivulle syötetty projewktin nimi
                string[] userstoryNames = reader.DBUserStoryReader().Split('\n');   //käytetään readeriin kirjoitettua metodia, joka lukee kaikki käyttäjätarinat, splitataan rivinvaihdosta
                int aloittamatta = 0;   //kolme tilaa, jotka taskeilla voi olla
                int tyonAlla = 1;
                int valmis = 2;
                string result = string.Empty; //kerätään tieto taas kerran tyhjään stringiin

                for (int i = 0; i < userstoryNames.Length; i++) //loopataan läpi koko äsken tehty userstoryNames-array
                {
                    reader = new Reader(userstoryNames[i]); //muutetaan readerin syötettä, annetaan loopissa sillä hetkellä olevan käyttäjätarinan nimi
                    result = reader.DBUserStoryTaskStateReader(); //DBUserStoryTaskReader käyttää syötteenä annettua käyttäjätarinan nimeä hakemaan siihen liittyvien taskien tilat

                    if (!result.Contains("1") && !result.Contains("2")) //eli jos string EI sisällä 1 tai 2, se sisältää pelkkiä nollia = user storyn tila on siis myös 0 eli aloittamatta tai aivan alussa
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 0 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    if (!result.Contains("0") && !result.Contains("1")) //jos EI sisällä 0 tai 1, kaikkien tehtävien on siis pakko olla 2, eli user storyn tila = 2
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 2 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    else    //kaikissa muissa tapauksissa, eli niissä, jossa string sisältää kaiken tyyppisiä lukuja, asetataan user storyn tilaksi 1 eli työn alla
                    {
                        cmd = new OleDbCommand("UPDATE user_stories SET user_story_tila = 1 WHERE user_story_nimi='" + userstoryNames[i] + "';");
                    }
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();  //suorituksen jälkeen loopataan seuraavan user storyn taskit samalla tavalla
                }
            }
        }
        public void UserStoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserStoryPhase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
