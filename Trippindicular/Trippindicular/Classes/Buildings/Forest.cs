using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

class Forest : Building
{
    public Point forestPoint;
    public Forest(Point p) : base("forest", "selectedTile")
    {
        forestPoint = p;
        maxHealth = 500;
        health = 500;
    }
}
