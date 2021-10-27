using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ListBoxesWPF
{
    public class ListItemGrid : Grid
    {
        public ListItemGrid()
        {
            HorizontalAlignment = HorizontalAlignment.Left;
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            var binding = new Binding("ActualWidth");
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof (ListBoxItem), 1);
            SetBinding(ListItemWidthProperty, binding);
        }

        public double ListItemWidth
        {
            get { return (double)GetValue(ListItemWidthProperty); }
            set { SetValue(ListItemWidthProperty, value); }
        }
        public static readonly DependencyProperty ListItemWidthProperty = DependencyProperty.Register("ListItemWidth", typeof(double), typeof(ListItemGrid), new UIPropertyMetadata(0d, new PropertyChangedCallback(OnListItemWidthChanged)));
        private static void OnListItemWidthChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var grid = source as Grid;
            if (grid != null)
            {
                var newValue = (double)e.NewValue;
                newValue -= 4;
                grid.Width = newValue;
            }
        }
    }
}
