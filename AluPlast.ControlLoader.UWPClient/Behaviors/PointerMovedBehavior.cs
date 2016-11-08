using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace AluPlast.ControlLoader.UWPClient.Behaviors
{
    public class PointerMovedBehavior : DependencyObject, IBehavior
    {


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(PointerMovedBehavior), new PropertyMetadata(null));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PointerMovedBehavior), new PropertyMetadata(string.Empty));



        public DependencyObject AssociatedObject
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Attach(DependencyObject associatedObject)
        {
            var button = (Button)associatedObject;

            button.PointerMoved += Button_PointerMoved;
        }

        private void Button_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var button = (Button)sender;
            
            button.Background = new SolidColorBrush(Colors.Red);

            Command.Execute(null);
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }
    }
}
