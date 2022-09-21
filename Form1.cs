using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{   //mapSize-размер карты
    public partial class Form1 : Form
    {
        const int mapSize = 8;//размер доски
        const int cellSize = 50;

        /// <summary> Игровая карта </summary>
        int[,] map = new int[mapSize, mapSize];

        /// <summary>        Белая фигура        /// </summary>
        Image whiteFigure;
        Image blackFigure;

        public Form1()
        {
            InitializeComponent();

            whiteFigure = new Bitmap(new Bitmap(@"C:\Users\адм\Google Диск\Lepeshkin_4_well\Checkers_1\checkers\png\White.png"), new Size(cellSize - 1, cellSize - 10));
            blackFigure = new Bitmap(new Bitmap(@"C:\Users\адм\Google Диск\Lepeshkin_4_well\Checkers_1\checkers\png\Black.png"), new Size(cellSize - 1, cellSize - 10));


            this.Text = "Checkers";

            Init();
        }

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        public void Init()
        {
            //создание карта
            map = new int[mapSize, mapSize] {
                { 0,1,0,1,0,1,0,1},
                { 1,0,1,0,1,0,1,0},
                { 0,1,0,1,0,1,0,1},
                { 0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0},
                { 2,0,2,0,2,0,2,0},
                { 0,2,0,2,0,2,0,2},
                { 2,0,2,0,2,0,2,0}
            };

            CreateMap();

        }

        List<Button> _gameButtons = new List<Button>(64);
        public void CreateMap()
        {

            this.Width = (mapSize + 1) * cellSize;
            this.Height = (mapSize + 1) * cellSize;

            #region Create clear field
            bool isBlack = true;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);

                    if (isBlack)
                        button.BackColor = Color.Black;
                    else button.BackColor = Color.White;
                    isBlack = !isBlack; //меняем цвет местами
                    this.Controls.Add(button);
                    _gameButtons.Add(button);
                }
                isBlack = !isBlack;
            }
            #endregion
            var t = 0;
            for(int i = 0; i < 3; i++)
            {if (i == 1)
                        t++;
for (t = 0; t< 8; t++)
            {
                    
                if (t% 2 == 0)
                    _gameButtons[i*8+t].Image = whiteFigure;
                    t++;
            }

            }
         
            foreach(var btn in _gameButtons)
                btn.Click += Btn_Click;

        }

        Button prevButton;
        Color PrevColor;

        private void Btn_Click(object sender, EventArgs e)
        {
            if (prevButton != null)
                prevButton.BackColor = PrevColor;

            PrevColor = ((Button)sender).BackColor;
            ((Button)sender).BackColor = Color.Yellow;
            prevButton = ((Button)sender);

        }

        public void InitNewGame()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
