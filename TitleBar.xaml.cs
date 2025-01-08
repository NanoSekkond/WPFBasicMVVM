using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFBasicMVVM
{
    public partial class TitleBarView : UserControl
    {
        private bool _isDragging = false;
        private Point _startMousePosition;

        public TitleBarView()
        {
            InitializeComponent();
        }

        private void DragMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _isDragging = true;
                _startMousePosition = e.GetPosition(this);
                DragButton.CaptureMouse();
            }
        }

        private void DragMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Window parentWindow = Window.GetWindow(this);
                Point currentMousePosition = e.GetPosition(this);
                Vector delta = currentMousePosition - _startMousePosition;

                parentWindow.Left += delta.X;
                parentWindow.Top += delta.Y;
            }
        }

        private void DragMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                DragButton.ReleaseMouseCapture();
            }
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
