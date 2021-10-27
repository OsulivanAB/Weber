using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ListBoxesWPF
{
    public class CarouselPanel : Panel
    {
        private bool _eventHooked = false;

        protected override Size MeasureOverride(Size availableSize)
        {
            if (!_eventHooked)
            {
                var listBox = GetListBox();
                if (listBox != null)
                {
                    listBox.SelectionChanged += (sender, e) => InvalidateArrange();
                    _eventHooked = true;
                }
            }

            foreach (UIElement child in Children)
                child.Measure(new Size(300, 500));

            base.MeasureOverride(availableSize);
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var listBox = GetListBox();
            if (listBox == null) return base.ArrangeOverride(finalSize);
            if (listBox.SelectedIndex < 0) listBox.SelectedIndex = 0;

            int selectedIndex = listBox.SelectedIndex;
            int rightCount = Children.Count - selectedIndex;
            int leftCount = selectedIndex - 1;
            double top = (finalSize.Height - 500)/2;
            int zIndex = 10000;

            double center = finalSize.Width/2;
            center -= 150;

            for (int leftCounter = 0; leftCounter < selectedIndex; leftCounter++ )
            {
                var left = center - ((selectedIndex - leftCounter) * 80) - 80;
                var finalRect = new Rect(left, top, 300, 500);
                Children[leftCounter].Arrange(finalRect);
                CarouselPanel.SetAngle(Children[leftCounter], -65);
                Panel.SetZIndex(Children[leftCounter], zIndex);
                zIndex++;
            }

            for (int rightCounter = Children.Count-1; rightCounter > selectedIndex; rightCounter--)
            {
                var left = center + ((rightCounter - selectedIndex) * 80) + 80;
                var finalRect = new Rect(left, top, 300, 500);
                Children[rightCounter].Arrange(finalRect);
                CarouselPanel.SetAngle(Children[rightCounter], 65);
                Panel.SetZIndex(Children[rightCounter], zIndex);
                zIndex++;
            }

            Children[selectedIndex].Arrange(new Rect(center, top, 300, 500));
            CarouselPanel.SetAngle(Children[selectedIndex], 0);
            Panel.SetZIndex(Children[selectedIndex], 11000);

            return base.ArrangeOverride(finalSize);
        }

        private ListBox GetListBox()
        {
            return VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(this))) as ListBox;
        }

        public int Angle
        {
            get { return (int)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly DependencyProperty AngleProperty = DependencyProperty.RegisterAttached("Angle", typeof(int), typeof(CarouselPanel), new UIPropertyMetadata(0));
        public static void SetAngle(DependencyObject target, int value) { target.SetValue(CarouselPanel.AngleProperty, value); }
        public static int GetAngle(DependencyObject target) { return (int)target.GetValue(CarouselPanel.AngleProperty); }
    }
}
