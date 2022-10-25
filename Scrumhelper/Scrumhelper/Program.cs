using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using static Scrumhelper.Program;

namespace Scrumhelper
{
    internal class Program
    {
        public class Administration
        {
            private int AdminID;
            private Projekti[] projektit;
            
            private int MAX_PRJCT = 20;      

            public Administration()
            {
                AdminID = 0000;
                projektit = new Projekti[MAX_PRJCT];
            }
            public bool AddProjekti(Projekti pj)
            {
                int n = 0;
                while (n < MAX_PRJCT)
                    n++;
                if (n < MAX_PRJCT)
                {
                    projektit[n] = pj;
                    return true; 
                }
                else
                return false;
            }
            public void RemoveProjekti(Projekti pj)
            {
                int n = 0;
                while (n < MAX_PRJCT)
                {
                    if (projektit[n] == pj)
                        projektit[n] = null;
                    n++;
                }
            }
        }
        public class Projekti
        {
            private int projektiID;
            private string nimi;
            private string projektiInfo;
            private DateTime aloitusPvm;
            private DateTime lopetusPvm;
            private Tiimi[] tiimi;
            private Sprintti[] sprintti;
            private int MAX_TEAM = 100;
            private int MAX_NMB = 9999;

            public Projekti()
            {
                projektiID = 0000;
                nimi = null;
                projektiInfo = null;
                tiimi = new Tiimi[MAX_TEAM];
                sprintti = new Sprintti[MAX_NMB];
                aloitusPvm = DateTime.Now;
                lopetusPvm = DateTime.Now;
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    projektiID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public bool AddTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_TEAM)
                    n++;
                if (n < MAX_TEAM)
                {
                    tiimi[n] = tm;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_TEAM)
                {
                    if (tiimi[n] == tm)
                        tiimi[n] = null;
                    n++;
                }
            }
            public bool AddSprintti(Sprintti spr)
            {
                int n = 0;
                while (n < MAX_NMB)
                    n++;
                    if (n < MAX_NMB)
                    {
                        sprintti[n] = spr;
                        return true;
                    }
                    else
                        return false;
            }
            public void RemoveSprintti(Sprintti spr)
            {
                int n = 0;
                while (n < MAX_NMB)
                {
                    if (sprintti[n] == spr)
                        sprintti[n] = null;
                    n++;
                }
            }
            public void SetProjektiInfo (string info)
            {
                projektiInfo = info;
            }
            public string GetProjektiInfo()
            { 
                StringBuilder sb = new StringBuilder(projektiInfo + " Projektin tiimit: ");
                sb.AppendLine();
                foreach (Tiimi tm in tiimi)
                    if (tm != null)
                        sb.AppendLine(tm.ToString());
                return sb.ToString(); 
            }
        }
        public class Sprintti
        {
            private int SprinttiID;
            private string nimi;
            private string sprinttiInfo;
            private DateTime aloitusPvm;
            private DateTime lopetusPvm;
            private Kayttajatarina[] kayttajatarinat;
            private int MAX_STORY = 9999;
            
