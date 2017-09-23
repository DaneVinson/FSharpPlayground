using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] WeaponIds { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
