using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Exit:GameObject
    {
        public Exit(char label):base(label) { }

        // функция отрисовки exit
        public override void Draw()
        {
            base.Draw();
        }
    }
}
