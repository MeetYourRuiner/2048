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
        public const int Size = 4;
        public int iScore = 0;
        public Label[,] cell = new Label[Size, Size];

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {

            for (int i = 0; i < Size; i++)
                for (int k = 0; k < Size; k++)
                {
                    cell[i, k] = new Label
                    {
                        Content = "",
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Background = new SolidColorBrush(Color.FromArgb(255, 147, 187, 255)),
                        Margin = new Thickness(2, 2, 2, 2),
                        FontWeight = FontWeights.Bold,
                        FontSize = 35,
                        Foreground = Brushes.White
                    };
                    Grid.SetRow(cell[i, k], i + 1);
                    Grid.SetColumn(cell[i, k], k);
                    MyGrid.Children.Add(cell[i, k]);
                }
            Random rand = new Random();
            cell[rand.Next(0, Size), rand.Next(0, Size)].Content = "2";
            cell[rand.Next(0, Size), rand.Next(0, Size)].Content = "2";
        }

        public static bool SortZeros(int[] array, bool IsReversed = false)
        {
            bool action = false;
            if (IsReversed)
                Array.Reverse(array);
            for (int i = 0; i < Size; i++)
            {
                if (array[i] == 0)
                {
                    {
                    for (int j = i + 1; j < Size; j++)
                        if (array[j] != 0)
                        {
                            array[i] = array[j];
                            array[j] = 0;
                            goto Success;
                        }
                    goto Failure;
                    }
                }
                continue;
                Success:
                action = true;
            }
            Failure:
            if (IsReversed)
                Array.Reverse(array);
            return action;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int emptycells = 0;
            int actions = 0;
            // W
            if (e.Key == Key.W || e.Key == Key.Up)
            {
                for (int col = 0; col < Size; col++)
                {
                    int[] temp = new int[Size];
                    //Ряд в темп
                    for (int i = 0; i < Size; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[i, col].Content.ToString());
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    //
                    //Сортируем нули
                    if (SortZeros(temp))
                        actions++;
                    //
                    //Складываем смежные
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (temp[i] == temp[i + 1] && temp[i] != 0)
                        {
                            temp[i] *= 2;
                            iScore += temp[i];
                            Score.Content = iScore.ToString();
                            temp[i + 1] = 0;
                            i++;
                            actions++;
                        }
                    }
                    //
                    SortZeros(temp);
                    //Обновляем текст
                    for (int i = 0; i < Size; i++)
                    {
                        if (temp[i] != 0)
                            cell[i, col].Content = temp[i].ToString();
                        else
                        {
                            cell[i, col].Content = "";
                            emptycells++;
                        }
                    }
                    //
                }
            }
            // S
            if (e.Key == Key.S || e.Key == Key.Down)
            {
                for (int col = 0; col < Size; col++)
                {
                    int[] temp = new int[Size];
                    //Ряд в темп
                    for (int i = 0; i < Size; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[i, col].Content.ToString());
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    //
                    //Сортируем нули
                    if (SortZeros(temp,true))
                        actions++;
                    //
                    //Складываем смежные
                    for (int i = Size - 1; i > 0; i--)
                    {
                        if (temp[i] == temp[i - 1] && temp[i] != 0)
                        {
                            temp[i] *= 2;
                            temp[i - 1] = 0;
                            iScore += temp[i];
                            Score.Content = iScore.ToString();
                            i--;
                            actions++;                          
                        }
                    }
                    //
                    SortZeros(temp, true);
                    //Обновляем текст
                    for (int i = Size - 1; i >= 0; i--)
                    {
                        if (temp[i] != 0)
                            cell[i, col].Content = temp[i].ToString();
                        else
                        {
                            cell[i, col].Content = "";
                            emptycells++;
                        }
                    }
                    //
                }
            }
            // A
            if (e.Key == Key.A || e.Key == Key.Left)
            {
                for (int row = 0; row < Size; row++)
                {
                    int[] temp = new int[Size];
                    //Ряд в темп
                    for (int i = 0; i < Size; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[row, i].Content.ToString());
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    //
                    //Сортируем нули
                    if (SortZeros(temp))
                        actions++;
                    //
                    //Складываем смежные
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (temp[i] == temp[i + 1] && temp[i] != 0)
                        {
                            temp[i] *= 2;
                            temp[i + 1] = 0;
                            iScore += temp[i];
                            Score.Content = iScore.ToString();
                            i++;
                            actions++;                            
                        }
                    }
                    //
                    SortZeros(temp);
                    //Обновляем текст
                    for (int i = 0; i < Size; i++)
                    {
                        if (temp[i] != 0)
                            cell[row, i].Content = temp[i].ToString();
                        else
                        {
                            cell[row ,i].Content = "";
                            emptycells++;
                        }
                    }
                    //
                }
            }
            // D
            if (e.Key == Key.D || e.Key == Key.Right)
            {
                for (int row = 0; row < Size; row++)
                {
                    int[] temp = new int[Size];
                    //Ряд в темп
                    for (int i = 0; i < Size; i++)
                    {
                        try
                        {
                            temp[i] = int.Parse(cell[row, i].Content.ToString());
                        }
                        catch (FormatException)
                        {
                            temp[i] = 0;
                        }
                    }
                    //
                    //Сортируем нули
                    if (SortZeros(temp, true))
                        actions++;
                    //
                    //Складываем смежные
                    for (int i = Size - 1; i > 0; i--)
                    {
                        if (temp[i] == temp[i - 1] && temp[i] != 0)
                        {
                            temp[i] *= 2;
                            temp[i - 1] = 0;
                            iScore += temp[i];
                            Score.Content = iScore.ToString();
                            i--;
                            actions++;
                            
                        }
                    }
                    //
                    SortZeros(temp, true);
                    //Обновляем текст
                    for (int i = Size - 1; i >= 0; i--)
                    {
                        if (temp[i] != 0)
                            cell[row, i].Content = temp[i].ToString();
                        else
                        {
                            cell[row, i].Content = "";
                            emptycells++;
                        }
                    }
                    //
                }
            }
            // Рандомить новое число, если есть свободные клетки и было совершенно любое действие
            if (emptycells > 0 && actions > 0)
            {
                Random rand = new Random();
                int a, b;
                for (a = rand.Next(0, Size), b = rand.Next(0, Size); cell[a, b].Content.ToString() != ""; a = rand.Next(0, Size), b = rand.Next(0, Size));
                if (rand.NextDouble() > 0.11)
                    cell[a, b].Content = "2";
                else
                    cell[a, b].Content = "4";
                Animations.PlayAnimation(cell[a, b]);
            }
        }
    }
}
