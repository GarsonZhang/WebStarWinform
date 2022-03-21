using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ClientDemo
{
    public partial class frmMain : Form
    {
        internal string[] args { get; }
        public frmMain(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsRunAsAdmin() == false)
            {
                MessageBox.Show("该操作需要《管理员》权限，请使用《管理员》运行此程序");
                return;
            }

            // 注册协议

            RegistryKey key = Registry.ClassesRoot;
            RegistryKey software = key.CreateSubKey("gzclienttest");
            software.SetValue("", "gzclienttestProtocol");
            software.SetValue("URL Protocol", Application.ExecutablePath);

            var s = software.CreateSubKey("shell\\open\\command");
            s.SetValue("", "\"" + Application.ExecutablePath + "\"\"%1\"");

            MessageBox.Show("程序注册成功，需要《退出》程序使用《普通用户》打开程序");
            Application.Exit();
        }

        /// <summary>
        /// 判断程序是否是以管理员身份运行。
        /// </summary>
        public static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += ("  " + Note.GetMainIntPtr().ToString());

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (args != null && args.Length > 0)
            {
                // 收到消息
                string s = args[0];
                textBox1.Text += (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + s + System.Environment.NewLine);
                HandleMessage(s);
            }

        }


        frmDemo1 frm1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new frmDemo1();
                frm1.Show();
            }
            else
            {
                frm1.Activate();
            }
        }
        frmDemo2 frm2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new frmDemo2();
                frm2.Show();
            }
            else
            {
                frm2.Activate();
            }
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Note.WM_COPYDATA)
            {
                // 收到消息
                string s = ((Note.CopyData)Marshal.PtrToStructure(m.LParam, typeof(Note.CopyData))).lpData;
                textBox1.Text += (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + s + System.Environment.NewLine);
                HandleMessage(s);
            }
            else
                base.WndProc(ref m);
        }


        void HandleMessage(string s)
        {


            string command = this.GetQuery(s, "command");

            switch (command)
            {
                case "openform":
                    {
                        string form = this.GetQuery(s, "openform");
                        switch (form)
                        {
                            case "form1":
                                btn_open1.PerformClick();
                                break;
                            case "form2":
                                btn_open2.PerformClick();
                                break;
                        }
                    }
                    break;
            }
        }


        string GetQuery(string message, string name)
        {
            //url.Query 
            Regex reg = new Regex(name + ":(\\w+)", RegexOptions.IgnoreCase);
            var m = reg.Match(message);
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
                return "";
        }
    }
}
