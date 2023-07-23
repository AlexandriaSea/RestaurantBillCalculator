using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LoginUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Store sample user data in the collection
        private ObservableCollection<User> usersRecord = new ObservableCollection<User>(SampleUserData.GetAll());

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            // Link user data collection to the view display
            UsersList.ItemsSource = usersRecord;
        }
    }
}
