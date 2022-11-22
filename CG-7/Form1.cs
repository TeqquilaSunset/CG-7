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
        readonly float[] figure = { -0.9f,0,1, -0.9f,0,0, -0.9f,0.5f,0, -0.9f,0.5f,1, 1,0,0, 1,1f,0, 1,1,1, 
                                    1,0,1, 0.4f,0.5f,1, 0.4f,1,1, 0.4f,0.5f,0, 0.4f,1,0,};
        
        readonly uint[] indexQuads = { 0,1,2,3, 3,2,10,8, 8,10,11,9, 6,5,11,9, 6,5,4,7, 0,1,4,7 };
        readonly uint[] indexLines = {0,1, 1,2, 2,3, 3,0, 2,10, 10,11, 11,5, 5,4, 4,1, 11,9, 9,6,
                                      6,7, 7,0, 7,4, 9,8, 8,3, 6,5, 10,8 };
        readonly uint[] indexLinesLoop = {8,10};
        readonly uint[] indexPolygon = {10,11,5,4,1,2 };
        readonly uint[] indexPolygon2 = {8,9,6,7,0,3 };

        readonly float[] quad = {-1,-1,0, 1,-1,0, 1,1,0, -1,1,0 };
        readonly float[] normal = {-0.9f,0,1, -0.9f,0,0, -0.9f,0.5f,0, -0.9f,0.5f,1, 1,0,0, 1,1f,0, 1,1,1,
                                    1,0,1, 0.4f,0.5f,1, 0.4f,1,1, 0.4f,0.5f,0, 0.4f,1,0 };
        //readonly float[] normal = {-1,0,1, -1,0,0, -1,1,0, -1,1,1, 1,0,0, 1,1,0, 1,1,1,
        //                            1,0,1, 1,1,1, 1,1,1, 1,1,0, 1,1,0 };


        int s = 0;
        int l = 0;


        // положение фигуры
        float X = 0;
        float Y = 0;
        float Z = 0;
        //флаг запуска таймера 
        bool flag = false;

        bool flagLeft = false;
        bool flagTop = false;
        bool light = true;

        float anglc = 0;
        float anglLight = 65;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
            //прозрачность
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //Gl.glEnable(Gl.GL_BLEND);

            //Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //Gl.glEnable(Gl.GL_DEPTH_TEST);
            //Gl.glEnable(Gl.GL_LIGHTING);
            //Gl.glEnable(Gl.GL_LIGHT0);
            //Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //Gl.glEnable(Gl.GL_NORMALIZE);

            //начальное и конечное значение для осей
            //Gl.glOrtho(-2, 2, -2, 2, 4, -50);
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB| Glut.GLUT_DOUBLE |Glut.GLUT_DEPTH);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-2, 2, -2, 2, 0.2f, 10);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Draw();
            holst.Invalidate();
        }
        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Draw();
        }
        float a=0;
        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_NORMALIZE);



            Gl.glPushMatrix();
            DrawCube();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            DrawLight();
            Gl.glPopMatrix();

            holst.Invalidate();
        }

        private void DrawLight()
        {
           

        }
        private void DrawQuad()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//используем массив вершин
            Gl.glColor4f(1, 1, 1, 1f);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, quad);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 0, 4);
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            //Gl.glPopMatrix();
        }

        private void DrawCube()
        {
         
            Gl.glTranslated(0, 0, -4);
            Gl.glRotatef(33, 1, 1, 0);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, figure); //в качестве массива вершин используем
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            // характеристики материалов
            //http://devernay.free.fr/cours/opengl/materials.html
            //rubby 
            


            //////////////////////
            Gl.glRotatef(X, 1, 0, 0);
            Gl.glRotatef(Y, 0, 1, 0);
            Gl.glRotatef(Z, 0, 0, 1);
            //Gl.glColor3f(0.8f, 0.2f, 0.2f);
            
            Gl.glColor3f(1,1,1);
            Glut.glutSolidSphere(0.5, 20, 20);

            holst.Invalidate();
        }

        

        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Q)
            {
                Y--;
                Draw();
            }
            if (e.KeyCode == Keys.E)
            {
                Y++;
                Draw();
            }
            if (e.KeyCode == Keys.W)
            {
                X--;
                Draw();
            }
            if (e.KeyCode == Keys.S)
            {
                X++;
                Draw();
            }
            if (e.KeyCode == Keys.A)
            {
                Z--;
                Draw();
            }
            if (e.KeyCode == Keys.D)
            {
                Z++;
                Draw();
            }
            if (e.KeyCode == Keys.Z)
            {
                a -= 0.1f;
                Draw();
            }
            if (e.KeyCode == Keys.X)
            {
                a += 0.1f;
                Draw();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (flag == true)
                {
                    flag = false;
                    //timer1.Stop();
                }
                else if (flag == false)
                {
                    flag = true;
                    //timer1.Start();
                }
            }
        }

    }
}
