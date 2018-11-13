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

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[,] cell = new TextBlock[3, 3];
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
                for (int k = 0; k < 3; k++)
                {
                    cell[i, k] = new TextBlock { HorizontalAlignment = HorizontalAlignment.Center, TextWrapping = TextWrapping.NoWrap, VerticalAlignment = VerticalAlignment.Center };
                    Grid.SetRow(cell[i, k], i + 1);
                    Grid.SetColumn(cell[i, k], k);
                    MyGrid.Children.Add(cell[i, k]);
                }
            cell[1, 2].Text = "2";
            cell[2, 2].Text = "2";
            cell[0, 2].Text = "2";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int emptycell = 0;
            if (e.Key == Key.W)
            {               
                for (int col = 0; col < 3; col++)
                {
                    int[] temp = new int[3];
                    //Ряд в темп
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[i, col].Text);
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    int loop = 0;
                    while (loop++ < 2)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (temp[i] != 0 && i > 0)
                            {
                                if (temp[i - 1] == 0)
                                {
                                    if (i > 1 && temp[i - 2] == 0)
                                    {
                                        temp[i - 2] = temp[i];
                                        temp[i] = 0;
                                    }
                                    else
                                    {
                                        temp[i - 1] = temp[i];
                                        temp[i] = 0;
                                    }
                                }
                            }
                            if (temp[i] != 0 && i > 0 && temp[i-1] == temp[i])
                            {
                                temp[i - 1] += temp[i - 1];
                                temp[i] = 0;
                            }
                        }
                    }
                    //Обновление блоков
                    for (int i = 0; i < 3; i++)
                    {
                        if (temp[i] != 0)
                            cell[i, col].Text = temp[i].ToString();
                        else { cell[i, col].Text = ""; emptycell++; }
                    }
                }
            }
            if (e.Key == Key.S)
            {
                for (int col = 0; col < 3; col++)
                {
                    int[] temp = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[i, col].Text);
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    int loop = 0;
                    while (loop++ < 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (temp[i] != 0 && i < 2)
                            {
                                if (temp[i + 1] == 0)
                                {
                                    if (i < 1 && temp[i + 2] == 0)
                                    {
                                        temp[i + 2] = temp[i];
                                        temp[i] = 0;
                                    }
                                    else
                                    {
                                        temp[i + 1] = temp[i];
                                        temp[i] = 0;
                                    }
                                }
                            }
                            if (temp[i] != 0 && i < 2 && temp[i + 1] == temp[i])
                            {
                                temp[i + 1] += temp[i + 1];
                                temp[i] = 0;
                            }
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (temp[i] != 0)
                            cell[i, col].Text = temp[i].ToString();
                        else { cell[i, col].Text = ""; emptycell++; }
                    }
                }
            }
            if (e.Key == Key.A)
            {
                for (int row = 0; row < 3; row++)
                {
                    int[] temp = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[row, i].Text);
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    int loop = 0;
                    while (loop++ < 2)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (temp[i] != 0 && i > 0)
                            {
                                if (temp[i - 1] == 0)
                                {
                                    if (i > 1 && temp[i - 2] == 0)
                                    {
                                        temp[i - 2] = temp[i];
                                        temp[i] = 0;
                                    }
                                    else
                                    {
                                        temp[i - 1] = temp[i];
                                        temp[i] = 0;
                                    }
                                }
                            }
                            if (temp[i] != 0 && i > 0 && temp[i - 1] == temp[i])
                            {
                                temp[i - 1] += temp[i - 1];
                                temp[i] = 0;
                            }
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (temp[i] != 0)
                            cell[row, i].Text = temp[i].ToString();
                        else { cell[row, i].Text = ""; emptycell++; }
                    }
                }
            }
            if (e.Key == Key.D)
            {
                for (int row = 0; row < 3; row++)
                {
                    int[] temp = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[row, i].Text);
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    int loop = 0;
                    while (loop++ < 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (temp[i] != 0 && i < 2)
                            {
                                if (temp[i + 1] == 0)
                                {
                                    if (i < 1 && temp[i + 2] == 0)
                                    {
                                        temp[i + 2] = temp[i];
                                        temp[i] = 0;
                                    }
                                    else
                                    {
                                        temp[i + 1] = temp[i];
                                        temp[i] = 0;
                                    }
                                }
                            }
                            if (temp[i] != 0 && i < 2 && temp[i + 1] == temp[i])
                            {
                                temp[i + 1] += temp[i + 1];
                                temp[i] = 0;
                            }
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (temp[i] != 0)
                            cell[row, i].Text = temp[i].ToString();
                        else { cell[row, i].Text = ""; emptycell++; }
                    }
                }
            }
            if (emptycell > 0)
            {
                Random rand = new Random();
                int a, b;
                for (a = rand.Next(0, 3), b = rand.Next(0, 3); cell[a, b].Text != ""; a = rand.Next(0, 3), b = rand.Next(0, 3)) ;
                cell[a, b].Text = "2";
            }
        }
    }
}