            public Sprintti()
            {
                kayttajatarinat = new Kayttajatarina[MAX_STORY];
                SprinttiID = 0000;
                nimi= null;
                sprinttiInfo = null;
                aloitusPvm = DateTime.Now;
                lopetusPvm = aloitusPvm.AddDays(14);
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    SprinttiID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public void SetStoryInfo(string info)
            {
                sprinttiInfo = info;
            }
            public bool AddKayttajatarina(Kayttajatarina story)
            {
                int n = 0;
                while (n < MAX_STORY)
                    n++;
                if (n < MAX_STORY)
                {
                    kayttajatarinat[n] = story;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveKayttajatarina(Kayttajatarina story)
            {
                int n = 0;
                while (n < MAX_STORY)
                {
                    if (kayttajatarinat[n] == story)
                        kayttajatarinat[n] = null;
                    n++;
                }
            }
        }
        public class Tiimi
        {
            private int tiimiID;
            private string nimi;
            private string tiimiInfo;
            private Kayttaja[] kayttaja;
            private int MAX_USER = 500;

            public Tiimi()
            {
                kayttaja = new Kayttaja[MAX_USER];
                tiimiID = 0000;
                nimi = null;
                tiimiInfo = null;
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    tiimiID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public void SetTiimiInfo(string info)
            {
                tiimiInfo = info;
            }
            public void SetNimi(string name)
            {
                name = nimi;
            }
            public bool AddKayttaja(Kayttaja user)
            {
                int n = 0;
                while (n < MAX_USER)
                    n++;
                if (n < MAX_USER)
                {
                    kayttaja[n] = user;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveKayttaja(Kayttaja user)
            {
                int n = 0;
                while (n < MAX_USER)
                {
                    if (kayttaja[n] == user)
                        kayttaja[n] = null;
                    n++;
                }
            }
        }
        public class Kayttaja
        {
            private int kayttajaID;
            private string nimi;
            private string rooli;
            private Tehtava[] tehtavat;
            private Tiimi[] tiimi;
            private int MAX_TASK = 10;
            private int MAX_TEAM = 100;


            public Kayttaja()
            {
                tehtavat = new Tehtava[MAX_TASK];
                tiimi = new Tiimi[MAX_TEAM];
                kayttajaID = 0000;
                nimi = null;
                rooli = null;
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    kayttajaID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public void SetNimi(string name)
            {
                nimi = name;
            }
            public void SetRooli(string role)
            {
                rooli = role;
            }
            public bool AddTehtava(Tehtava task)
            {
                int n = 0;
                while (n < MAX_TASK)
                    n++;
                if (n < MAX_TASK)
                {
                    tehtavat[n] = task;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveTehtava(Tehtava task)
            {
                int n = 0;
                while (n < MAX_TASK)
                {
                    if (tehtavat[n] == task)
                        tehtavat[n] = null;
                    n++;
                }
            }
            public bool AddTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_TEAM)
                    n++;
                if (n < MAX_TEAM)
                {
                    tiimi[n] = tm;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_TEAM)
                {
                    if (tiimi[n] == tm)
                        tiimi[n] = null;
                    n++;
                }
            }
        }
        public class Kayttajatarina
        {
            private int storyID;
            private string nimi;
            private string storyInfo;
            private int prioriteettiTaso;
            private int tila;
            private Tehtava[] tehtavat;
            private int MAX_TASK = 10;

            public Kayttajatarina()
            {
                tehtavat = new Tehtava[MAX_TASK];
                storyID = 0000;
                nimi = null;
                storyInfo = null;
                prioriteettiTaso = 0;
                tila = 0;
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    storyID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public void SetStoryInfo(string info)
            {
                storyInfo = info;
            }
            public bool AddTehtava(Tehtava task)
            {
                int n = 0;
                while (n < MAX_TASK)
                    n++;
                if (n < MAX_TASK)
                {
                    tehtavat[n] = task;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveTehtava(Tehtava task)
            {
                int n = 0;
                while (n < MAX_TASK)
                {
                    if (tehtavat[n] == task)
                        tehtavat[n] = null;
                    n++;
                }
            }
            public string GetStoryInfo()
            {
                StringBuilder sb = new StringBuilder(storyInfo + "\nKäyttäjätarinan tehtävät: ");
                sb.AppendLine();
                foreach (Tehtava task in tehtavat)
                    if (task != null)
                        sb.AppendLine(task.ToString());
                return sb.ToString();
            }
            public void SetPrioriteetti(int i)
            {
                if (prioriteettiTaso >= 0 && prioriteettiTaso <= 5)
                {
                    prioriteettiTaso = i;
                }
                else
                    prioriteettiTaso = 0;
            }
            public double CheckTila()
            {
                int i = 0;
                int j = 0;
                for (int k = 0; k < MAX_TASK; k++)
                {
                    if (tehtavat[k] != null && tehtavat[k].CheckState() == true)
                    {
                        i++;
                    }
                }
                for (int l = 0; l < MAX_TASK; l++)
                {
                    if (tehtavat[l] != null)
                        j++;
                }
                return (i / j) * 100;
            }
        }
        public class Tehtava
        {
            private int taskID;
            private string nimi;
            private int tila;
            private string tehtavaInfo;
            private int prioriteettiTaso;
            private string kategoria;
            private int vaikeustaso;
            private double taskKesto;
            private DateTime aloitusPvm;
            private DateTime lopetusPvm;
            

            public Tehtava()
            {
                taskID = 0000;
                nimi = null;
                tila = 0;
                tehtavaInfo = null;
                prioriteettiTaso= 0;
                kategoria = null;
                vaikeustaso = 0;
                taskKesto = 0;
                aloitusPvm = DateTime.Now;
                lopetusPvm = DateTime.Now;
            }
            public string SetId(int i)
            {
                if (i >= 0 && i <= 9999)
                {
                    taskID = i;
                    return "ID added.";
                }
                else
                    return "Id needs to be a number between 0000 and 9999";
            }
            public void SetNimi(string name)
            {
                name = nimi;
            }
            public void SetTehtavaInfo(string info)
            {
                tehtavaInfo = info;
            }
            public string GetTehtavaInfo()
            {
                return tehtavaInfo + "\nTila: " + tila + "\nPrioriteetti: " + prioriteettiTaso + "\nKategoria: " + kategoria + "\nVaikeustaso: " + vaikeustaso + "\nArvioitu kesto: " + taskKesto + "\nAloituspvm: " + aloitusPvm;
            }
            public void SetTila(int i)
            {
                if (tila >= 0 && tila <= 1)
                {
                    tila = i;
                }
                else
                    tila = 0;
            }
            public bool CheckState()
            {
                if (tila == 0)
                    return false;
                if (tila == 1)
                    return true;
                else
                    return false;
            }
            public void SetPrioriteetti(int i)
            {
                if (prioriteettiTaso >= 0 && prioriteettiTaso <= 5)
                {
                    prioriteettiTaso = i;
                }
                else
                    prioriteettiTaso = 0;
            }
            public void SetKategoria(string kat)
            {
                kategoria = kat;
            }
            public void SetVaikeustaso(int diff)
            {
                if (diff >= 0 && diff <= 5)
                {
                    vaikeustaso = diff;
                }
                else
                    vaikeustaso = 0;
            }
            public void SetTaskKesto(double time)
            {
                taskKesto = time;
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
