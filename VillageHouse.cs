using System.IO;

namespace Task_3
{
    class VillageHouse : Building
    {
        public VillageHouse(int Xpos, int Ypos, string faction, string symbol) : base(Xpos, Ypos, faction, symbol)
        {
            this.hp = 10;
            this.XPos = Xpos;
            this.YPos = Ypos;
            this.faction = faction;
            this.symbol = symbol;

            this.blueResources = OosorionResources;
            this.redResources = RedResources;
        }

        public override string ToString()
        {
            string[] unitType = GetType().ToString().Split('.');
            string myType = unitType[unitType.Length - 1];

            return Faction + "," + myType + "," + (XPos + 1) + "," + (YPos + 1) + "," + Hp;
        }

        public override void Savebuildings()
        {
            FileStream file = new FileStream("saves/village.file", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ToString());
            writer.Close();
            file.Close();
        }
    }
}
