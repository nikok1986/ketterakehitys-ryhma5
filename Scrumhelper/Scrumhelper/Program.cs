using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumhelper
{
    internal class Program
    {
        public class Administration
        {
            private int AdminID;
            private Projekti[] projektit;
            private Tiimi[] tiimit;
            private Kayttaja[] kayttajat;
            private Kayttajatarina[] kayttajatarinat;
            private Tehtava[] tehtavat;

            private int MAX_NMB = 10000;           

            public Administration()
            {
                AdminID = 0000;
                projektit = new Projekti[MAX_NMB];
                tiimit = new Tiimi[MAX_NMB];
                kayttajat = new Kayttaja[MAX_NMB];
                kayttajatarinat = new Kayttajatarina[MAX_NMB];
                tehtavat = new Tehtava[MAX_NMB];
            }
            public bool AddProjekti(Projekti pj)
            {
                int n = 0;
                while (n < MAX_NMB)
                    n++;
                if (n < MAX_NMB)
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
                while (n < MAX_NMB)
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
            private Tiimi[] tiimit;

            private int MAX_NMB = 10000;

            public Projekti()
            {
                projektiID = 0000;
                nimi = null;
                projektiInfo = null;
                tiimit = new Tiimi[MAX_NMB];
                aloitusPvm = DateTime.Now;
                lopetusPvm = DateTime.Now;
            }
            public bool AddTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_NMB)
                    n++;
                if (n < MAX_NMB)
                {
                    tiimit[n] = tm;
                    return true;
                }
                else
                    return false;
            }
            public void RemoveTiimi(Tiimi tm)
            {
                int n = 0;
                while (n < MAX_NMB)
                {
                    if (tiimit[n] == tm)
                        tiimit[n] = null;
                    n++;
                }
            }
        }
        public class Sprintti
        {
            private int SprinttiID;
            private string nimi;
            private string sprinttiInfo;
            private DateTime aloitusPvm;
            private DateTime lopetusPvm;

            public Sprintti()
            {
                SprinttiID = 0000;
                nimi= null;
                sprinttiInfo = null;
                aloitusPvm = DateTime.Now;
                lopetusPvm = aloitusPvm.AddDays(14);
            }
        }
        public class Tiimi
        {
            private int tiimiID;
            private string nimi;
            private string tiimiInfo;
            

            public Tiimi()
            {
                tiimiID = 0000;
                nimi = null;
                tiimiInfo = null;
            }
        }
        public class Kayttaja
        {
            private int kayttajaID;
            private string nimi;
            private string rooli;
            

            public Kayttaja()
            {
                kayttajaID = 0000;
                nimi = null;
                rooli = null;
            }
        }
        public class Kayttajatarina
        {
            private int storyID;
            private string nimi;
            private string storyInfo;
            private int prioriteettiTaso;
            private int tila;

            public Kayttajatarina()
            {
                storyID = 0000;
                nimi = null;
                storyInfo = null;
                prioriteettiTaso = 0;
                tila = 0;
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
        }
        static void Main(string[] args)
        {
        }
    }
}
