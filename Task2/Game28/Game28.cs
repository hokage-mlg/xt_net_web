using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Game28
    {
        private Player player;
        private Map map;
        private List<Monster> monsters;
        private List<Obstruction> obstructions;
        private List<Bonus> bonuses;
        public Game28()
        {
            map = new Map(100, 100);
            player = new Player();
            monsters = new List<Monster>();
            obstructions = new List<Obstruction>();
            bonuses = new List<Bonus>();
        }
        public void GameRun()
        {
            Console.WriteLine("Game is running...");
            monsters.Add(new Bear());
            monsters.Add(new Wolf());
            obstructions.Add(new Tree());
            obstructions.Add(new Stone());
            bonuses.Add(new Apple());
            bonuses.Add(new Cherry());
        }
        public void PlayerAttack()
        {
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("Player attack {0}", monster.Name);
                player.Hit(monster);
            }
        }
        public void MonstersAttack()
        {
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("{0} attack player", monster.Name);
                monster.Hit(player);
            }
        }
        public void BonusForPlayer()
        {
            foreach (Bonus bonus in bonuses)
                bonus.GiveBonus(player);
        }
        public void CollisionWithObstacle()
        {
            foreach (Obstruction obstruction in obstructions)
                obstruction.Hit(player);
        }
        public void Moving()
        {
            List<IMove> movables = new List<IMove>();
            movables.Add(player);
            foreach (Monster monster in monsters)
                movables.Add(monster);
            foreach (IMove movable in movables)
                movable.Move();
        }
        public void GameDisplay()
        {
            Game28 game = new Game28();
            game.GameRun();
            Console.ReadLine();
            Console.WriteLine("Moving:");
            game.Moving();
            Console.ReadLine();
            Console.WriteLine("Player attack:");
            game.PlayerAttack();
            Console.ReadLine();
            Console.WriteLine("Monsters attack:");
            game.MonstersAttack();
            Console.ReadLine();
            Console.WriteLine("Bonuses for player:");
            game.BonusForPlayer();
            Console.ReadLine();
            Console.WriteLine("Player collision with an obstacle:");
            game.CollisionWithObstacle();
        }
    }
}
