using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{

    // состояния игры
    public enum GameState
    {
        START, PLAYING, WIN, LOST, PAUSE
    }

    // состояния игрока
    public enum GameAction
    {
        START, MOVE_UP, MOVE_DOWN, MOVE_RIGHT, MOVE_LEFT, PAUSE, UNKNOWN
    }

    class Program
    {
        

        // привязываем настройки управления к кнопкам
        static GameAction KeyToGameAction(ConsoleKeyInfo keyInfo)
        {
            ConsoleKey key = keyInfo.Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    return GameAction.MOVE_UP;
                case ConsoleKey.DownArrow:
                    return GameAction.MOVE_DOWN;
                case ConsoleKey.LeftArrow:
                    return GameAction.MOVE_LEFT;
                case ConsoleKey.RightArrow:
                    return GameAction.MOVE_RIGHT;
                case ConsoleKey.Escape:
                    return GameAction.PAUSE;
                case ConsoleKey.Enter:
                    return GameAction.START;
                default:
                    return GameAction.UNKNOWN;
            }
        }

        static void Main(string[] args)
        {
            

            GameState state = GameState.START;
            GameSession session = new GameSession();
            GameAction action = GameAction.UNKNOWN;

            while (true)
            {
                state = session.play(action);
                if (state == GameState.LOST)
                {
                    lost();
                    break;
                }
                if (state == GameState.WIN)
                {
                    win();
                    break;
                }
                action = KeyToGameAction(Console.ReadKey());
            }
            
        }

        static void lost()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("GAME OVER! Press any key.");
            Console.ReadKey();
        }

        static void win()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("YOU WIN! Press any key.");
            Console.ReadKey();
        }
    }
}
