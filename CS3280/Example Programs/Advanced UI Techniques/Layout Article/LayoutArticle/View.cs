using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace LayoutArticle
{
    public class View : ItemsControl
    {
        public View()
        {
            //var defaultTemplate = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(StackPanel)));
            //defaultTemplate.Seal();
            //ItemsPanelProperty.OverrideMetadata(typeof(View), new FrameworkPropertyMetadata(defaultTemplate));
        }

        // Attached property used to define column breaks
        public static readonly DependencyProperty ColumnBreakProperty = DependencyProperty.RegisterAttached("ColumnBreak", typeof(bool), typeof(View), new PropertyMetadata(false));
        public static bool GetColumnBreak(DependencyObject o)
        {
            return (bool)o.GetValue(ColumnBreakProperty);
        }
        public static void SetColumnBreak(DependencyObject o, bool value)
        {
            o.SetValue(ColumnBreakProperty, value);
        }

        // Property used to detirmine group break (adds a space between elements)
        public static readonly DependencyProperty GroupBreakProperty = DependencyProperty.RegisterAttached("GroupBreak", typeof(bool), typeof(View), new PropertyMetadata(false));
        public static bool GetGroupBreak(DependencyObject o)
        {
            return (bool)o.GetValue(GroupBreakProperty);
        }
        public static void SetGroupBreak(DependencyObject o, bool value)
        {
            o.SetValue(GroupBreakProperty, value);
        }
    }
}
