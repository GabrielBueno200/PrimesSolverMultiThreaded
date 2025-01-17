﻿using PrimeNumbersThreaded.Utilities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrimeNumbersThreaded.Graphics
{
    public abstract class Graphic : Form
    {
        protected System.ComponentModel.IContainer Components;
        protected Chart chart;

        public Graphic(string title)
        {
            InitializeGraphic(title);
            InitializeForm(title);
        }

        protected abstract void Plot(object sender, EventArgs e);

        protected void ConfigureAxis(string XAxisTitle, string YAxisTitle)
        {
            var chartArea = chart.ChartAreas[chart.Name];

            chartArea.AxisX.Title = XAxisTitle;
            chartArea.AxisX.TitleFont = new Font("Arial", 10.0f);

            chartArea.AxisY.Title = YAxisTitle;
            chartArea.AxisY.TitleFont = new Font("Arial", 10.0f);

            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
        }

        private void InitializeGraphic(string title)
        {
            Components = new System.ComponentModel.Container();
            chart = new Chart();

            ChartArea chartArea = new ChartArea();
            Legend legend = new Legend();

            (chart as System.ComponentModel.ISupportInitialize).BeginInit();
            SuspendLayout();

            chartArea.Name = title;
            chart.ChartAreas.Add(chartArea);

            // Legends
            legend.Name = "Legend1";
            chart.Legends.Add(legend);

            chart.Name = title;
            chart.Size = new Size(900, 450);

            chart.Location = new Point(0, 0);
        }

        private void InitializeForm(string title)
        {
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(900, 450);
            Controls.Add(chart);

            Name = title;
            Text = title;
            Load += new EventHandler(Plot);
            
            (chart as System.ComponentModel.ISupportInitialize).EndInit();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }
      
    }
}