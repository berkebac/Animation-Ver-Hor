using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Satır_Sutun_Efekt
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }


        
        private void tbsatırsutun_TextChanged(object sender, TextChangedEventArgs e)
        {
            grid.Children.Clear();
            grid.Children.Add(rect);
            
            try
            {
                grid.RowDefinitions.Clear();
                grid.ColumnDefinitions.Clear();
                for (int i = 0; i < int.Parse(tbsatırsutun.Text); i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                int c = 0;
                int r = 0;
                for (int i = 0; i < int.Parse(tbsatırsutun.Text) * int.Parse(tbsatırsutun.Text); i++)
                {
                    TextBlock tb = new TextBlock();
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.MouseMove += Tb_MouseMove;
                    tb.MouseLeave += Tb_MouseLeave;
                    
                    tb.Text = (i + 1).ToString();
                    tb.FontSize = 25;
                    Grid.SetColumn(tb, c);
                    Grid.SetRow(tb, r);
                    c++;
                    if (grid.ColumnDefinitions.Count==c)
                    {
                        r++;
                        c = 0;
                    }
                    grid.Children.Add(tb);
                }
            
            
            }
            catch { }
        }
        
        private void Tb_MouseLeave(object sender, MouseEventArgs e)
        {
            rect.Visibility = Visibility.Collapsed;
        }
        Rectangle rect = new Rectangle()
        {
            Fill = new SolidColorBrush(Colors.Orange),
            Visibility= Visibility.Collapsed
        };


        private void Tb_MouseMove(object sender, MouseEventArgs e)
        {
            rect.Visibility = Visibility.Visible;
            TextBlock tb = (TextBlock)sender;
            Grid.SetColumn(rect, Grid.GetColumn(tb));
            Grid.SetRow(rect, Grid.GetRow(tb));
        }
    }
}
