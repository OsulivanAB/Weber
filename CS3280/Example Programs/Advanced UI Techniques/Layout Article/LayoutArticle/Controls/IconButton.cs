using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace LayoutArticle.Controls
{
    public class IconButton : Button
    {
        public Visual Icon
        {
            get { return (Visual)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Visual), typeof(IconButton), new UIPropertyMetadata(null));
    }
}
