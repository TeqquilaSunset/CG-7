using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace CG_7
{
    public partial class Form1 : Form
    {
        float anglc = 0;
        float anglLight = 65;

        bool timer = false;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_BLEND);

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(50, 1, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, holst.Width, holst.Height);

            //туман
            float[] fogColor = {0.5f, 0.5f, 0.5f, 1 };
            Gl.glEnable(Gl.GL_FOG);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_LINEAR);
            Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.3f);
            Gl.glFogf(Gl.GL_FOG_START, 9f);
            Gl.glFogf(Gl.GL_FOG_END, 14.0f);


            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Draw();
            holst.Invalidate();
        }
        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            //Gl.glEnable(Gl.GL_NORMALIZE);


            //Gl.glRotated(45, 1, 0, 0);
            //Gl.glTranslated(0, -8, -1);

            Gl.glPushMatrix();
            DrawIcosahedron();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            DrawTeapot();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            DrawCylinder();
            Gl.glPopMatrix();

            holst.Invalidate();
        }

        private void DrawCylinder()
        {
            Gl.glColor4f(1, 0, 0, 0.5f);

            Gl.glTranslated(0, 1, -10);
            Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidCylinder(1, 2, 100, 1);



            holst.Invalidate();

        }
        private void DrawIcosahedron()
        {
            Gl.glTranslated(0, 0, -10);
            Gl.glRotatef(anglc, 0, 1, 0);
            Gl.glTranslatef(-4, 0, 0);
            Gl.glRotatef(anglc + 2, 1, 1, 1);

            Gl.glColor4f(1, 0.5f, 0.9f, 1);
            //Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidIcosahedron();

        }

        private void DrawTeapot()
        {
            Gl.glTranslated(0, 0, -10);
            Gl.glRotatef(anglc, 0, 1, 0);
            Gl.glTranslatef(4, 0, 0);
            Gl.glRotatef(anglc, 1, 1, 1);

            Gl.glColor4f(0, 0.5f, 0.9f, 1);
            Glut.glutSolidTeapot(1);


            holst.Invalidate();
        }



        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Space)
            {
                if (timer == true)
                {
                    timer = false;
                    timer1.Stop();
                }
                else
                {
                    timer = true;
                    timer1.Start();
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            anglc += 1;
            Draw();
        }
    }
}
