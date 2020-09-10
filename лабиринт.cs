using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinth
{
    class Program
    {
        static void Main()
        {
            Init();
            while(!IsEndgame())
            {
                Draw();
                Input();
                Logic();
            }
            Console.WriteLine("!!!WIN!!!");
        }



        public static int height = 20, width = 20, freq = 10;
        public static char[,] Map = new char[width, height];
        public static int CharX, CharY, FinishX, FinishY,dx,dy;
        public static Random r = new Random();
        public static int newX,newY;
        static void Init()
        {
            CharX = r.Next(0, width);
            CharY = r.Next(0, height);
            FinishX = r.Next(0, width);
            FinishY = r.Next(0, height);
            GenerateMap();
            PlaceObjects();
        }
        static char[,] GenerateMap()
        {
            int RandNum;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    RandNum = r.Next(100);
                    if (RandNum < freq) Map[j, i] = '#';
                    else Map[j, i] = ' ';
                }
            }                           
            return Map;
        }
        static char[,] PlaceObjects()
           {
            Map[CharX, CharY] = '@';
            Map[FinishX, FinishY] = 'F';
            return Map;
        }
        static void Draw()
        {
            Console.Clear();
            for(int i=0;i<height;i++)
            {
                for(int j=0;j<width;j++)
                {
                    if (j == CharX && i == CharY) Map[j, i] = '@';
                    Console.Write(Map[j, i]);
                }
                Console.WriteLine();
            }
        }
        static void Input()
        {
            dx = 0;
            dy = 0;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    dy = -1;
                    break;
                case ConsoleKey.S:
                    dy = 1;
                    break;
                case ConsoleKey.D:
                    dx = 1;
                    break;
                case ConsoleKey.A:
                    dx = -1;
                    break;
            }
        }
        static void Logic()
        {
            TryMove();
            IsEndgame();
        }
        static void TryMove()
        {
            newX = CharX + dx;
            newY= CharY + dy;
            if (CanGoTo()) GoTo();
        }
        static bool CanGoTo()
        {
            if (newX >= width|| newY >= height) return false;
            if (!IsWalkable()) return false;
            return true;
        }
        static bool IsWalkable()
        {
            if (Map[newX,newY]=='#') return false;
                    return true;
        }
        static void GoTo()
        {
            Map[CharX, CharY] = ' ';
            CharX = newX;
            CharY = newY;
        }
        static bool IsEndgame()
        {
            if (CharX == FinishX && CharY == FinishY) return true;
            return false;
        }
    }
}


