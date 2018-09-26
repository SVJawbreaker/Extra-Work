using System;

namespace Task_3
{
    class GameEngine
    {
        public Map map = new Map();
        public ResourceBuilding resources = new ResourceBuilding(0, 0, "DEFAULT", "DEFAULT");

        System.Media.SoundPlayer death = new System.Media.SoundPlayer();

        public GameEngine()
        {
            death.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "sounds/death.wav";
        }

        public void PlayGame()
        {
            UnitTurn();

            for (int k = 0; k < map.buildings.Length; k++)
            {
                if (map.buildings[k] != null)
                map.GameMap[map.buildings[k].YPos, map.buildings[k].XPos] = map.buildings[k].Symbol;
            }
        }

        private void UnitTurn()
        {
            for (int k = 0; k < map.units.Length; k++) //Picks a unit for their turn
            {
                if (map.units[k] != null)
                {
                    map.GameMap[map.units[k].YPos, map.units[k].XPos] = " "; //Replaces current unit position with an empty space, just in case the unit moves

                    if (map.units[k].Hp > 0) //Alive
                    {
                        if ((map.units[k].Hp / map.units[k].MaxHP) * 100 <= 25/100) //Running away
                        {
                            map.units[k].RunAway();
                            if (map.units[k].EnemyInRange(map.units[k].GetClosestUnit(map.units)) == true) //Enemy is in range, Unit will attack
                            {
                                for (int a = 0; a < map.units.Length; a++)
                                {
                                    if (map.units[a] == map.units[k].GetClosestUnit(map.units) && map.units[a] != null)
                                        map.units[a].Hp -= map.units[k].Attack();
                                }
                            }

                        }
                        else //Not running away
                        {
                            if (map.units[k].EnemyInRange(map.units[k].GetClosestUnit(map.units)) == true) //Enemy is in range, Unit will attack
                            {
                                for (int a = 0; a < map.units.Length; a++)
                                {
                                    if (map.units[a] == map.units[k].GetClosestUnit(map.units) && map.units[a] != null)
                                        map.units[a].Hp -= map.units[k].Attack();
                                }
                            }
                            else //Go to closest enemy
                                map.units[k].GoToEnemy(map.units[k].GetClosestUnit(map.units));
                        }

                        map.GameMap[map.units[k].YPos, map.units[k].XPos] = map.units[k].Symbol; //Fills current position on the map with unit's symbol
                    }
                    else //Dead
                    {
                        map.GameMap[map.units[k].YPos, map.units[k].XPos] = "✞"; //RIP
                        map.units[k] = null; //Forgotten warrior

                        death.Play(); //Oof
                    }
                }
            }
        }
    }
}
