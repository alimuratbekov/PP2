using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maze
{
    class GameSession
    {
        private Wall wall;
        private Exit exit;
        private Person person;
        private int level = 1;


        
        public GameSession()
        {
            Console.CursorVisible = false;

            // задаём переменным (классам) параметры (label)
            wall = new Wall('#');
            exit = new Exit('X');
            person = new Person('P');
            
            // загружаем игру
            LoadMap(level);
        }
        
        // поведение игры во время действий игрока
        public GameState play(GameAction action)
        {
            // управление стрелками
            if (action == GameAction.MOVE_DOWN)
            {
                person.move(0, 1);
            }
            else if (action == GameAction.MOVE_UP)
            {
                person.move(0, -1);
            }
            else if (action == GameAction.MOVE_LEFT)
            {
                person.move(-1, 0);
            }
            else if (action == GameAction.MOVE_RIGHT)
            {
                person.move(1, 0);
            }

            // при столкновении со стеной - поражение
            if (person.IsWallCollision(wall))
            {
                return GameState.LOST;
            }

            // функция отображения стенок, выхода, персонажа
            render();

            return GameState.PLAYING;
        }

        private void render()
        {
            // очищает карту
            wall.Clear();
            exit.Clear();
            person.Clear();

            // заново загружает объекты на новых координатах
            wall.Draw();
            exit.Draw();
            person.Draw();

        }

        public void LoadMap(int level)
        {
            Console.Clear();

            // считываем txt файл в поток StreamReader
            string filePath = string.Format("Levels/Level{0}.txt", level);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            bool isPersonLoaded = false;
            bool isExitLoaded = false;
            int x = 0, y = 0;

            // пробегаемся по всем строкам файла
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                // все данные из файла записываются в классы
                for (x = 0; x < line.Length; x++)
                {
                    // внутри wall записываются координаты символов '#'
                    if (line[x] == wall.GetLebel())
                    {
                        wall.AddPoint(new Point(x, y));
                    }
                    // внутри person записываются координаты символа 'p'
                    else if (line[x] == person.GetLebel() && !isPersonLoaded)
                    {
                        person.AddPoint(new Point(x, y));
                        isPersonLoaded = true;
                    }
                    // внутри exit записываются координаты символа 'X'
                    else if (line[x] == exit.GetLebel() && !isExitLoaded)
                    {
                        exit.AddPoint(new Point(x, y));
                        isExitLoaded = true;
                    }
                }

                y++;
            }

            // закрываем потоки файлов
            sr.Close();
            fs.Close();
        }
    }
}
