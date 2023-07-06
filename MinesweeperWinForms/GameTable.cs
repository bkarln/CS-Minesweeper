using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class GameTable
    {
        private GameLevel gameLevel;
        private int columns;
        private int rows;
        private int mines;
        private float columnWidth;
        private float rowHeight;
        private int tableWidth;
        private int tableHeight;
        private bool firstStepDone;
        private Unit[,] table;
        public const float NominalTableWidth = 500f;
        public GameLevel GameLevel
        {
            get { return gameLevel; }
        }
        public int Columns
        {
            get { return columns; }
        }
        public int Rows
        {
            get { return rows; }
        }
        public int Mines
        {
            get { return mines; }
        }
        public float ColumnWidth
        {
            get { return columnWidth; }
        }

        public float RowHeight
        {
            get { return rowHeight; }
        }
        public int TableWidth
        {
            get { return tableWidth; }
        }
        public int TableHeight
        {
            get { return tableHeight; }
        }
        public bool FirstStepDone
        {
            get { return firstStepDone; }
        }
        public Unit[,] Table
        {
            get { return table; }
        }
        public GameTable(GameLevel gameLevel)
        {
            this.gameLevel = gameLevel;
            switch (gameLevel)
            {
                case GameLevel.Easy:
                    columns = 10;
                    rows = 10;
                    mines = 10;
                    break;
                case GameLevel.Medium:
                    columns = 18;
                    rows = 18;
                    mines = 40;
                    break;
                case GameLevel.Hard:
                    columns = 23;
                    rows = 23;
                    mines = 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameLevel), gameLevel, null);
            }
            SetTableSize();
        }

        void SetTableSize()
        {
            columnWidth = (float)Math.Round(NominalTableWidth / columns, 0);
            rowHeight = (float)Math.Round(NominalTableWidth / rows, 0);
            tableWidth = (int)(columns * columnWidth);
            tableHeight = (int)(rows * rowHeight);

        }

        public class Nested
        {
            public Unit[,] table;
            public int x;
            public int y;

            public Nested(Unit[,] table, int x, int y)
            {
                this.table = table;
                this.x = x;
                this.y = y;
            }

            public static void Method(object arg)
            {
                var box = arg as GameTable.Nested;
                //GetNeighbours(box.table, box.x, box.y);
            }
        }


        public void InitializeTable(int column, int row)
        {
            if (!firstStepDone)
            {
                firstStepDone = true;
                table = new Unit[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        table[i, j] = Unit.Free;
                    }
                }

                var rnd = new Random();
                var minesLeft = mines;

                while (minesLeft > 0)
                {
                    int mineX;
                    int mineY;
                    do
                    {
                        mineX = rnd.Next(0, columns);
                        mineY = rnd.Next(0, rows);
                    }
                    while ((mineX == column && mineY == row) || table[mineX, mineY] == Unit.Mine);

                    table[mineX, mineY] = Unit.Mine;
                    minesLeft--;
                }

                SetNumbers(table); 
            }
        }

       
        //ParameterizedThreadStart method = new ParameterizedThreadStart(Nested.Method);
        void SetNumbers(Unit[,] table)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    
                    //Thread thread = new Thread(method);
                   // var arg = new Nested(table,i,j);
                    //thread.Start(arg);
                    GetNeighbours(table,i,j);
                }
            }
        }

        void GetNeighbours(Unit[,] table, int i, int j)
        {
            if (table[i, j] != Unit.Mine)
            {
                var neighbourmines = 0;
                for (int k = i - 1; k <= i + 1; k++)
                {
                    for (int l = j - 1; l <= j + 1; l++)
                    {
                        try
                        {
                            if (table[k, l] == Unit.Mine)
                            {
                                neighbourmines++;
                            }
                        }
                        catch (Exception e)
                        {
                            
                        }
                   
                    }
                }

                table[i,j] = GetNumber(neighbourmines);
            }

            //table[i,j] = Unit.Mine;
        }

        Unit GetNumber(int neighbourmines)
        {
            switch (neighbourmines)
            {
                case 0:
                    return Unit.Free;
                    break;
                case 1:
                    return Unit.One;
                    break;
                case 2:
                    return Unit.Two;
                    break;
                case 3:
                    return Unit.Three;
                    break;
                case 4:
                    return Unit.Four;
                    break;
                case 5:
                    return Unit.Five;
                    break;
                case 6:
                    return Unit.Six;
                    break;
                case 7:
                    return Unit.Seven;
                    break;
                case 8:
                    return Unit.Eight;
                    break;
                case 9:
                    return Unit.Nine;
                    break;
                default:
                    return Unit.Free;
            }
        }

        public void TestShowTable(TableLayoutPanel tableLayout)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (table[i,j])
                    {
                        case Unit.Free:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.field;
                            break;
                        case Unit.One:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m1;
                            break;
                        case Unit.Two:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m2;
                            break;
                        case Unit.Three:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m3;
                            break;
                        case Unit.Four:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m4;
                            break;
                        case Unit.Five:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m5;
                            break;
                        case Unit.Six:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m5;
                            break;
                        case Unit.Seven:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m5;
                            break;
                        case Unit.Eight:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m5;
                            break;
                        case Unit.Nine:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.m5;
                            break;
                        case Unit.Mine:
                            tableLayout.GetControlFromPosition(j, i).BackgroundImage =
                                Minesweeper.Properties.Resources.mine;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
