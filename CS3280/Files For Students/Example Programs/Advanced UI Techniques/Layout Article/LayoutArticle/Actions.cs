using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace LayoutArticle
{
    public interface IHaveActions
    {
        IEnumerable<IAction> Actions { get; }
    }

    public interface IAction : ICommand
    {
        string Caption { get; set; }
        bool BeginGroup { get; set; }
    }

    public class Action : IAction
    {
        public Action(string caption = "",
                      bool beginGroup = false,
                      Action<IAction, object> execute = null,
                      Func<IAction, object, bool> canExecute = null,
                      string visualResourceKey = "")
        {
            Caption = caption;
            BeginGroup = beginGroup;
            _executeDelegate = execute;
            _canExecuteDelegate = canExecute;
            VisualResourceKey = visualResourceKey;
        }

        public string Caption { get; set; }
        public string VisualResourceKey { get; set; }
        public bool BeginGroup { get; set; }

        public Visual Visual
        {
            get
            {
                try
                {
                    return (Visual)Application.Current.FindResource(VisualResourceKey);
                }
                catch
                {
                    return null;
                }
            }
        }

        Func<IAction, object, bool> _canExecuteDelegate;
        public bool CanExecute(object parameter)
        {
            if (_canExecuteDelegate != null) return _canExecuteDelegate(this, parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged;

        Action<IAction, object> _executeDelegate;
        public void Execute(object parameter)
        {
            if (_executeDelegate != null) _executeDelegate(this, parameter);
        }
    }

    public class ActionGrid : Grid
    {
        public object Model
        {
            get { return (object)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(object), typeof(ActionGrid), new UIPropertyMetadata(null, ModelChanged));
        static void ModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as ActionGrid;
            if (grid != null)
            {
                if (e.NewValue is IHaveActions)
                    grid.Visibility = Visibility.Visible;
                else
                    grid.Visibility = Visibility.Collapsed;
            }
        }
    }
}
