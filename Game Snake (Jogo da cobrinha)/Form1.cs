using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Snake__Jogo_da_cobrinha_
{
    public partial class Form1 : Form
    {
        Jogo Jogo;
        public Form1()
        {
            InitializeComponent();
            Jogo = new Jogo(ref Frame, ref Pontos, ref Tela);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iniciarJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jogo.StartGame();
        }

        private void Frame_Tick(object sender, EventArgs e)
        {
            Jogo.Tick();
        }

        private void Clicado(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Jogo.Arrow = e.KeyCode;
            }
        }
    }
}
