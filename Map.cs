using System.IO;
using System;

namespace Task_3
{

    class Map
    {
        public string[,] GameMap = new string[20,20];
        public Unit[] units = new Unit[10];
        public Building[] buildings = new Building[10];
        public string[] Names = new string[] { "Jeff", "Scotty", "Corey", "Stylo", "Vorn", "Jawbreaker", "Death", "War", "Famine", "Waldo", "Neo", "Tron", "Knuckles", "Bob", "Drake", "Jake", "Ken_is_gay", "Liam" , "Ezio", "Altair", "Jimmy", "Spencer"};

        Random rnd = new Random();


        public Map()
        {

        }

        public void GenMap()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    GameMap[y, x] = " ";
                }
            }
        }

        public void PopulateMap()
        {
            UnitSpawner();
            BuildingSpawner();

            for (int k = 0; k < units.Length; k++)
            {
                Console.WriteLine(units[k].ToString());
            }
            for (int k = 0; k < buildings.Length; k++)
            {
                Console.WriteLine(buildings[k].ToString());
            }
        }

        public void UnitSpawner()
        {
            for (int k = 0; k < units.Length; k++)
            {
                int UnitType;
                int Faction;
                int name = rnd.Next(0, Names.Length);

                string assignedFaction = "";
                string assignedSymbol = "";
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                UnitType = rnd.Next(1, 7);

                switch (UnitType)
                {
                    case 1: //Melee Unit
                        Faction = rnd.Next(1, 3);
                        switch (Faction)
                        {
                            case 1: //Blue Team
                                assignedFaction = "Oosorion";
                                assignedSymbol = "M";
                                break;

                            case 2: //Red Team
                                assignedFaction = "Asobaxian";
                                assignedSymbol = "m";
                                break;
                        }
                        units[k] = new MeleeUnit(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;

                    case 2: //Range Unit
                        Faction = rnd.Next(1, 3);
                        switch (Faction)
                        {
                            case 1: //Blue Team
                                assignedFaction = "Oosorion";
                                assignedSymbol = "R";
                                break;

                            case 2: //Red Team
                                assignedFaction = "Asobaxian";
                                assignedSymbol = "r";
                                break;
                        }
                        units[k] = new RangeUnit(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;

                    case 3: //Horseman
                        Faction = rnd.Next(1, 3);
                        switch (Faction)
                        {
                            case 1: //Blue Team
                                assignedFaction = "Oosorion";
                                assignedSymbol = "H";
                                break;

                            case 2: //Red Team
                                assignedFaction = "Asobaxian";
                                assignedSymbol = "h";
                                break;
                        }
                        units[k] = new HorseMan(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;

                    case 4: //Wizard
                        Faction = rnd.Next(1, 3);
                        switch (Faction)
                        {
                            case 1: //Blue Team
                                assignedFaction = "Oosorion";
                                assignedSymbol = "W";
                                break;

                            case 2: //Red Team
                                assignedFaction = "Asobaxian";
                                assignedSymbol = "w";
                                break;
                        }
                        units[k] = new Wizard(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;

                    case 5: //Peasant
                                assignedFaction = "Civilian";
                                assignedSymbol = "*";
                        units[k] = new Villager(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;

                    case 6: //Golem
                        assignedFaction = "Civilian";
                        assignedSymbol = "@";
                        units[k] = new Golem(x, y, assignedFaction, assignedSymbol, Names[name]);
                        break;
                }
                GameMap[units[k].YPos, units[k].XPos] = units[k].Symbol;
            }
        }

        public void BuildingSpawner()
        {
            int k = 0;
            int Faction;

            string assignedFaction = "";
            string assignedSymbol = "";

            buildings[k] = new FactoryBuilding(0, 0, "Oosorion", "F");
            GameMap[buildings[k].YPos, buildings[k].XPos] = buildings[k].Symbol;
            k++;
            buildings[k] = new FactoryBuilding(19, 19, "Asobaxian", "f");
            GameMap[buildings[k].YPos, buildings[k].XPos] = buildings[k].Symbol;

            for (int l = 2; l < buildings.Length - 4; l++) //Creating Resource Buildings
            {
                Faction = rnd.Next(1, 3);
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                switch (Faction)
                {
                    case 1: //BlueTeam
                        assignedFaction = "Oosorion";
                        assignedSymbol = "G";
                        break;

                    case 2: //Red Team
                        assignedFaction = "Asobaxian";
                        assignedSymbol = "g";
                        break;
                }

                buildings[l] = new ResourceBuilding(x, y, assignedFaction, assignedSymbol);
                GameMap[buildings[l].YPos, buildings[l].XPos] = buildings[l].Symbol;
            }

            for (int l = 6; l < buildings.Length; l++)
            {
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);
                assignedFaction = "Civillian";
                assignedSymbol = "#";

                buildings[l] = new VillageHouse(x, y, assignedFaction, assignedSymbol);
                GameMap[buildings[l].YPos, buildings[l].XPos] = buildings[l].Symbol;
            }
        }
        public void Load()
        {
            string[] unitFile = File.ReadAllLines("saves/unit.file");
            units = new Unit[unitFile.Length];

            string loadedFaction = "";
            string loadedSymbol = "";
            string loadedName = "";
            int loadedXPos;
            int loadedYPos;

            for (int k = 0; k < unitFile.Length; k++)
            {
                string[] unitRead = unitFile[k].Split(',');
                if (unitRead[0] == "Oosorion") //BlueTeam unit
                {
                    loadedName = unitRead[1];
                    loadedXPos = Convert.ToInt32(unitRead[3]) - 1;
                    loadedYPos = Convert.ToInt32(unitRead[4]) - 1;
                    loadedFaction = unitRead[0];
                    if (unitRead[2] == "MeleeUnit")
                    {
                        loadedSymbol = "M";
                        units[k] = new MeleeUnit(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "RangeUnit")
                    {
                        loadedSymbol = "R";
                        units[k] = new RangeUnit(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "HorseMan")
                    {
                        loadedSymbol = "H";
                        units[k] = new HorseMan(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "Wizard")
                    {
                        loadedSymbol = "W";
                        units[k] = new Wizard(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    units[k].Hp = Convert.ToInt32(unitRead[5]);
                }

                else if (unitRead[0] == "Asobaxian") //RedTEam unit
                {
                    loadedName = unitRead[1];
                    loadedXPos = Convert.ToInt32(unitRead[3]) - 1;
                    loadedYPos = Convert.ToInt32(unitRead[4]) - 1;
                    loadedFaction = unitRead[0];
                    if (unitRead[2] == "MeleeUnit")
                    {
                        loadedSymbol = "m";
                        units[k] = new MeleeUnit(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "RangeUnit")
                    {
                        loadedSymbol = "r";
                        units[k] = new RangeUnit(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "HorseMan")
                    {
                        loadedSymbol = "h";
                        units[k] = new HorseMan(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if (unitRead[2] == "Wizard")
                    {
                        loadedSymbol = "w";
                        units[k] = new Wizard(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    units[k].Hp = Convert.ToInt32(unitRead[5]);
                }

                else //Neutral unit
                {
                    loadedName = unitRead[1];
                    loadedXPos = Convert.ToInt32(unitRead[3]) - 1;
                    loadedYPos = Convert.ToInt32(unitRead[4]) - 1;
                    loadedFaction = unitRead[0];
                    if (unitRead[2] == "Villager")
                    {
                        loadedSymbol = "*";
                        units[k] = new Villager(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);
                    }
                    else if(unitRead[2] == "Golem")
                    {
                        loadedSymbol = "@";
                        units[k] = new Golem(loadedXPos, loadedYPos, loadedFaction, loadedSymbol, loadedName);

                    }
                }
            }

            buildings = new Building[10];
            string[] factoryFile = File.ReadAllLines("saves/factory.file");
            for (int k = 0; k < factoryFile.Length; k++)
            {
                string[] factoryRead = factoryFile[k].Split(',');

                buildings[k] = new FactoryBuilding(0, 0, "", "");
                buildings[k].Faction = factoryRead[0];
                buildings[k].Hp = Convert.ToInt32(factoryRead[4]);

                if (buildings[k].Faction == "Oosorion")
                {
                    buildings[k].Symbol = "F";
                    buildings[k].XPos = Convert.ToInt32(factoryRead[2]) - 1;
                    buildings[k].YPos = Convert.ToInt32(factoryRead[3]) - 1;
                }
                else
                {
                    buildings[k].Symbol = "f";
                    buildings[k].XPos = Convert.ToInt32(factoryRead[2]) - 1;
                    buildings[k].YPos = Convert.ToInt32(factoryRead[3]) - 1;
                }
                
            }


            string[] resourceFile = File.ReadAllLines("saves/resource.file");
            for (int k = 0; k < resourceFile.Length; k++)
            {
                string[] resourceRead = resourceFile[k].Split(',');

                buildings[k + 2] = new ResourceBuilding(0, 0, "a", "a");
                buildings[k + 2].Faction = resourceRead[0];
                buildings[k + 2].XPos = Convert.ToInt32(resourceRead[2]) - 1;
                buildings[k + 2].YPos = Convert.ToInt32(resourceRead[3]) - 1;
                buildings[k + 2].Hp = Convert.ToInt32(resourceRead[4]);

                if (buildings[k + 2].Faction == "Oosorion") buildings[k].Symbol = "G";
                else buildings[k + 2].Symbol = "g";
            }

            string[] villageFile = File.ReadAllLines("saves/village.file");
            for (int k = 0; k < villageFile.Length; k++)
            {
                string[] villageRead = villageFile[k].Split(',');

                buildings[k + 6] = new VillageHouse(0, 0, "a", "a");
                buildings[k + 6].Faction = villageRead[0];
                buildings[k + 6].XPos = Convert.ToInt32(villageRead[2]) - 1;
                buildings[k + 6].YPos = Convert.ToInt32(villageRead[3]) - 1;
                buildings[k + 6].Hp = Convert.ToInt32(villageRead[4]);

                buildings[k + 6].Symbol = "#";
            }
        }
    }

}
