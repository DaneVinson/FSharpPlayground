using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public interface IArmory
    {
        string Name { get; }

        IEnumerable<Weapon> GetWeapons();
    }
}
