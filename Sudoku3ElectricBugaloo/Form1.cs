using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku5OSudokuer
{
    public partial class Form1 : Form
    {
        /* Conrado Perini Fracacio @ 04722-073
         * Rita de Cassia Santos @ 04722-099
         */
        private List<int> table = new List<int>();
        private List<NumericUpDown> CellList = new List<NumericUpDown>();
        
        private Dictionary<int, int> randomValues = new Dictionary<int, int>();

        private int max = 45;

        public Form1()
        {
            InitializeComponent();

            InitializeSudoku();
        }

        public void InitializeSudoku()
        {
            StartGame();
            CreateCells();

            AddCells();
        }

        private void StartGame()
        {
            Random rng = new Random();

            InitializeTable();
            for(int i = 0; i < 9; i++)
            {
                int numArea = (i * 9) + (3 * (i % 3));

                for (int j = 0; j<3; j++)
                {
                    List<int> numInArea = new List<int>();
                    int areaLine = ((numArea - (numArea % 9)) / 9) % 3;
                    int areaColumn = numArea % 3;

                    int initialValue = (numArea - areaColumn) - (areaLine * 9);
                    int auxX = 0;
                    int auxY = 0;

                    for (int k = 0; k < 9; k++)
                    {
                        if (auxX > 2)
                        {
                            auxX = 0;
                            auxY++;
                        }
                        numInArea.Add(initialValue + auxX + (auxY * 9));
                        auxX++;
                    }
                    int position = numInArea[rng.Next(9)];
                    while (table[position]!= 0)
                    {
                        position = numInArea[rng.Next(9)];
                    }
                    int newValue = rng.Next(9) + 1;

                    while (randomValues.ContainsKey(position))
                    {
                        position = rng.Next(81);
                    }

                    while (CheckValues(position, newValue))
                    {
                        newValue = rng.Next(9) + 1;
                    }

                    randomValues[position] = newValue;
                    table[position] = newValue;
                }
            }
        }

        private void InitializeTable()
        {
            for (int i = 0; i < 81; i++)
            {
                table.Add(0);
            }
        }

        private bool CheckValues(int position, int value)
        {
            bool allChecksOut = false;

            bool lineOk = isOnLine(position, value);
            bool columnOk = isOnColumn(position, value);
            bool areaOk = isOnArea(position, value);

            allChecksOut = lineOk || columnOk || areaOk;
            

            return allChecksOut;
        }

        private bool isOnLine(int position, int value)
        {
            bool alreadyExists = false;

            int minimumValue = position - (position % 9);

            for (int i = minimumValue; i < minimumValue + 9; i++)
            {

                if(i != position)
                {
                    //MessageBox.Show($"Valor de randomValues[{i}] = {randomValues[i]}\nValor de value = {value}");

                    if (table[i] == value)
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                
                
            }

            return alreadyExists;
        }

        private bool isOnColumn(int position, int value)
        {
            bool alreadyExists = false;

            int column = position % 9;

            for(int i = 0; i < 9; i++)
            {
                if (column + (9 * i) != position)
                {
                    //MessageBox.Show($"Valor de randomValues[{i}] = {randomValues[i]}\nValor de value = {value}");

                    if (table[column + (9 * i)] == value)
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                
            }


            return alreadyExists;
        }

        private bool isOnArea(int position, int value)
        {
            bool alreadyExists = false;

            int areaLine = ((position - (position % 9)) / 9) % 3;
            int areaColumn = position % 3;

            int initialValue = (position - areaColumn) - (areaLine * 9);
            int auxX = 0;
            int auxY = 0;

            //MessageBox.Show($"Valores:\n    Posição Alvo: {position}\n    areaLine: {areaLine}\n    areaColumn: {areaColumn}\n    initialValue: {initialValue}");

            for (int i = 0; i < 9; i++)
            {
                if (auxX > 2)
                {
                    auxX = 0;
                    auxY++;
                }

                //MessageBox.Show($"indice: {initialValue + auxX + (auxY * 9)}");
                if (initialValue + auxX + (auxY * 9) != position)
                {
                    //MessageBox.Show($"Valor de randomValues[{i}] = {randomValues[i]}\nValor de value = {value}");

                    if (table[initialValue + auxX + (auxY * 9)] == value)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                auxX++;
            }

            return alreadyExists;
        }

        private void CheckChange(object sender, EventArgs e)
        {
            int index = ((NumericUpDown)sender).TabIndex;
            int newValue = int.Parse($"{((NumericUpDown)sender).Value}");

            table[index] = newValue;

            if (!CheckValues(index, newValue))
            {
                ((NumericUpDown)sender).ForeColor = Color.Green;
            }
            else
            {
                ((NumericUpDown)sender).ForeColor = Color.Red;
            }

            if (newValue == 0)
            {
                ((NumericUpDown)sender).ForeColor = Color.Gray;
            }
        }

        private void CreateCells()
        {
            int auxX = 0;
            int auxY = 0;
            for (int i = 0; i < 81; i++)
            {

                NumericUpDown nmrcUpDown = new NumericUpDown();

                nmrcUpDown.Size = new Size(40, 40);
                nmrcUpDown.Location = new Point(69 * auxX, 50 * auxY);
                nmrcUpDown.Maximum = 9;
                nmrcUpDown.TabIndex = i;

                CellList.Add(nmrcUpDown);

                auxX++;
                if (auxX >= 3)
                {
                    auxX = 0;
                }
                if ((i+1)%9==0 && i!=0)
                {
                    auxY++;
                }
                if (auxY >= 3)
                {
                    auxY = 0;
                    auxX = 0;
                }
            }
        }

        private void AddCells()
        {
            int index = 0, panelCount = 0, cellCount = 0;
            int i = 0, j = 0;
            List<Panel> panelList = new List<Panel>() {new Panel(), new Panel(), new Panel()};
            foreach(Panel p in panelList) {
                p.Size = new Size(tblLytPnl_Table.Width / 3, tblLytPnl_Table.Height / 3);
            }
            foreach (NumericUpDown n in CellList)
            {
                if (randomValues.ContainsKey(index))
                {
                    table[index] = randomValues[index];
                }

                if (table[index] == 0)
                {
                    n.ForeColor = Color.DarkGray;
                }
                else
                {
                    n.ForeColor = Color.Black;
                }

                n.Value = table[index];
                n.ValueChanged += CheckChange;
                panelList[panelCount].Controls.Add(n);
                cellCount++;
                if(cellCount >= 3)
                {
                    panelCount++;
                    cellCount = 0;
                }
                if(panelCount >= 3)
                {
                    panelCount = 0;
                    cellCount = 0;
                }

                index++;
                if (index % 27 == 0 && index!=0)
                {
                    foreach (Panel p in panelList)
                    {
                        tblLytPnl_Table.Controls.Add(p, i, j);
                        i++;
                    }
                    i = 0;
                    j++;
                    panelList = new List<Panel>() { new Panel(), new Panel(), new Panel()};
                    foreach (Panel p in panelList)
                    {
                        p.Size = new Size(tblLytPnl_Table.Width / 3, tblLytPnl_Table.Height / 3);
                    }
                }
            }
        }

        private void ClearGame()
        {
            tblLytPnl_Table = new TableLayoutPanel();
            table.Clear();
            CellList.Clear();
            randomValues.Clear();

            table = new List<int>();
            CellList = new List<NumericUpDown> ();
            randomValues = new Dictionary<int, int>();
        }

        private void bttn_Refresh_Click(object sender, EventArgs e)
        {
            ClearGame();
            InitializeSudoku();
        }
    }
}
