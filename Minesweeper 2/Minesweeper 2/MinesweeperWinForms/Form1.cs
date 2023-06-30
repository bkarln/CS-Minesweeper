using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private GameTable gameTable;
        Bitmap fieldClosed = new Bitmap(Minesweeper.Properties.Resources.field);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            var oldTables = this.Controls.Find(Minesweeper.Properties.Resources.tableName, true);
            if (oldTables.Length > 0)
            {
                this.Controls.Remove(oldTables[0]);
            }
            if (rbEasyLevel.Checked)
            {
                gameTable = new GameTable(GameLevel.Easy);
            }
            else if (rbMediumLevel.Checked)
            {
                gameTable = new GameTable(GameLevel.Medium);
            }
            else if (rbHardLevel.Checked)
            {
                gameTable = new GameTable(GameLevel.Hard);
            }
            else
            {
                MessageBox.Show("Please choose any difficult level");
                return;
            }

            var tableLayout = new TableLayoutPanel()
            {
                Visible = false,
                Name = Minesweeper.Properties.Resources.tableName,
                AutoSize = true,
                TabIndex = 5,
                RowCount = gameTable.Rows,
                ColumnCount = gameTable.Columns
            };
            //tableLayout.Visible = false;
            //tableLayout.Name = Minesweeper.Properties.Resources.tableName;
            //tableLayout.AutoSize = true;
            //tableLayout.TabIndex = 5;
            //tableLayout.RowCount = gameTable.Rows;
            //tableLayout.ColumnCount = gameTable.Columns;

            while (tableLayout.RowStyles.Count < tableLayout.RowCount)
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, gameTable.RowHeight));
            }
            while (tableLayout.ColumnStyles.Count < tableLayout.ColumnCount)
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, gameTable.ColumnWidth));
            }

            tableLayout.Size = new Size(10, 10);
            tableLayout.BorderStyle = BorderStyle.None; 
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            foreach (ColumnStyle style in tableLayout.ColumnStyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = gameTable.ColumnWidth;
            }

            foreach (RowStyle style in tableLayout.RowStyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = gameTable.RowHeight;
            }

            for (int i = 0; i < tableLayout.RowCount; i++)
            {
                for (int j = 0; j < tableLayout.ColumnCount; j++)
                {
                    var field = new PictureBox();
                    field.Name = $"field_{i}-{j}";
                    field.Anchor = (((AnchorStyles.Left | AnchorStyles.Bottom) | AnchorStyles.Right) |
                                    AnchorStyles.Top);
                    field.Text = string.Empty;
                    field.BackgroundImageLayout = ImageLayout.Stretch;
                    field.BackgroundImage = fieldClosed;
                    field.Margin = new Padding(0);
                    field.Padding = new Padding(0);
                    field.BackColor = Color.Black;
                    field.MouseClick += pictureBoxAny_Click;
                    //field.Image = fieldClosed;

                    tableLayout.Controls.Add(field, j, i);

                }
            }
            textBoxHelper.AppendText($" form width = {this.Width}, table width = {gameTable.TableWidth} ");
            tableLayout.Location = new Point((this.Width / 2 - gameTable.TableWidth / 2), 5);
            textBoxHelper.AppendText($" location = {tableLayout.Location.X}:{tableLayout.Location.Y}");

            this.Controls.Add(tableLayout);
      
            textBoxHelper.AppendText($"{tableLayout.Size.Width}" + "\n");
            textBoxHelper.AppendText($"{tableLayout.Size.Height}" + "\n");

            tableLayout.Visible = true;

        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxHelper.AppendText($"\n{e.Location.X}:{e.Location.Y} - {e.Button.ToString()}");

        }

        private void pictureBoxAny_Click(object sender, MouseEventArgs e)
        {
            if (!gameTable.FirstStepDone)
            {
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                var tableLayout = this.Controls.Find(Minesweeper.Properties.Resources.tableName, false)[0] as TableLayoutPanel;
                var firstUserClick = tableLayout.GetCellPosition(sender as Control);
                gameTable.InitializeTable(firstUserClick.Column, firstUserClick.Row);
                //gameTable.InitializeTable(firstUserClick.Column, firstUserClick.Row);

                gameTable.TestShowTable(tableLayout);
                startTime.Stop();
                var resultTime = startTime.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                MessageBox.Show(elapsedTime);
            }
        }
    }
}
