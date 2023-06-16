using System;
using System.Windows.Forms;

namespace Minesweeper_2
{
    public partial class Form1 : Form
    {
        private GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameLogic = new GameLogic();
            gameLogic.Initialize(this); 
        }
    }
}






