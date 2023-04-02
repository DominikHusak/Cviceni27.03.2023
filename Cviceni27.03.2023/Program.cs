using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni27._03._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hrac = new Hrac("John", 100);

            var damageThread = new Thread(() =>
            {
                var random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    var damage = random.Next(1, 11);
                    hrac.Damage(damage);
                    Console.WriteLine($"{hrac.Jmeno} took {damage} damage. Health: {hrac.Health}");
                    Thread.Sleep(500);
                }
            });

            var healThread = new Thread(() =>
            {
                var random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    var heal = random.Next(1, 11);
                    hrac.Heal(heal);
                    Console.WriteLine($"{hrac.Jmeno} healed {heal} health. Health: {hrac.Health}");
                    Thread.Sleep(500);
                }
            });

            damageThread.Start();
            healThread.Start();

            damageThread.Join();
            healThread.Join();

            if (hrac.Alive)
            {
                Console.WriteLine($"{hrac.Jmeno} is alive with {hrac.Health} health.");
            }
            else
            {
                Console.WriteLine($"{hrac.Jmeno} is dead.");
            }
        }
    } 
