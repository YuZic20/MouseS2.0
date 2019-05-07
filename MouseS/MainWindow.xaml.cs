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
using MenuItem = System.Windows.Controls.MenuItem;

namespace MouseS
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Profile> profiles;
        public int IndexofCurrentProfile =0;
        public int ID;

        public MainWindow()
        {
            InitializeComponent();
            
            NotifyIcon notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = SystemIcons.Application;
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
        public void Update()
        {
            UpdateSpeed(false);
            UpdateClick(false);
            UpdateLines(false);
            SaveData();
        }
        public void UpdateSpeed(bool save = true)
        {
           int speed = MouseSpeedGet.GetMouseSpeed();
            MouseSpeedSlider.Value = speed;
            MouseSpeedLabel.Content = speed;
            profiles[IndexofCurrentProfile].MouseSpeed = speed;
            if (save)
            {
                SaveData();
            }

        }
        public void UpdateClick(bool save = true)
        {
            int ClickSpeed = GetDubbleClick.GetClickSpeed();
            DubbleClickTimeSlider.Value = ClickSpeed;
            DubbleClickTimeLabel.Content = ClickSpeed;
            profiles[IndexofCurrentProfile].DubbleClick = ClickSpeed;
            if (save)
            {
                SaveData();
            }
        }
        public void UpdateLines(bool save = true)
        {
            int Lines = GetScrollLines.GetSpeed();
            LinesSlider.Value = Lines;
            LinesLabel.Content = Lines;
            profiles[IndexofCurrentProfile].ScrollSpeed = Lines;
            if (save)
            {
                SaveData();
            }

        }
        public void SaveData()
        {
            DataHandle.SaveProfiles(profiles, ID);
        }

        public Profile CurrentData()
        {
            
            Profile profile = new Profile();
            profile.Name = (string)ProfileNow.Header;
            profile.MouseSpeed = MouseSpeedGet.GetMouseSpeed();
            profile.ScrollSpeed = GetScrollLines.GetSpeed();
            profile.DubbleClick = GetDubbleClick.GetClickSpeed();
            return profile;
        }
        public void ChangeProfile(int IndexOfProfile)
        {
            ProfileNow.Header = profiles[IndexOfProfile].Name;
            MouseSpeed.SetMouseSpeed(profiles[IndexofCurrentProfile].MouseSpeed);
            SetDubbleClick.SetClickSpeed(profiles[IndexofCurrentProfile].DubbleClick);
            SetScrollLines.SetLineSpeed(profiles[IndexofCurrentProfile].ScrollSpeed);
            Update();
        }

        public void GenerateProfileButtons(List<Profile> profiles)
        {
            ProfileNow.Items.Clear();
            for(int i = 0; i< profiles.Count(); i++)
            {
                MenuItem menuitem = new MenuItem();
                menuitem.Header = profiles[i].Name;
                menuitem.Tag = i;
                menuitem.Click += new RoutedEventHandler(MenuItem_Click);
                ProfileNow.Items.Add(menuitem);
            }
        }

        private void MouseSpeedSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            MouseSpeed.SetMouseSpeed((int)MouseSpeedSlider.Value);
            UpdateSpeed();
        }

        private void DubbleClickTimeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            SetDubbleClick.SetClickSpeed((int)DubbleClickTimeSlider.Value);
            UpdateClick();
        }

        private void LanesSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            SetScrollLines.SetLineSpeed((int)LinesSlider.Value);
            UpdateLines();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            IndexofCurrentProfile = (int)item.Tag;
            ChangeProfile(IndexofCurrentProfile);
            GenerateProfileButtons(profiles);
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile = CurrentData();
            profile.Name = ProfileName.Text;
            profiles.Add(profile);
            GenerateProfileButtons(profiles);
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(IdText.Text != "")
            {
                int n;
                bool isNumeric = int.TryParse(IdText.Text, out n);
                if (isNumeric)
                {
                    IntPanel.Visibility = Visibility.Hidden;
                    ID = n;

                    profiles = DataHandle.LoadProfiles(ID);
                    ChangeProfile(0);
                    GenerateProfileButtons(profiles);
                    Update();
                }
            }
        }
    }
}
