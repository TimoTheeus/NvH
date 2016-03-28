using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Forest : Building
{
    public Forest() : base("forest", "selectedTile")
    {
        maxHealth = 500;
        health = 500;
    }
}
