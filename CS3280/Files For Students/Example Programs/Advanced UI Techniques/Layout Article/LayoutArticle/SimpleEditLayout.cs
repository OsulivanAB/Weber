using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace LayoutArticle
{
    public class SimpleEditLayout : Panel
    {
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }
        public static readonly DependencyProperty VerticalSpacingProperty = DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(SimpleEditLayout), new UIPropertyMetadata(5d));


        public SimpleEditLayout()
        {
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
        }

        /// <summary>
        /// Provides the behavior for the Measure pass of Silverlight layout. Classes can override this method to define their own Measure pass behavior.
        /// </summary>
        /// <param name="availableSize">The available size that this object can give to child objects. Infinity can be specified as a value to indicate that the object will size to whatever content is available.</param>
        /// <returns>
        /// The size that this object determines it needs during layout, based on its calculations of child object allotted sizes.
        /// </returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            // First, we figure out how many columns we have and what the controls are in each column
            List<List<ControlPair>> columns = this.GetColumns();

            // Now we calculate the space needed in each column
            double totalHeight = 0;
            double totalWidth = 0;
            double space = VerticalSpacing;
            bool firstColumn = true;
            var large = new Size(100000, 100000);
            foreach (var column in columns)
            {
                double widestLabel = 0;
                double widestControl = 0;
                double columnHeight = 0;

                foreach (var pair in column)
                {
                    pair.Label.Measure(large);
                    pair.Edit.Measure(large);

                    widestLabel = Math.Max(pair.Label.DesiredSize.Width, widestLabel);
                    widestControl = Math.Max(pair.Edit.DesiredSize.Width, widestControl);
                    columnHeight += Math.Max(pair.Label.DesiredSize.Height, pair.Edit.DesiredSize.Height) + space;
                    if (View.GetGroupBreak(pair.Label) || View.GetGroupBreak(pair.Edit))
                    {
                        pair.NewGroup = true;
                        columnHeight += 15;
                    }
                }

                totalWidth += widestLabel + 15 + widestControl + (firstColumn ? 0 : 30);
                totalHeight = Math.Max(columnHeight, totalHeight);

                firstColumn = false;
            }

            base.MeasureOverride(availableSize);
            return new Size(totalWidth, totalHeight);
        }

        /// <summary>
        /// Provides the behavior for the Arrange pass of Silverlight layout. Classes can override this method to define their own Arrange pass behavior.
        /// </summary>
        /// <param name="finalSize">The final area within the parent that this object should use to arrange itself and its children.</param>
        /// <returns>
        /// The actual size used once the element is arranged.
        /// </returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            List<List<ControlPair>> columns = this.GetColumns();

            double totalHeight = 0;
            double totalWidth = 0;
            double currentY = 0;
            double currentX = 0;
            double space = VerticalSpacing;
            bool firstColumn = true;
            foreach (var column in columns)
            {
                double widestLabel = 0;
                double widestControl = 0;
                double columnHeight = 0;

                // We first need to know the widest elements, since all controls need to be aligned according to those controls
                foreach (var pair in column)
                {
                    widestLabel = Math.Max(pair.Label.DesiredSize.Width, widestLabel);
                    widestControl = Math.Max(pair.Edit.DesiredSize.Width, widestControl);
                }

                // Now we perform the layout for this column
                foreach (var pair in column)
                {
                    if (pair.NewGroup) currentY += 15;

                    pair.Label.Arrange(new Rect(currentX, currentY + 3, widestLabel, pair.Label.DesiredSize.Height));
                    pair.Edit.Arrange(new Rect(currentX + 15 + widestLabel, currentY, widestControl, pair.Edit.DesiredSize.Height));

                    currentY += Math.Max(pair.Label.DesiredSize.Height, pair.Edit.DesiredSize.Height) + space;
                }

                totalWidth += widestLabel + 15 + widestControl + (firstColumn ? 0 : 30);
                totalHeight = Math.Max(columnHeight, totalHeight);
                currentX = totalWidth + 30;
                currentY = 0;

                firstColumn = false;
            }

            base.ArrangeOverride(finalSize);
            return new Size(totalWidth, totalHeight);
        }

        /// <summary>
        /// Iterates over all the controls and returns them in columns and tuples
        /// </summary>
        /// <returns></returns>
        private List<List<ControlPair>> GetColumns()
        {
            var columns = new List<List<ControlPair>>();
            columns.Add(new List<ControlPair>());
            var currentColumn = columns[0];
            for (int controlCounter = 0; controlCounter < this.Children.Count; controlCounter += 2)
            {
                var child = this.Children[controlCounter];
                if (View.GetColumnBreak(child))
                {
                    columns.Add(new List<ControlPair>());
                    currentColumn = columns[columns.Count - 1];
                }

                var tuple = new ControlPair() { Label = child, Edit = this.Children[controlCounter + 1] };
                if (View.GetGroupBreak(tuple.Label) || View.GetGroupBreak(tuple.Edit))
                {
                    tuple.NewGroup = true;
                }
                currentColumn.Add(tuple);
            }
            return columns;
        }
    }

    public class ControlPair
    {
        public UIElement Label { get; set; }
        public UIElement Edit { get; set; }
        public bool NewGroup { get; set; }
    }
}
