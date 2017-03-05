using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyCube

{
    class Cube
    {
        public int gravity = 1;
        public int speed = 0;
        public int y_position = 0;
        public int jump_height = 12;

        public Cube(){
            }

        public void cube_fall()
        {
            speed += gravity;
            y_position += speed;
        }

        public void cube_jump()
        {
            speed = -jump_height;
        }
    }

}
