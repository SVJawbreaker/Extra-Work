using System;
using System.IO;

namespace Task_3
{
    class FactoryBuilding : Building
    {
        Random r = new Random();

        Map map = new Map();
        Unit[] TempUnits;

        public FactoryBuilding(int Xpos, int Ypos, string faction, string symbol) : base(Xpos, Ypos, faction, symbol)
        {
            this.hp = 50;
            this.XPos = Xpos;
            this.YPos = Ypos;
            this.faction = faction;
            this.symbol = symbol;
        }

        public override string ToString()
        {
            string[] unitType = GetType().ToString().Split('.');
            string myType = unitType[unitType.Length - 1];

            return Faction + "," + myType + "," + (XPos + 1) + "," + (YPos + 1) + "," + Hp;
        }

        public override void BuildUnits(Unit[] units)
        {
            int UnitSwitch = 0;

            TempUnits = new Unit[units.Length + 1];

            for (int k = 0; k < map.units.Length; k++)
                TempUnits[k] = map.units[k];

            if (Faction == "BlueTeam")
            {
                    UnitSwitch = r.Next(1, 4);
                    switch (UnitSwitch)
                    {
                        case 1: //Create new Melee Unit
                        units = new Unit[TempUnits.Length + 1];
                        for (int k = 0; k < units.Length; k++)
                            units[k] = TempUnits[k];

                            map.units[TempUnits.Length - 1] = new MeleeUnit(this.XPos, this.YPos, "BlueTeam", "M", map.Names[r.Next(0, map.Names.Length - 1)]);
                            break;
                        case 2: //Create new Range Unit
                            units = new Unit[TempUnits.Length + 1];
                            for (int k = 0; k < units.Length; k++)
                                units[k] = TempUnits[k];

                            units[TempUnits.Length - 1] = new RangeUnit(this.XPos, this.YPos, "BlueTeam", "R", map.Names[r.Next(0, map.Names.Length - 1)]);
                            break;
                        default: //Conserve resources
                            break;
                    }
            }
            else if (Faction == "RedTeam")
            {
                    UnitSwitch = r.Next(1, 4);
                    switch (UnitSwitch)
                    {
                        case 1: //Create new Melee Unit
                            units = new Unit[TempUnits.Length + 1];
                            for (int k = 0; k < units.Length; k++)
                                units[k] = TempUnits[k];

                            units[TempUnits.Length - 1] = new MeleeUnit(this.XPos, this.YPos, "BlueTeam", "M", map.Names[r.Next(0, map.Names.Length - 1)]);
                            break;
                        case 2: //Create new Range Unit
                            units = new Unit[TempUnits.Length + 1];
                            for (int k = 0; k < units.Length; k++)
                                units[k] = TempUnits[k];

                            units[TempUnits.Length - 1] = new RangeUnit(this.XPos, this.YPos, "RedTeam", "r", map.Names[r.Next(0, map.Names.Length - 1)]);
                            break;
                    default: //Conserve resources
                            break;
                    }
            }
        }

        public override void Savebuildings()
        {
            FileStream file = new FileStream("saves/factory.file", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ToString());
            writer.Close();
            file.Close();
        }
    }
}
