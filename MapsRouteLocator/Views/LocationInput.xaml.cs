using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapsRouteLocator.Views
{
    /// <summary>
    /// Interaction logic for LocationInput.xaml
    /// </summary>
    public partial class LocationInput : UserControl
    {
        public LocationInput()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title), 
                typeof(string),
                typeof(LocationInput),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback( OnTitleChanged)
                )
            );

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
                
            }
        }

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LocationInput li = d as LocationInput;
            li.PrefixLabel.Content = (string)e.NewValue;
        }

        public static readonly DependencyProperty RemoveButtonVisibleProperty =
            DependencyProperty.Register(
                "RemoveButtonVisible",
                typeof(bool),
                typeof(LocationInput),
                new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnRemoveButtonVisibleChanged))
            );

        public bool RemoveButtonVisible
        {
            get { return (bool)GetValue(RemoveButtonVisibleProperty); }
            set
            {
                SetValue(RemoveButtonVisibleProperty, value);

            }
        }

        private static void OnRemoveButtonVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LocationInput li = d as LocationInput;
            li.RemoveButton.Visibility = (bool)e.NewValue ? System.Windows.Visibility.Visible : Visibility.Hidden;
        }
    }
}
