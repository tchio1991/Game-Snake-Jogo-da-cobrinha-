using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Snake__Jogo_da_cobrinha_
{
    // Aqui vai está localizada todas as funcionalidades do jogo.
    internal class Jogo
    {
        public Keys Direction { get; set; }

        public Keys Arrow { get; set; }


        public Timer Frame { get; set; }

        public Label Pontos { get; set; }

        public Panel Tela { get; set; }

        
        private int pontos = 0;

        private Comida Comida;

        private Snake Snake;

        private Bitmap offScreenBitmap;

        private Graphics bitmapGraph;

        private Graphics screenGraph;

        public Jogo(ref Timer timer, ref Label label, ref Panel panel)
        {
            Tela = panel;
            Frame = timer;
            Pontos = label;
            offScreenBitmap = new Bitmap(428, 428);
            Snake = new Snake();
            Comida = new Comida();
            Direction = Keys.Left;
            Arrow = Direction;
        }

        public void StartGame()
        {
            Snake.Reset();
            Comida.CreateComida();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = Tela.CreateGraphics();
            Frame.Enabled = true;
        }

        public void Tick()
        {

         if (((Arrow == Keys.Left) && (Direction != Keys.Right)) ||
            ((Arrow == Keys.Right) && (Direction != Keys.Left)) ||
            ((Arrow == Keys.Up) && (Direction != Keys.Down)) ||
            ((Arrow == Keys.Down) && (Direction != Keys.Up)))
            {
                Direction = Arrow;
            }

            switch(Direction)
            {
                case Keys.Left:
                    Snake.Esquerda();
                    break;
                case Keys.Right:
                    Snake.Direita();
                    break;
                case Keys.Up:
                    Snake.Cima();
                    break;
                case Keys.Down:
                    Snake.Baixo();
                    break;
            }


            bitmapGraph.Clear(Color.White);

            bitmapGraph.DrawImage(Properties.Resources.comida,(Comida.Location.X * 15), (Comida.Location.Y * 15), 15, 15);
            bool gameOver = false;

            for(int i=0; i < Snake.length; i++)
            {
                if(i == 0)
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#262324")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);
                } else
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#f1a20b")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);
                }

                if ((Snake.Location[i] == Snake.Location[0]) && (i > 0))
                {
                    gameOver = true;
                } 
            }

            screenGraph.DrawImage(offScreenBitmap, 0, 0);
            CheckCollision();
            if(gameOver)
            {
                GameOver();
            }
                      

        }

        public void CheckCollision()
        {
            if (Snake.Location[0] == Comida.Location)
            {
                Snake.Eat();
                Comida.CreateComida();
                pontos += 9;
                Pontos.Text = "PONTOS: " + pontos;
             }
        }
    
        public void GameOver()
        {
            Frame.Enabled = false;
            bitmapGraph.Dispose();
            screenGraph.Dispose();
            Pontos.Text = "PONTOS: 0";
            pontos = 0;
            MessageBox.Show("Game Over");
        }
    
    }




}

