using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class FantasyArmory : IArmory
    {
        public FantasyArmory()
        {
            Name = "fantasy";
        }

        public string Name { get; }

        public IEnumerable<Weapon> GetWeapons()
        {
            return new Weapon[]
            {
                new Weapon() { Id = 1, Name = "Excalibur", Source = "Aurthurian Mythos", Type = "Sword" },
                new Weapon() { Id = 3, Name = "Orcrist", Source = "J. R. R. Tolkien", Type = "Dagger" },
                new Weapon() { Id = 2, Name = "Stormbringer", Source = "Michael Moorcock", Type = "Bastard Sword" }
            };
        }
    }
}
