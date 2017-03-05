using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace FlappyCube
{
    class Pipe
    {
        static Random r = new Random();
        public const int width = 30;
        public const int mid_space = 100;
        public int height = 150;
        public int x_position = Form1.panel_width;
        public int speed = 3;
        public int order;

        public Pipe(int order)
        {
            this.order = order;
            this.x_position += (order * Form1.panel_width) / 3;
            height = Rand_height();
        }


        public void Move()
        {
            x_position -= speed;
        }

        public void Respawn()
        {
            x_position = Form1.panel_width;
            height = Rand_height();
            
        }


        public int Rand_height()
        {
            return r.Next() % 150 + 50;
        }
    }
}
