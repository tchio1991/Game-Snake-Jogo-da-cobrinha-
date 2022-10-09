using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game_Snake__Jogo_da_cobrinha_
{
    internal class Comida
    {
        public Point Location { get; private set; }
        // Comportamento da comida e o tamanho
        public void CreateComida()
        {
            Random rnd = new Random();
            Location = new Point(rnd.Next(0, 27), rnd.Next(0, 27));

        }
    }

}
