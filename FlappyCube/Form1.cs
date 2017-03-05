using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FlappyCube
{
    public partial class Form1 : Form
    {
        public static int panel_width;
        public static int panel_height;
        public static int score = 0;

        Cube cube;
        Pipe[] pipe = new Pipe[3];


        public Form1()
        {
            InitializeComponent();
            panel_width = panel1.Width;
            panel_height = panel1.Height;

            timer1.Interval = 30;
            cube = new Cube();
            

            for (int i = 0; i<3; i++)
                pipe[i] = new Pipe(i);

            timer1.Enabled = true;
            Debug.WriteLine(panel_width);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(KeyDownHandler);
            

        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    ((Form1)sender).cube.cube_jump();
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

           cube.cube_fall();

            for (int i =0; i<3; i++)
            {
                pipe[i].Move();
                if (pipe[i].x_position < -Pipe.width)
                {
                    pipe[i].Respawn();
                    score++;
                    label.Text = score.ToString();
                }
            }

           panel1.Refresh();

            if (isCollided())
                timer1.Stop();

        }

        private bool isCollided()
        {
            for (int i = 0; i < 3; i++) { 
                if ((0 >= pipe[i].x_position && 0 <= pipe[i].x_position + Pipe.width)
                    && (cube.y_position < pipe[i].height || cube.y_position > pipe[i].height + Pipe.mid_space))
        
                    return true;
            }

            return false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

          
            Point[] points_bird = new Point[4];

            points_bird[0] = new Point(0, cube.y_position);
            points_bird[1] = new Point(0, cube.y_position + 10);
            points_bird[2] = new Point(10, cube.y_position +10);
            points_bird[3] = new Point(10, cube.y_position);

            Brush brush = new SolidBrush(Color.Red);

            g.FillPolygon(brush, points_bird);

            for (int i = 0; i < 3; i++)
            {
                Point[] points_pipe = new Point[4];

                points_pipe[0] = new Point(pipe[i].x_position, 0);
                points_pipe[1] = new Point(pipe[i].x_position, pipe[i].height);
                points_pipe[2] = new Point(pipe[i].x_position + Pipe.width, pipe[i].height);
                points_pipe[3] = new Point(pipe[i].x_position + Pipe.width, 0);

                Point[] points_pipe2 = new Point[4];

                points_pipe2[0] = new Point(pipe[i].x_position, pipe[i].height + Pipe.mid_space);
                points_pipe2[1] = new Point(pipe[i].x_position, panel_height);
                points_pipe2[2] = new Point(pipe[i].x_position + Pipe.width, panel_height);
                points_pipe2[3] = new Point(pipe[i].x_position + Pipe.width, pipe[i].height + Pipe.mid_space);


                brush = new SolidBrush(Color.Green);

                g.FillPolygon(brush, points_pipe);
                g.FillPolygon(brush, points_pipe2);

            }





        }
    }
}
