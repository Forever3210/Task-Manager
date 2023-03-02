using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace TaskMananger
{
    public partial class Form1 : Form
    {

        public void enable()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            objRegistryKey.DeleteValue("DisableTaskMgr");
            objRegistryKey.Close();
        }

        public void disable()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", "1");
        }

        private Boolean flagunload = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagunload == true)
            {
            }
            else
            {
                e.Cancel = true;
            }
            //Alt + F4 will also not work 
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            enable();// fix task manager
            MessageBox.Show("Your task manager work"); //text for positive answer
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disable();
            MessageBox.Show("Your task manager now dont work"); //text for negative answer
            //if you dont want have a answer just remove above line
        }
    }
}