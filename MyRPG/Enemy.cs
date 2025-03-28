using System;

namespace MyRPG
{
    public class Enemy
    {
        private string name;
        private float health;
        private float shield;
        private static int totalPowerUpsCollected;

        static Enemy()
        {
            totalPowerUpsCollected = 0;
        }

        public Enemy(string name)
        {
            SetName(name);
            health = 100;
            shield = 0;
        }

        public string GetName()
        {
            return name;
        }

        public float GetHealth()
        {
            return health;
        }

        public float GetShield()
        {
            return shield;
        }

        public static int GetTotalPowerUpsCollected()
        {
            return totalPowerUpsCollected;
        }

        public void SetName(string newName)
        {
            name = newName.Substring(0, Math.Min(8, newName.Length));
        }

        public void PickupPowerUp(PowerUp powerUp, float value)
        {
            totalPowerUpsCollected++;
            if (powerUp == PowerUp.Health)
            {
                health = Math.Min(100, health + value);
            }
            else if (powerUp == PowerUp.Shield)
            {
                shield = Math.Min(100, shield + value);
            }
        }

        public void TakeDamage(float damage)
        {
            shield -= damage;
            if (shield < 0)
            {
                float damageStillToInflict = -shield;
                shield = 0;
                health -= damageStillToInflict;
                if (health < 0) health = 0;
            }
        }
    }
}
