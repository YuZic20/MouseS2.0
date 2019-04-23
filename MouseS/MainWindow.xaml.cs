using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;


namespace MouseS
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            
            NotifyIcon notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new System.Drawing.Icon(@"Icon.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "MouseS";
            notifyIcon1.Click += ItemClick;

            
        }


        public void ItemClick(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Focus();
            this.Top = System.Windows.Forms.Control.MousePosition.Y - 450;
            this.Left = System.Windows.Forms.Control.MousePosition.X - 200;
            

        }
    }
}
