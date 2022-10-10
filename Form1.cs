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

 //   public class Car
 //   {
 //       Color Color;
 //       int Mass;
 //       int Type;
 //       int doorCount;
 //       int Speed;

 //public bool door1IsClose=true, door2IsClose=true, door3IsClose=true;
 //       public void Move()
 //       {

 //       }

 //       public bool IsCarClose()
 //       {
          
 //           if (door1IsClose == true && door2IsClose == true && door3IsClose == true)
 //               return true;
 //           else
 //           return 
 //                   false;
 //       }
 //   }

    /// <summary>
    /// Представляет игровую клетку
    /// </summary>
    public class ChessCell
    {

     
       public int x;
       public int y;

        public readonly Color BaseColor;

        /// <summary>
        /// 1 - белая шашка, 2 - черная шашка
        /// </summary>
        public int Type;
        public Image Figure;

        public ChessCell(int coordX, int coordY, Color baseColor)
        {
            BaseColor = baseColor;
            x = coordX;
            y = coordY;
        }

        public bool IsIQueen( int y)
        {
            if (Type == 1 && y == 7 || Type ==0 && y==0 )
                return true;
  
            else return false;
        }
    }

    public partial class Form1 : Form
    {
        const int mapSize = 8;//размер доски
        const int cellSize = 50;

       
        /// <summary> Игровая карта </summary>
       // int[,] map = new int[mapSize, mapSize];
        Button[,] map2 = new Button[mapSize, mapSize];

        /// <summary>        Белая фигура        /// </summary>
        //Image whiteFigure;
        //Image blackFigure;
        Image whiteFigure = new Bitmap(new Bitmap(@"C:\Users\адм\Google Диск\Lepeshkin_4_well\Checkers_1\checkers\png\White.png"), new Size(cellSize - 1, cellSize - 10));
        Image blackFigure = new Bitmap(new Bitmap(@"C:\Users\адм\Google Диск\Lepeshkin_4_well\Checkers_1\checkers\png\Black.png"), new Size(cellSize - 1, cellSize - 10));

        /// <summary> Ход белых </summary>
        bool _isWhiteTurn;

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
            //map = new int[mapSize, mapSize] {
            //    { 0,1,0,1,0,1,0,1},
            //    { 1,0,1,0,1,0,1,0},
            //    { 0,1,0,1,0,1,0,1},
            //    { 0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0},
            //    { 2,0,2,0,2,0,2,0},
            //    { 0,2,0,2,0,2,0,2},
            //    { 2,0,2,0,2,0,2,0}
            //};

            // map2 = new int[mapSize, mapSize]
            //Car m1 = new Car();

            //m1.IsCarClose(); // true
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
                    button.Click += Btn_Click;

                    Color col = Color.White;
                    if (i % 2 == 0 && j %2==0)
                        col = Color.White;
                    else 
                        col = Color.Black;

                    button.BackColor = col;
                    var cell = new ChessCell(i+1, j+1, col);
                    button.Tag = cell;
               //     if (map2[i, j] == button)

                        //((ChessCell)button.Tag).
                        //     button.BackgroundImage = whiteFigure;
                        //  else if (map[i, j] == 2) button.BackgroundImage = blackFigure;
                        this.Controls.Add(button);
                 //if (isBlack)
                 //button.BackColor = Color.Black;
                 //else button.BackColor = Color.White;
                 //isBlack = !isBlack; //меняем цвет местами
                 //   this.Controls.Add(button);
                    _gameButtons.Add(button);
                }
                isBlack = !isBlack;
            }
            #endregion
            var t = 0;
//            for(int i = 0; i < 3; i++)
//            {if (i == 1)
//                        t++;
//for (t = 0; t< 8; t++)
//            {
                    
//                if (t% 2 == 0)
//                    _gameButtons[i*8+t].Image = whiteFigure;
//                    t++;
//            }

//            }
         
         //   foreach(var btn in _gameButtons)
               

        }

        /// <summary>        Предыдущая кнопка </summary>
        Button prevButton;
        Button activeCh;
        Color PrevColor;

        private void Btn_Click(object sender, EventArgs e)
        {
            var cell = ((ChessCell)((Button)sender).Tag);

            if (prevButton != null)
                prevButton.BackColor = PrevColor;

            PrevColor = ((Button)sender).BackColor;
            ((Button)sender).BackColor = Color.Yellow;
            prevButton = ((Button)sender);
            activeCh = prevButton;

           prevButton.BackgroundImage = null;
        }


        public void InitNewGame()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
