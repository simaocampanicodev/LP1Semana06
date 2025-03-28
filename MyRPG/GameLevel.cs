using System;
using System.Collections.Generic;
using Humanizer;

namespace MyRPG
{
    public class GameLevel
    {

        private Hardness difficulty;
        public Hardness GetHardness() => difficulty;

        private int enemyCount;
        public int GetNumRooms() => enemyCount;
        
        private List<Enemy> enemies;
        private int actualEnemies = 0;
        public int GetNumEnemies() => actualEnemies;
        
        public GameLevel(int enemyCount, Hardness difficulty)
        {
            this.difficulty = difficulty;
            this.enemyCount = enemyCount;
            enemies = new List<Enemy>();
            for (int i = 0; i < enemyCount; i++)
            {
                enemies.Add(null);
            }
        }

        public void SetEnemyInRoom(int enemyCount, Enemy enemy)
        {
            if (enemies[enemyCount] != null) return;
            enemies[enemyCount] = enemy;
            actualEnemies++;
        }

        public void PrintEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy == null) continue;
                int index = enemies.IndexOf(enemy);
                Console.WriteLine($"Room {index.ToRoman()}: {enemy.GetName()}");
            }
            // Room I: Worf
            // Room VII: Picard
            // Room XVI: Data
            // Room LIX: Troi
            // Room XCIV: Riker
        }
        
    }
}