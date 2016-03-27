using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class EventLog : GameObjectList
{
    public EventLog() : base(10, "eventLog")
    {
        Objects = new List<GameObject>(6);
        for(int i = 0; i < 6; i++)
            Objects.Add(new TextGameObject("smallFont"));
    }

    public void Add(GameObject target, GameObject attacker)
    {
        TextGameObject prompt = new TextGameObject("smallFont");
        if(target is Unit)
            switch(GameWorld.Random.Next(6))
            {
                case 0:
                    prompt.Text = attacker.ID + " cashed in " + target.ID + "'s chips";
                    break;
                case 1:
                    prompt.Text = target.ID + " was no match for " + attacker.ID + "'s fists of fury";
                    break;
                case 2:
                    prompt.Text = attacker.ID + " iced " + target.ID;
                    break;
                case 3:
                    prompt.Text = attacker.ID + " slaughtered " + target.ID + " in a crazed frenzy";
                    break;
                case 4:
                    prompt.Text = attacker.ID + " decided the world wasn't big enough for " + target.ID;
                    break;
                case 5:
                    prompt.Text = target.ID + "didn't have what it took to take on" + attacker.ID;
                    break;
            }
        
        else if(target is Building)
        {
            switch(GameWorld.Random.Next(4))
            {
                case 0:
                    prompt.Text = target.ID + "crumbled under" + attacker.ID + "'s might";
                    break;
                case 1:
                    prompt.Text = attacker.ID + "rolled over" + target.ID + "like a bulldozer";
                    break;
                case 2:
                    prompt.Text = target.ID + "wasn't built with" + attacker.ID + "in mind";
                    break;
                case 3:
                    prompt.Text = attacker.ID + "found a structural weakness in" + target.ID;
                    break;
            }
        }

        for(int i = 4; i >= 0; i--)
        {
            if(Objects[i] != null)
            {
                Objects[i].Position = new Vector2(0, 20 * (i + 1));
                Objects[i + 1] = Objects[i];
            }
        }
        prompt.Position = new Vector2(0, 0);
        Objects[0] = prompt;
    }
}
