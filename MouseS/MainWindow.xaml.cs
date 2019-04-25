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
            Update();

            
        }


        public void ItemClick(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Focus();
            this.Top = System.Windows.Forms.Control.MousePosition.Y - 450;
            this.Left = System.Windows.Forms.Control.MousePosition.X - 200;
            

        }
        public void Update()
        {
            UpdateSpeed();
        }
        public void UpdateSpeed()
        {
           int speed = MouseSpeed.GetMouseSpeed();
            MouseSpeedSlider.Value = speed;
            MouseSpeedLabel.Content = speed;
        }

        private void MouseSpeedSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            MouseSpeed.SetMouseSpeed((int)MouseSpeedSlider.Value);
            UpdateSpeed();
        }
    }
}
