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

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
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
            //фоновая подсветка
            //Gl.glShadeModel(Gl.GL_SMOOTH); //затенение
            float[] ambient = { 0.2f, 0.2f, 0.2f, 1 };
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, ambient);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light0_col = { 1, 1, 1, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_col);
            //float[] light_position = { 1.0f, 1.0f, 2.0f, 0.0f };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
            //float[] light0_dif = { 1, 1, 1, 1};
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_dif

            //float[] ambientlight = { 0.1f, 0.1f, 0.1f, 1.0f 

            //float[] light0_dif = { 0f, 0f, 0f, 1 };
            //float[] ambientlight = { 0.1f, 0.1f, 0.1f, 1.0f };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambientlight);
            if ( l == 0)
            {
                Gl.glDisable(Gl.GL_LIGHT0);
            }
            if (l == 3)
            {
                //Gl.glRotatef(-60, 1, 0, 0);
                //Gl.glRotatef(33, 0, 0, 1);
                //Gl.glTranslatef(0, 0, -4);
                Gl.glPushMatrix();
                //Gl.glRotatef(30, 0, 0, 1);
                //Gl.glRotatef(anglLight, 0, 1, 0);
                float[] light0_pos = { 0, 2, 1, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 2, 1);
                Gl.glRotatef(15, 0, 0, 1);
                DrawQuad();
                Gl.glPopMatrix();

            }
            else if (l == 1)
            {
                Gl.glRotatef(-60, 1, 0, 0);
                Gl.glRotatef(33, 0, 0, 1);
                Gl.glTranslatef(2, 3, -3);
                Gl.glPushMatrix();
                //Gl.glRotatef(30, 0, 0, 1);
                Gl.glRotatef(anglLight, 0, 1, 0);
                float[] light0_pos = { 0, 0, 1, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 0, 3);
                Gl.glScalef(0.4f, 0.4f, 0.4f);
                Gl.glColor3f(0, 0, 0);
                DrawQuad();
                Gl.glPopMatrix();
            }
            else if (l == 2)
            {
                Gl.glRotatef(-30, 0, 0, 1);
                Gl.glRotatef(-60, 1, 0, 0);
                Gl.glRotatef(33, 0, 0, 1);
                Gl.glTranslatef(2, 3, -2);
                Gl.glPushMatrix();
                Gl.glRotatef(anglLight, 1, 0, 0);
                float[] light0_pos = { 0, 0f, 2f, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 0, 2.5f);
                Gl.glScalef(0.4f, 0.4f, 0.4f);
                Gl.glColor3f(0, 0, 0);
                DrawQuad();
                Gl.glPopMatrix();
            }
            else if (l == 4)
            {
                float[] light0_pos = { 0, 0f, 4f, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
            }
            else if (l == 5)
            {
                Gl.glPushMatrix();
                float[] light0_pos = { 1, 0f, 0, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                //DrawQuad();
                Gl.glPopMatrix();
            }
            else if (l == 6)
            {
                Gl.glPushMatrix();
                float[] light0_pos = { 0, 1f, 0, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                //DrawQuad();
                Gl.glPopMatrix();
            }
            else if (l == 7)
            {
                Gl.glPushMatrix();
                float[] light0_pos = { 0, 0f, 1, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                //DrawQuad();
                Gl.glPopMatrix();
            }
            else if (l == 8)
            {
                float[] light0_col2 = {0, 1, 0, 1 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_col2);

                Gl.glRotatef(-60, 1, 0, 0);
                Gl.glRotatef(33, 0, 0, 1);
                Gl.glTranslatef(2, 3, -3);
                Gl.glPushMatrix();
                //Gl.glRotatef(30, 0, 0, 1);
                Gl.glRotatef(anglLight, 0, 1, 0);
                float[] light0_pos = { 0, 0, 1, 0 };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_pos);
                Gl.glTranslatef(0, 0, 3);
                Gl.glScalef(0.4f, 0.4f, 0.4f);
                Gl.glColor3f(0, 0, 0);
                DrawQuad();
                Gl.glPopMatrix();
            }

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
            if (s == 1)
            {
                //float[] color_am = { 0.1747f, 0.01175f, 0.01175f, 1.0f };
                //float[] color_dif = { 0.61424f, 0.04136f, 0.04136f };
                //float[] color_spec = { 0.727811f, 0.626959f, 0.0626959f };
                //float[] emission = {0.0f, 0.0f, 0.0f, 1 };
                //float color_shin = 0.6f;

                float[] color_am = { 0.1747f, 0.01175f, 0.01175f, 1.0f };
                float[] color_dif = { 0.61424f, 0.04136f, 0.04136f };
                float[] color_spec = { 0.727811f, 0.626959f, 0.0626959f };
                float[] emission = { 0.0f, 0.0f, 0.0f, 1 };
                float color_shin = 0.1f;

                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color_am);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color_dif);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color_spec);
                Gl.glMaterialf(Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, color_shin * 128.0f);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
            }
            //gold
            if (s == 2)
            {
                float[] color_am = { 0.24725f, 0.1995f, 0.0745f, 1.0f };
                float[] color_dif = { 0.75164f, 0.60648f, 0.22648f };
                float[] color_spec = { 0.628281f, 0.555802f, 0.366065f };
                float[] emission = { 0.0f, 0.0f, 0.0f, 1 };
                float color_shin = 0.4f;

                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color_am);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color_dif);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color_spec);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
                Gl.glMaterialf(Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, color_shin * 128.0f);
            }
            //specular
            if (s == 3)
            {
                //float[] color_am = { 0.19225f, 0.19225f, 0.19225f, 1.0f };
                //float[] color_dif = { 0.50754f, 0.50754f, 0.50754f };
                //float[] color_spec = { 0.508273f, 0.508273f, 0.508273f };
                //float[] emission = { 0.0f, 0.0f, 0.0f, 1 };
                //float color_shin = 0.4f;

                float[] color_am = { 0.0f, 0.0f, 0.0f, 1.0f };
                float[] color_dif = { 0.76f, 0.68f, 0.88f };
                float[] color_spec = { 0.0f, 0.0f, 0.0f };
                float[] emission = { 0.0f, 0.0f, 0.0f, 1 };
                float color_shin = 0.4f;

                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color_am);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color_dif);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color_spec);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
                Gl.glMaterialf(Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, color_shin * 128.0f);
            }
            //emission
            if (s == 4)
            {
                //float[] color_am = { 0.0f, 0.05f, 0.0f, 1.0f };
                //float[] color_dif = { 0.4f, 0.5f, 0.4f };
                //float[] color_spec = { 0.04f, 0.7f, 0.04f };
                //float[] emission = { 0.3f, 0.75f, 0.2f, 1 };
                //float color_shin = 0.78125f;

                //Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color_am);
                //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color_dif);
                //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color_spec);
                //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
                //Gl.glMaterialf(Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, color_shin * 128.0f);

                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                float[] emission = { 0, 1, 0, 0 };
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, new float[] { .2f, .2f, .2f, 1 });
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, new float[] { .8f, .8f, .8f, 1 });
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, new float[] { 0, 0, 0, 1 });
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
            }
            if(s == 5)
            {
                Gl.glDisable(Gl.GL_COLOR_MATERIAL);
                float[] amb = { 1, 0, 0, 0 };
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, amb);
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, new float[] { .8f, .8f, .8f, 1 });
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, new float[] { 0, 0, 0, 1 });
                Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, new float[] { 0, 0, 0, 1 });
            }


            //////////////////////
            Gl.glRotatef(X, 1, 0, 0);
            Gl.glRotatef(Y, 0, 1, 0);
            Gl.glRotatef(Z, 0, 0, 1);
            //Gl.glColor3f(0.8f, 0.2f, 0.2f);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, normal);

            Gl.glDrawElements(Gl.GL_QUADS, 24, Gl.GL_UNSIGNED_INT, indexQuads);
            Gl.glDrawElements(Gl.GL_POLYGON, 6, Gl.GL_UNSIGNED_INT, indexPolygon);
            Gl.glDrawElements(Gl.GL_POLYGON, 6, Gl.GL_UNSIGNED_INT, indexPolygon2);

            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1);
            Gl.glDrawElements(Gl.GL_LINES, 36, Gl.GL_UNSIGNED_INT, indexLines);
            Gl.glTranslated(-0.01, 0.01, 0);
            Gl.glDrawElements(Gl.GL_LINES, 2, Gl.GL_UNSIGNED_INT, indexLinesLoop);

            //////////////////////////
            //Gl.glDisable(Gl.GL_COLOR_MATERIAL);
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
            l = 1;
            Draw();
        }

        private void правоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 2;
            Draw();
        }

        private void сВерхуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 3;
            Draw();
        }

        private void сПередиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ambientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 1;
            Draw();
        }

        private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 2;
            Draw();
        }

        private void specularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 3;
            Draw();
        }

        private void emissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 4;
            Draw();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 0;
        }

        private void правоToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 5;
            Draw();
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 6;
            Draw();
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 7;
            Draw();
        }

        private void ambientTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 5;
            Draw();
        }

        private void вариант1GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 8;
            Draw();
        }
    }
}
