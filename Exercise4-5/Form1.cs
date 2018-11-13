﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise4_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            var initXs = new List<double> { -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2 };
            var initYs = initXs.Select(x => Math.Sin(x * 5) * Math.Exp(x)).ToList();
            ShowBezier(initXs, initYs);
            ShowMNK(initXs, initYs);
            ShowSource(initXs, initYs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var initXs = new List<double> { -3.2, -2.1, 0.4, 0.7, 2, 2.5, 2.777 };
            var initYs = new List<double> { 10, -2, 0, -7, 7, 0, 0 };
            ShowBezier(initXs, initYs);
            ShowMNK(initXs, initYs);
            ShowSource(initXs, initYs);
        }

        public void ShowSource(List<double> initXs, List<double> initYs)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < initXs.Count; i++)
            {
                chart1.Series[2].Points.AddXY(initXs[i], initYs[i]);
            }

        }

        public void ShowBezier(List<double> initXs, List<double> initYs)
        {
            var resXs = new List<double>();
            var resYs = new List<double>();

            for (double i = 0; i <= 1; i += 0.01F)
            {
                var resX = Bezier.Approx(initXs.Count - 1, i, initXs);
                var resY = Bezier.Approx(initYs.Count - 1, i, initYs);

                resXs.Add(resX);
                resYs.Add(resY);
            }

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < resXs.Count; i++)
            {
                chart1.Series[0].Points.AddXY(resXs[i], resYs[i]);
            }

        }

        public void ShowMNK(List<double> initXs, List<double> initYs)
        {
            var resXs = new List<double>();
            var resYs = new List<double>();

            ProgramG.RunMainProgram(initXs, initYs, out resXs, out resYs, (int)numericUpDown1.Value + 1);
          
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < resXs.Count; i++)
            {
                chart1.Series[1].Points.AddXY(resXs[i], resYs[i]);
            }
        }

    }
}
