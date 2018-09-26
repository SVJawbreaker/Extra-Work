namespace Task_3
{
    abstract class Building
    {
        protected int xPos;
        protected int yPos;
        protected string faction;
        protected string symbol;
        protected int hp;

        public int Hp { get => hp; set => hp = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public string Faction { get => faction; set => faction = value; }
        public string Symbol { get => symbol; set => symbol = value; }

        //Resource Building variables
        protected int blueResources;
        protected int redResources;

        public int OosorionResources { get => blueResources; set => blueResources = value; }
        public int RedResources { get => redResources; set => redResources = value; }

        public Building(int Xpos, int Ypos, string faction, string symbol)
        {

        }

        public virtual int GenBlueResource()
        {
            return 0;
        }

        public virtual int GenRedResource()
        {
            return 0;
        }

        public virtual void BuildUnits(Unit[] units) //For building units in the factory
        {
        }

        //UnitSpanwer

        public abstract void Savebuildings();
    }
}
