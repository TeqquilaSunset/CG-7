using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

namespace CG_7
{
    public partial class Form1 : Form
    {
        //координаты кубика
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
                                    1,0,1, 0.4f,0.5f,1, 0.4f,1,1, 0.4f,0.5f,0, 0.4f,1,0, };
       

        //флаг запуска таймера 
        bool flag = false;

        bool flagLeft = false;

        float anglc = 0;
        float anglLight = 65;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
            //прозрачность
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //Gl.glEnable(Gl.GL_BLEND);

            //буфер глубины для отсечения
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_NORMALIZE);


            //начальное и конечное значение для осей
            //Gl.glOrtho(-2, 2, -2, 2, 4, -50);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-2, 2, -2, 2, 2, 10);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(0, 0, 0, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            //Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            //float[] light0_dif = { 0.2f, 0.2f, 0.2f };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_dif);
            


            //float[] position = { 0, 0, 1, 0 };
            //Gl.glLightfv(GL_LIGHT0, GL_POSITIO, position);

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

            

            Gl.glPushMatrix();
            DrawCube();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            DrawLight();
            Gl.glPopMatrix();
        }

        private void DrawLight()
        {
            if (flagLeft == false)
            {
                Gl.glRotatef(0, 0, 0, 1);
                Gl.glRotatef(-60, 1, 0, 0);
                Gl.glRotatef(33, 0, 0, 1);
                Gl.glTranslatef(2, 3, -2);
                Gl.glPushMatrix();
                Gl.glRotatef(anglLight, 1, 0, 0);
                float[] light0_pos = { 0, 0f, 4f, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 0, 4);
                Gl.glScalef(0.4f, 0.4f, 0.4f);
                Gl.glColor3f(0, 0, 0);
                DrawQuad();
                Gl.glPopMatrix();
            }
            else
            {
                Gl.glRotatef(0, 0, 0, 1);
                Gl.glRotatef(-60, 1, 0, 0);
                Gl.glRotatef(33, 0, 0, 1);
                Gl.glTranslatef(2, 3, -2);
                Gl.glPushMatrix();
                Gl.glRotatef(anglLight, 1, 0, 0);
                float[] light0_pos = { 0, 0f, 4f, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 0, 4);
                Gl.glScalef(0.4f, 0.4f, 0.4f);
                Gl.glColor3f(0, 0, 0);
                DrawQuad();
                Gl.glPopMatrix();
            }

        }
        private void DrawQuad()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//используем массив вершин
            Gl.glColor3f(1, 1, 1);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, quad);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 0, 4);
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glPopMatrix();
        }
        private void DrawCube()
        {
            Gl.glTranslated(0, 0, -4);
            Gl.glRotatef(33, 1, 1, 0);

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, figure); //в качестве массива вершин используем

            //float[] color_am = {0,0,0};
            //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, color_am);
            Gl.glRotatef(anglc, 0, 1, 0);
            Gl.glLineWidth(4);
            Gl.glColor3f(1, 1, 1);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, normal);
            Gl.glDrawElements(Gl.GL_QUADS, 24, Gl.GL_UNSIGNED_INT, indexQuads);
            Gl.glDrawElements(Gl.GL_POLYGON, 6, Gl.GL_UNSIGNED_INT, indexPolygon);
            Gl.glDrawElements(Gl.GL_POLYGON, 6, Gl.GL_UNSIGNED_INT, indexPolygon2);
            Gl.glColor3f(0, 0, 0);
            Gl.glDrawElements(Gl.GL_LINES, 36, Gl.GL_UNSIGNED_INT, indexLines);
            Gl.glTranslated(-0.01, 0.01, 0);
            Gl.glDrawElements(Gl.GL_LINES, 2, Gl.GL_UNSIGNED_INT, indexLinesLoop);
            
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);

            holst.Invalidate();
        }

        

        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Q)
            {
                Draw();
            }
            if (e.KeyCode == Keys.E)
            {
                Draw();
            }
            if (e.KeyCode == Keys.W)
            {
                Draw();
            }
            if (e.KeyCode == Keys.S)
            {
                Draw();
            }
            if (e.KeyCode == Keys.A)
            {
                Draw();
            }
            if (e.KeyCode == Keys.D)
            {
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
                    timer1.Stop();
                }
                else if (flag == false)
                {
                    flag = true;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //anglc++;
            anglLight += 1f;
            Draw();
        }
        
        private void левоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagLeft = true;
            Draw();
        }

        private void правоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagLeft = true;
            Draw();
        }
    }
}
