using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int width = 90, height = 90;
        int[,] testMap;
        Random rnd = new Random();
        void RandamMakeMap(int depth, int maxDepth, int[] oldLand, int oldLength)
        {
            if (depth == maxDepth) return;
            int[] newLand = new int[oldLength * 4];
            int nowIndex = 0;
            for (int i = 0; i < oldLength; i++)
            {
                int oldX = oldLand[i] % width;
                int oldY = oldLand[i] / width;
                for (int j = oldX - 1; j <= oldX + 1; j += 2)
                {
                    if (j >= 0 && j < width && testMap[j, oldY] == 0)
                    {
                        if (checkMake(j, oldY, depth, maxDepth)) newLand[nowIndex++] = (j + oldY * width);
                    }
                }
                for (int j = oldY - 1; j <= oldY + 1; j += 2)
                {
                    if (j >= 0 && j < height && testMap[oldX, j] == 0)
                    {
                        if (checkMake(oldX, j, depth, maxDepth)) newLand[nowIndex++] = (oldX + j * width);
                    }
                }

            }
            if (nowIndex > 0) RandamMakeMap(depth + 1, maxDepth, newLand, nowIndex);
        }
        private bool checkMake(int _x, int _y, int depth, int maxDepth)
        {
            if (rnd.Next(depth / 3, maxDepth) < maxDepth / 10 * 7)
            {
                testMap[_x, _y] = 1;
                return true;
            }
            testMap[_x, _y] = 1;
            return false;
        }
        int rndPlus = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            rndPlus = 100;
            testMap = new int[width, height];

            int _xy = (new Random()).Next(width) + width * (new Random()).Next(height);

            testMap[_xy % width, _xy / height] = 1;

            int[] startXY = new int[] { _xy };

            RandamMakeMap(0, 30, startXY, 1);




            //---------------output-----------------------
            string testS = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    testS += testMap[i, j].ToString() + " ";
                }
                testS += "\n";
            }
            label1.Text = testS;
        }
    }
}
