using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;

namespace GraphsPlus
{
    public partial class GraphPlus : Form
    {
        Pen myPen = new Pen(Color.DarkBlue);
        Pen axisPen = new Pen(Color.Crimson);
        Graphics myGraphics = null;
        Graphics sinGraph = null;
        Graphics cosGraph = null;
        Graphics tanGraph = null;
        Graphics axis = null;

        static int center_x, center_y;
        static int start_x, start_y;
        static int end_x, end_y;

        static int my_angle = 0;
        static int my_length = 0;
        static int my_increment = 0;
        static int num_lines = 0;

        static bool useRandomColor;

        static float vertOffset = 0;
        static float scale = 0;
        static float funcLength = 0;
        static float accuracy = 0;
        static int penWidth = 0;

        float drawY2 = 0;

        Color backGroundColor = Color.FromArgb(179, 229, 252);


        public GraphPlus()
        {
            InitializeComponent();
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;

           
        }

        private void DrawAxis()
        {
            int prevX = canvas.Width/2;
            int prevY = canvas.Height / 2;
            axis = canvas.CreateGraphics();
            axis.DrawLine(axisPen, canvas.Width/2, canvas.Height/2, (canvas.Width/2)+canvas.Width/2, canvas.Height/2);
            axis.DrawLine(axisPen, canvas.Width / 2, canvas.Height / 2, (canvas.Width / 2) - canvas.Width / 2, canvas.Height / 2);

            axis.DrawLine(axisPen, canvas.Width / 2, canvas.Height / 2, canvas.Width / 2, (canvas.Height / 2) + canvas.Height/2);
            axis.DrawLine(axisPen, canvas.Width / 2, canvas.Height / 2, canvas.Width / 2, (canvas.Height / 2) - canvas.Height / 2);
        }

        /// <summary>
        /// Handles Sin drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Start Positions
            float posX = 0;
            float posY = 0;

            // Position that is calculated based on sin of X
            float posY_2 = 0;

            // Setting Line params based on LineConfig;
            LineConfig();
            myPen.Width = penWidth;
            myGraphics.Clear(backGroundColor);
            myGraphics = canvas.CreateGraphics();
            sinGraph = canvas.CreateGraphics();


            for (float x = 0; x < funcLength; x += accuracy)
            {
                posY_2 = (float)Math.Sin(x);
                // Draws a line from start position to end poisition. End position is calculated based on the SIN function of X. X is multiplied by scale
                // to move it forward along the x axis and y is multiplyed by scale ant vert offset to position it in the center of the form.
                sinGraph.DrawLine(myPen, posX * scale, posY * scale + vertOffset, x * scale, posY_2 * scale + vertOffset);

                posX = x;
                posY = posY_2;
            }
            DrawAxis();
        }

        /// <summary>
        /// Handles Cos Drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawCos_Click(object sender, EventArgs e)
        {
            // Start Positions
            float posX = 0;
            float posY = 0;

            // Position that is calculated based on sin of X
            float posY_2 = 0;

            // Setting Line params based on LineConfig;
            LineConfig();
            myPen.Width = penWidth;
            myGraphics.Clear(backGroundColor);
            cosGraph = canvas.CreateGraphics();
   

            for (float x = 0; x < funcLength; x += accuracy)
            {
                posY_2 = (float)Math.Cos(x);
                // Draws a line from start position to end poisition. End position is calculated based on the SIN function of X. X is multiplied by scale
                // to move it forward along the x axis and y is multiplyed by scale ant vert offset to position it in the center of the form.
                cosGraph.DrawLine(myPen, posX * scale, posY * scale + vertOffset, x * scale, posY_2 * scale + vertOffset);

                posX = x;
                posY = posY_2;
            }
            DrawAxis();
        }

