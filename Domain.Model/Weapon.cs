using System;

namespace Domain.Model
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Type} from {Source}, {Id})";
        }
    }
}
