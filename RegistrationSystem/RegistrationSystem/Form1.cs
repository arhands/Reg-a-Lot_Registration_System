﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Trey" && radioButton1.Checked)
            {
               // studentView SView = new studentView();
               // SView.Show();
                Hide();
            }

            if (textBox1.Text == "Max" && radioButton2.Checked)
            {
                ProffessorView PView = new ProffessorView();
                PView.Show();
                //string message = "You are not a professor.";
                //string caption = "Authentification Error";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //DialogResult result;

                // Displays the MessageBox.

               // result = MessageBox.Show(message, caption, buttons);
            }

            if (textBox1.Text == "Trey" && radioButton3.Checked)
            {
                string message = "You are not a registrar.";
                string caption = "Authentification Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