        /// <summary>
        /// Handles Tan Drawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawTan_Click(object sender, EventArgs e)
        {
            // Start Positions
            float posX = 0;
            float posY = 0;

            // Position that is calculated based on sin of X
            float posY_2 = 0;

            // Setting Line params based on LineConfig;
            LineConfig();
            myPen.Width = penWidth;
            myGraphics.Clear(backGroundColor);
            tanGraph = canvas.CreateGraphics();
            

            for (float x = 0; x < funcLength; x += accuracy)
            {
                posY_2 = (float)Math.Tan(x);
                // Draws a line from start position to end poisition. End position is calculated based on the SIN function of X. X is multiplied by scale
                // to move it forward along the x axis and y is multiplyed by scale ant vert offset to position it in the center of the form.
                tanGraph.DrawLine(myPen, posX * scale, posY * scale + vertOffset, x * scale, posY_2 * scale + vertOffset);

                posX = x;
                posY = posY_2;
            }
            DrawAxis();
        }


        private void button2_Click_2(object sender, EventArgs e)
        {
            myGraphics.Clear(backGroundColor);

            int pos1 = int.Parse(cPos1.Text);
            int pos2 = int.Parse(cPos1.Text);
            int pos3 = int.Parse(cPos1.Text);
            int pos4 = int.Parse(cPos1.Text);

            

            myGraphics.DrawEllipse(myPen, pos1, pos2, pos3, pos4);
            DrawAxis();
        }



        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Start Positions
            float posX = 0;
            float posY = 0;

            // Position that is calculated based on sin of X

            // Setting Line params based on LineConfig;
            LineConfig();
            myPen.Width = penWidth;
            myGraphics.Clear(backGroundColor);
            tanGraph = canvas.CreateGraphics();


            for (float x = 0; x < funcLength; x += accuracy)
            {
                drawY2 = (float)Math.Tan(x);
                // Draws a line from start position to end poisition. End position is calculated based on the SIN function of X. X is multiplied by scale
                // to move it forward along the x axis and y is multiplyed by scale ant vert offset to position it in the center of the form.
                tanGraph.DrawLine(myPen, posX * scale, posY * scale + vertOffset, x * scale, drawY2 * scale + vertOffset);

                posX = x;
                posY = drawY2;
            }
            DrawAxis();
        }



        private void LineConfig()
        {
             vertOffset = canvas.Height / 2;
             scale = float.Parse(fScale.Text);
             funcLength = float.Parse(fLength.Text);
             accuracy = float.Parse(fAccuracy.Text);
             penWidth = int.Parse(lineWidth.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }


        #region Fractal Drawings
        // Checks radio buttons.
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                useRandomColor = true;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                useRandomColor = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles drawing the graphic.
        /// </summary>
        private void DrawImage()
        {
            // Sets Colors and handles random color generation.
            if (useRandomColor == true)
            {
                Random randomGen = new Random();
                myPen.Color = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));
            }

            else
            {
                myPen.Color = Color.DarkBlue;
            }
            
            // Sets angle and length.
            my_angle = my_angle + Int32.Parse(angle.Text);
            my_length = my_length + Int32.Parse(increment.Text);

            //Calculated end position based on startposition with Sin and Cos.
            end_x = (int)(start_x + Math.Sin(my_angle * .017453292519) * my_length);
            end_y = (int)(start_y + Math.Cos(my_angle * .017453292519) * my_length);

            // Creates an array of points (start and end point);
            Point[] points =
                {
                    new Point(start_x, start_y),
                    new Point(end_x, end_y)
                };
            
            // Sets the new start points as the previous end points.
            start_x = end_x;
            start_y = end_y;

            // Draws the Graphic based on the (points) array.
            myGraphics.DrawLines(myPen, points);

        }

        /// <summary>
        /// Refreshes values when button is pressed;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            my_length = Int32.Parse(length.Text);
            my_increment = Int32.Parse(increment.Text);
            my_angle = Int32.Parse(angle.Text);
            num_lines = Int32.Parse(lineNum.Text);

            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;

            canvas.Refresh();
        }

        /// <summary>
        /// Calls the draw function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 2;
           // my_length = Int32.Parse(length.Text);
            myGraphics = canvas.CreateGraphics();
            //Calls the draw function based on the number of lines the user wants.
            for (int i = 0; i < Int32.Parse(lineNum.Text); i++)
            {
                DrawImage();
            }
        }
#endregion
    }
}
