using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Snake__Jogo_da_cobrinha_
{   
    // Classe Snake, aqui vai está o comportamento cobrinha
    internal class Snake
    {
        public int length { get; private set; }

        public Point[] Location { get; private set; }


        public Snake()
        {
            Location = new Point[28 * 28];
            Reset();
        }
        
        public void Reset()
        {
            length = 5;
            for(int i = 0; i < length; i++)
            {
                Location[i].X = 12;
                Location[i].Y = 12;
            }
         }

        public void Segue()
        {
            for (int i = length -1; i > 0; i--)
            {
                Location[i] = Location[i - 1];
            } 
        } 

        public void Cima()
        {
            Segue();
            Location[0].Y--;
            if (Location[0].Y < 0)
            {
                Location[0].Y += 28;
            }
        }

        public void Baixo()
        {
            Segue();
            Location[0].Y++;
            if (Location[0].Y > 27)
            {
                Location[0].Y -= 28;
            }
        }

        public void Esquerda()
        {
            Segue();
            Location[0].X--;
            if (Location[0].X < 0)
            {
                Location[0].X += 28;
            }
        }

        public void Direita()
        {
            Segue();
            Location[0].X++;
            if (Location[0].X > 27)
            {
                Location[0].X -= 28;
            }
        }

        public void Eat()
        {
            length++;
        }
    }
}
