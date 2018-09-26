namespace Task_3
{
    abstract partial class Unit
    {
        protected int xPos;
        protected int yPos;
        protected int hp;
        protected int atk;
        protected int range;
        protected string faction;
        protected string symbol;
        protected string name;
        protected int maxHP;
        protected bool attacking;

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Range { get => range; set => range = value; }
        public string Faction { get => faction; set => faction = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public string Name { get => name; set => name = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public bool Attacking { get => attacking; set => attacking = value; }

        public Unit(int Xpos, int Ypos, string faction, string symbol, string name)
        {
        }

        public abstract Unit GetClosestUnit(Unit[] units);

        public abstract bool EnemyInRange(Unit enemy);

        public abstract void GoToEnemy(Unit enemy);

        public abstract int Attack();

        public abstract void RunAway();

        public abstract void SaveUnits();

    }
}
