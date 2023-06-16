// GameLogic.cs
using System;
using System.Windows.Forms;

namespace Minesweeper_2
{
    public class GameLogic
    {
        private Button[] mine_buttons;
        private int[] mines;
        private Form1 form;

        public void Initialize(Form1 form)
        {
            this.form = form;
            mine_buttons = new Button[81];
            mines = MineGenerator.GenerateMines();
            AddButtonsToForm();
        }

        private void AddButtonsToForm()
        {
            int mov_left = 0;
            int mov_right = 0;
            for (int j = 0; j < 9; ++j)
            {
                for (int i = 0; i < 9; ++i)
                {
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(mov_left + 1, 9 + mov_right);
                    button.Name = ((j * 9) + (i + 1)).ToString();
                    button.Size = new System.Drawing.Size(23, 23);
                    button.TabStop = false;
                    button.Text = " ";
                    button.UseVisualStyleBackColor = true;
                    button.MouseClick += new MouseEventHandler(Button_Click);


                    // Adicionar o botão ao array mine_buttons
                    mine_buttons[i + (j * 9)] = button;

                    // Adicionar o botão ao formulário
                    form.Controls.Add(button);

                    mov_left += 22;
                }
                mov_left = 0;
                mov_right = 22 * (j + 1);
            }
        }


        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int buttonIndex = int.Parse(clickedButton.Name) - 1;

            // Lógica para tratar o clique em um botão

            // Exemplo: exibindo a posição do botão clicado
            int row = buttonIndex / 9;
            int column = buttonIndex % 9;
            Console.WriteLine("Button clicked: Row = " + row + ", Column = " + column);
        }
    }
}
