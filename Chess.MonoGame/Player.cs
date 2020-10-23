using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame
{
    public class Player
    {
        public Player(string name, Alliance alliance)
        {
            Alliance = alliance;
            Name = name;
        }
        public Alliance Alliance { get; }
        public string Name { get; }
    }
}
