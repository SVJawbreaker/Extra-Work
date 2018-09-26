using System;
using System.IO;

namespace Task_3
{
    class Golem : Unit
    {
        Random r = new Random();

        public Golem(int Xpos, int Ypos, string faction, string symbol, string name) : base(Xpos, Ypos, faction, symbol, name)
        {
            this.XPos = Xpos;
            this.YPos = Ypos;
            this.hp = r.Next(50, 151);
            this.atk = r.Next(1, 11);
            this.range = 1;
            this.faction = faction;
            this.symbol = symbol;
            this.name = name;
            this.maxHP = MaxHP = Hp;
            this.attacking = Attacking = false;
        }

        public override string ToString()
        {
            string[] unitType = GetType().ToString().Split('.');
            string myType = unitType[unitType.Length - 1];

            return Faction + "," + Name + "," + myType + "," + (XPos + 1) + "," + (YPos + 1) + "," + Hp;
        }

        public override Unit GetClosestUnit(Unit[] units)
        {
            int tempDistance = 500;
            int Distance = tempDistance;
            Unit returnedUnit = null;

            for (int k = 0; k < units.Length; k++) //distance = ((Xa - Xb)^2 + (Ya - Yb)^2)^1/2
            {
                if (units[k] != null && units[k] != this && units[k].Hp > 0 && units[k].Faction != this.faction)
                    Distance = ((this.XPos - units[k].XPos) ^ 2 + (this.YPos - units[k].YPos) ^ 2) ^ 1 / 2;
                if (Distance < 0)
                    Distance = Math.Abs(Distance);
                if (Distance < tempDistance)
                {
                    tempDistance = Distance;
                    returnedUnit = units[k];
                }
            }
            return returnedUnit;
        }

        public override void GoToEnemy(Unit enemy)
        {
            if (enemy != null)
            {
                int distanceX = (enemy.XPos - XPos);
                int distanceY = (enemy.YPos - YPos);

                if (Math.Abs(distanceX) < Math.Abs(distanceY))
                {
                    if (distanceX < 0)
                        XPos--;
                    else if (distanceX > 0)
                        XPos++;
                }
                else if (Math.Abs(distanceY) < Math.Abs(distanceX))
                {
                    if (distanceY < 0)
                        YPos--;
                    else if (distanceX > 0)
                        YPos++;
                }
            }
        }

        public override bool EnemyInRange(Unit enemy)
        {
            int distance = 500;

            if (enemy != null)
                distance = ((XPos - enemy.XPos) ^ 2 + (YPos - enemy.YPos) ^ 2) ^ 1 / 2;
            if (distance <= this.range)
                return true;
            else
                return false;
        }

        public override int Attack()
        {
            return this.Atk;
        }

        public override void RunAway() //1 up, 2 right, 3 left, 4 down
        {
            bool valid = false;
            int move = 0;
            while (valid == false)
            {
                move = r.Next(1, 5);
                if (YPos == 0 && move == 1)
                    valid = false; //Can't move up
                else if (XPos == 19 && move == 2)
                    valid = false; //Can't move right
                else if (YPos == 19 && move == 3)
                    valid = false; //Can't move down
                else if (XPos == 0 && move == 4)
                    valid = false; //Can't move left
                else
                    valid = true;
            }

            switch (move)
            {
                case 1:
                    YPos--; //Up
                    break;
                case 2:
                    XPos++; //Right
                    break;
                case 3:
                    YPos++; //Down
                    break;
                case 4:
                    XPos--; //Left
                    break;
            }

        }

        public override void SaveUnits()
        {
            FileStream file = new FileStream("saves/unit.file", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ToString());
            writer.Close();
            file.Close();
        }
    }
}
