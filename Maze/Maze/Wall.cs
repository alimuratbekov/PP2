﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Wall: GameObject
    {
        public Wall(char label) : base(label) { }
        
        public override void Draw()
        {

            base.Draw();
        }
        
        
    }
}
