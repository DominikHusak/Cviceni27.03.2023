using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni27._03._2023
{
    internal class Hrac
    {
        private readonly object healthLock = new object(); // lock object for accessing health property
        private readonly object aliveLock = new object(); // lock object for accessing alive property

        public string Jmeno { get; set; }
        private int health;
        public int Health
        {
            get
            {
                lock (healthLock)
                {
                    return health;
                }
            }
            set
            {
                lock (healthLock)
                {
                    if (Alive)
                    {
                        health = value;
                    }
                }
            }
        }
        private bool alive;
        public bool Alive
        {
            get
            {
                lock (aliveLock)
                {
                    return alive;
                }
            }
            set
            {
                lock (aliveLock)
                {
                    alive = value;
                }
            }
        }

        public Hrac(string jmeno, int health)
        {
            Jmeno = jmeno;
            Health = health;
            Alive = true;
        }

        public void Damage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                Alive = false;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
        }
    }
}
