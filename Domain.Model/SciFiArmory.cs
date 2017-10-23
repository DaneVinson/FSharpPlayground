using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class SciFiArmory : IArmory
    {
        public SciFiArmory()
        {
            Name = "scifi";
        }

        public string Name { get; }

        public IEnumerable<Weapon> GetWeapons()
        {
            return new Weapon[]
            {
                new Weapon() { Id = 3, Name = "Blaster", Source = "Star Wars", Type = "Energy Dischard Weapon" },
                new Weapon() { Id = 2, Name = "Light Saber", Source = "Star Wars", Type = "Energy Sword" },
                new Weapon() { Id = 1, Name = "Phaser", Source = "Star Trek", Type = "Energy Dischard Weapon" }
            };
        }
    }
}
