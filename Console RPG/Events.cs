using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Events
    {
        public bool isOver;

        public Events(bool isOver)
        {
            this.isOver = isOver;
        }
        public abstract void Resolve(List<Player> players);
    }
}
