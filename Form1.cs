using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Plz do
/*
 * Create resource types for creating Melee Units and Range Units
 * Melee Resources
 * Range Resources
 */

namespace Task_3
{
    public partial class Form1 : Form
    {
        int Timer = 0;

        int OosorionResources;
        int RedResources;

        GameEngine engine = new GameEngine();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer = 0;
            engine.resources.OosorionResources = 0;
            engine.resources.RedResources = 0;
            engine.map.GenMap();
            engine.map.PopulateMap();
            tmrGameTimer.Start();
            if (btnPause.Text == "RESUME")
            {
                btnPause.Text = "PAUSE";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "PAUSE")
            {
                btnPause.Text = "RESUME";
                tmrGameTimer.Stop();
            }
            else if(btnPause.Text == "RESUME")
            {
                btnPause.Text = "PAUSE";
                tmrGameTimer.Start();
            }
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e) //Game Time
        {
            cmbUnitsStats.Items.Clear();
            cmbUnitsStats.Items.Add("Units----------------------------------------------------------------------------");
            for (int l = 0; l < engine.map.units.Length; l++)
            {
                if (engine.map.units[l] != null)
                cmbUnitsStats.Items.Add(engine.map.units[l].ToString());
            }
            cmbUnitsStats.Items.Add("");
            cmbUnitsStats.Items.Add("Buildings------------------------------------------------------------------------");
            for (int l = 0; l < engine.map.buildings.Length; l++)
            {
                cmbUnitsStats.Items.Add(engine.map.buildings[l].ToString());
            }

            ResourceGen();

            lblOosorionResourcesCounter.Text = "Oosorion Resources: " + OosorionResources;
            lblAsobaxianResourcesCounter.Text = "Asobaxian Resources: " + RedResources;

            if (engine.resources.OosorionResources >= 10)
            {
                //engine.map.buildings[1].BuildUnits(engine.map.units);
                //engine.resources.BlueResources -= r.Next(1, 11);
            }
            if (engine.resources.RedResources >= 10)
            {
                //engine.map.buildings[2].BuildUnits(engine.map.units);
                //engine.resources.RedResources -= r.Next(1, 11);
            }
            engine.PlayGame();

            Timer++;
            lblGameCounter.Text = "Time: " + Timer + "s";
            
            RedrawMap();
        }

        public void RedrawMap()
        {
            lblGameMap.Text = "";
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    lblGameMap.Text += engine.map.GameMap[y, x];
                }
                lblGameMap.Text += Environment.NewLine;
            }
        }
        
        public void ResourceGen()
        {
            for (int k = 2; k < engine.map.buildings.Length; k++)
            {
                if (engine.map.buildings[k].Hp > 0)
                {
                    if (engine.map.buildings[k].Faction == "Oosorion")
                    {
                        engine.resources.GenBlueResource();
                        OosorionResources = engine.resources.OosorionResources;
                    }
                    else
                    {
                        engine.resources.GenRedResource();
                        RedResources = engine.resources.RedResources;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Saved");
            if (Directory.Exists("saves") != true)
            {
                Directory.CreateDirectory("saves");
            }

            FileStream unit = new FileStream("saves/unit.file", FileMode.Create, FileAccess.Write);
            unit.Close();

            FileStream factory = new FileStream("saves/factory.file", FileMode.Create, FileAccess.Write);
            factory.Close();

            FileStream resource = new FileStream("saves/resource.file", FileMode.Create, FileAccess.Write);
            resource.Close();

            FileStream village = new FileStream("saves/village.file", FileMode.Create, FileAccess.Write);
            village.Close();

            FileStream game = new FileStream("saves/game.file", FileMode.Create, FileAccess.Write);
            game.Close();

            //Saves Map details
            FileStream gameFile = new FileStream("saves/game.file", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(gameFile);
            writer.WriteLine(Timer + "," + OosorionResources + "," + RedResources);
            writer.Close();
            gameFile.Close();

            //Saves the units
            for (int k = 0; k < engine.map.units.Length; k++)
            {
                if (engine.map.units[k] != null)
                engine.map.units[k].SaveUnits();
            }
            //Saves the buildings
            for (int k = 0; k < engine.map.buildings.Length; k++)
            {
                engine.map.buildings[k].Savebuildings();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("saves") != true)
            {
                //Saves folder is missing!
                tmrGameTimer.Stop();
                lblGameMap.Text = "Save Directory is missing!";
                lblGameMap.Text += Environment.NewLine;
                lblGameMap.Text += "Failed to load save!";
            }
            else
            {
                Console.WriteLine("Loaded Save");
                engine.map.GenMap();
                engine.map.Load();
                RedrawMap();


                string[] gameFile = File.ReadAllLines("saves/game.file");
                for (int k = 0; k < gameFile.Length; k++)
                {
                    string[] gameRead = gameFile[k].Split(',');
                    Timer = Convert.ToInt32(gameRead[0]);
                    engine.resources.OosorionResources = Convert.ToInt32(gameRead[1]);
                    engine.resources.RedResources = Convert.ToInt32(gameRead[2]);
                }

                cmbUnitsStats.Items.Clear();

                for (int k = 0; k < engine.map.units.Length; k++)
                {
                    cmbUnitsStats.Items.Add(engine.map.units[k].ToString());
                }

                for (int k = 0; k < engine.map.units.Length; k++)
                {
                    Console.WriteLine(engine.map.units[k].ToString());
                }

                tmrGameTimer.Start();
            }
        }
    }
}
