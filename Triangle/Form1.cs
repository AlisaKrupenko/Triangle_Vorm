﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Triangle
{
    public partial class Form1 : Form
    {
        Graphics gp ;
        Pen p;
        TextBox txtA, txtB, txtC;
        Button button1, button2;
        Point p1, p2, p3;
        Panel panel1;
        Label lbl;
        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            p = new Pen(Brushes.Black, 2);
            panel1 = new Panel();
            panel1.Location = new Point(400,250);
            panel1.Size = new Size(200, 100);
            gp = panel1.CreateGraphics();
            button2 = new Button();
            button2.Text = "Рисовать треугольник";
            button2.Location = new Point(200, 25);
            button2.Size = new Size(100, 50);
            button2.BackColor = Color.Coral;
            button1 = new Button();
            button1.Text = "Запуск";
            button1.BackColor = Color.Coral;
            lbl = new Label();
            lbl.Text = "Стороны:";
            txtA = new TextBox();
            txtB = new TextBox();
            txtC = new TextBox();
            button1.Location = new Point(200, 100);
            button1.Size = new Size(100,50);
            txtA.Location = new Point(50,100);
            txtB.Location = new Point(50,125);
            txtC.Location = new Point(50,150);
            lbl.Location = new Point(50, 80);
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(txtC);
            txtA.Text = "A";
            txtB.Text = "B";
            txtC.Text = "C";
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(panel1);
            this.Controls.Add(lbl);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if ((txtA.Text == txtB.Text) && (txtB.Text == txtC.Text) && (txtC.Text == txtA.Text)) // равносторонний
            {
                panel1.Refresh();
                p1 = new Point(40, 90);
                p2 = new Point(150, 90);
                p3 = new Point(90, 20);
            }
            else if ((txtA.Text == txtB.Text) || (txtB.Text == txtC.Text) || (txtC.Text == txtA.Text)) // равнобедренный
            {
                
                    panel1.Refresh();
                    p1 = new Point(5, 80);
                    p2 = new Point(150, 80);
                    p3 = new Point(75, 30);
            }
            else
            {
                panel1.Refresh();
                p1 = new Point(25, 25);
                p2 = new Point(170, 45);
                p3 = new Point(45, 90);
            }
            Point[] list = new Point[3] { p1, p2, p3 };
            gp.DrawPolygon(p, list);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtA.Text == "A" && txtB.Text == "B" && txtC.Text == "C")
            {
                MessageBox.Show("Стороны не заданы", " ");
            }
            else
            {
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new Point(400, -75);

                ListBox listB = new ListBox();
                listB.Location = new Point(20, 200);
                listB.Size = new Size(300, 200);
                listB.Font = new Font("Georgia", 10);
                pictureBox1.Size = new Size(250, 350);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                double a, b, c;
                a = Convert.ToDouble(txtA.Text);
                b = Convert.ToDouble(txtB.Text);
                c = Convert.ToDouble(txtC.Text);
                Triangle triangle = new Triangle(a, b, c, Triangle.Height(a, b, c));
                listB.Items.Add("Сторона а: " + txtA.Text);
                listB.Items.Add("Сторона b: " + txtB.Text);
                listB.Items.Add("Сторона c: " + txtC.Text);
                listB.Items.Add("Высота: " + triangle.Height());
                listB.Items.Add("Периметр: " + triangle.Perimeter());
                listB.Items.Add("Площадь: " + triangle.Surface());
                if (triangle.ExistTriangle) { listB.Items.Add("Существует"); }
                else { listB.Items.Add("Не существует"); }
                pictureBox1.Image = triangle.TypeOfTriangle();

                this.Controls.Add(pictureBox1);
                this.Controls.Add(listB);

            }

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form Form2 = new Form();
            Form2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
