using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.MonoGame.Behaviours
{
    public interface IEnPassantable
    {
        bool CurrentlyEnPassantable { get; set; }
    }
}
