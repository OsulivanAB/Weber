using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ListBoxesWPF
{
    public class ScatterPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(new Size(10000, 10000));

            // Creating random positions and scales
            foreach (UIElement child in Children)
            {
                SetAngle(child, Randoms.Angle);
                SetOffsetX(child, Randoms.OffsetX);
                SetOffsetY(child, Randoms.OffsetY);
                SetScale(child, Randoms.Scale);
                child.RenderTransformOrigin = new Point(.5, .5);
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in Children)
            {
                child.Arrange(new Rect(0, 0, child.DesiredSize.Width, child.DesiredSize.Height));

                var group = new TransformGroup();
                group.Children.Add(new RotateTransform(GetAngle(child)));
                group.Children.Add(new ScaleTransform(GetScale(child), GetScale(child)));
                group.Children.Add(new TranslateTransform(GetOffsetX(child), GetOffsetY(child)));
                child.RenderTransform = group;
            }

            return base.ArrangeOverride(finalSize);
        }

        public int Angle
        {
            get { return (int)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly DependencyProperty AngleProperty = DependencyProperty.RegisterAttached("Angle", typeof(int), typeof(ScatterPanel), new UIPropertyMetadata(0));
        public static void SetAngle(DependencyObject target, int value) { target.SetValue(AngleProperty, value); }
        public static int GetAngle(DependencyObject target) { return (int)target.GetValue(AngleProperty); }

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.RegisterAttached("Scale", typeof(double), typeof(ScatterPanel), new UIPropertyMetadata(0d));
        public static void SetScale(DependencyObject target, double value) { target.SetValue(ScaleProperty, value); }
        public static double GetScale(DependencyObject target) { return (double)target.GetValue(ScaleProperty); }

        public double OffsetX
        {
            get { return (double)GetValue(OffsetXProperty); }
            set { SetValue(OffsetXProperty, value); }
        }
        public static readonly DependencyProperty OffsetXProperty = DependencyProperty.RegisterAttached("OffsetX", typeof(double), typeof(ScatterPanel), new UIPropertyMetadata(0d));
        public static void SetOffsetX(DependencyObject target, double value) { target.SetValue(OffsetXProperty, value); }
        public static double GetOffsetX(DependencyObject target) { return (double)target.GetValue(OffsetXProperty); }

        public double OffsetY
        {
            get { return (double)GetValue(OffsetYProperty); }
            set { SetValue(OffsetYProperty, value); }
        }
        public static readonly DependencyProperty OffsetYProperty = DependencyProperty.RegisterAttached("OffsetY", typeof(double), typeof(ScatterPanel), new UIPropertyMetadata(0d));
        public static void SetOffsetY(DependencyObject target, double value) { target.SetValue(OffsetYProperty, value); }
        public static double GetOffsetY(DependencyObject target) { return (double)target.GetValue(OffsetYProperty); }
    }
}
