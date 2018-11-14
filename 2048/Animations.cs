using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;

namespace _2048
{
    class Animations
    {
        public static ThicknessAnimation newAnimation = new ThicknessAnimation()
        {
            From = new Thickness(2, 2, 2, 2),
            To = new Thickness(0, 0, 0, 0),
            Duration = TimeSpan.FromSeconds(0.3),
            AutoReverse = true
        };
        public static ColorAnimation labelColorAnimation = new ColorAnimation()
        {
            From = Color.FromArgb(255, 147, 187, 255),
            To = Color.FromArgb(255, 147, 225, 255),
            Duration = TimeSpan.FromSeconds(0.3),
            AutoReverse = true
        };
        public static void PlayAnimation(Label label)
        {
            label.BeginAnimation(Label.MarginProperty, newAnimation);
            label.Background.BeginAnimation(SolidColorBrush.ColorProperty, labelColorAnimation);
        }
    }
}
