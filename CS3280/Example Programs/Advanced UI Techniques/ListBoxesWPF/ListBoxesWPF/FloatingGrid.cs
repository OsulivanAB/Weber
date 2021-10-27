using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ListBoxesWPF
{
    public class FloatingGrid : Grid
    {
        private readonly TranslateTransform _translation = new TranslateTransform();
        private readonly Storyboard _animation = new Storyboard();
        private readonly DoubleAnimation _animateX;
        private readonly DoubleAnimation _animateY;
        private double _lastGoingToX = 0;
        private double _lastGoingToY = 0;

        private static bool _doAnimations = true;
        public static bool DoAnimations
        {
            get { return _doAnimations;}
            set { _doAnimations = value; }
        }

        public FloatingGrid()
        {
            LayoutUpdated += This_LayoutUpdated;
            RenderTransform = _translation;
            _animateX = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(.5)));
            Storyboard.SetTargetProperty(_animateX, new PropertyPath("(0).(1)", new[] { RenderTransformProperty, TranslateTransform.XProperty }));
            _animation.Children.Add(_animateX);
            _animateY = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(.5)));
            Storyboard.SetTargetProperty(_animateY, new PropertyPath("(0).(1)", new[] { RenderTransformProperty, TranslateTransform.YProperty }));
            _animation.Children.Add(_animateY);
        }

        private Visual FindPanel(Visual visual)
        {
            var panel = visual as Panel;
            var item = visual as FloatingGrid;
            if (panel != null && item == null) return panel;
            if (visual != null)
            {
                var parent = (Visual)VisualTreeHelper.GetParent(visual);
                return FindPanel(parent);
            }
            return null;
        }

        private void This_LayoutUpdated(object sender, EventArgs e)
        {
            if (!DoAnimations) return;

            _animation.Stop(this);

            var panel = FindPanel(this);
            if (panel == null) return;

            var comingFromX = _lastGoingToX + _translation.X;
            var comingFromY = _lastGoingToY + _translation.Y;
            //if (comingFromX == 0 && comingFromY == 0) return;

            var transform = (Transform)TransformToAncestor(panel);
            var goingToX = transform.Value.OffsetX - _translation.X;
            _animateX.From = comingFromX - goingToX;
            _lastGoingToX = goingToX;
            var goingToY = transform.Value.OffsetY - _translation.Y;
            _animateY.From = comingFromY - goingToY;
            _lastGoingToY = goingToY;
            if (_animateX.From != 0 || _animateY.From != 0)
                _animation.Begin(this, HandoffBehavior.SnapshotAndReplace, true);
        }
    }
}
