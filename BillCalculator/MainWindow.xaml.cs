using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace BillCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> order;
        private double subtotal = 0;
        private double tax = 0;
        private double taxRate = 0.13;
        private double total = 0;

        public MainWindow()
        {
            InitializeComponent();

            InitializeComboBox();

            order = new ObservableCollection<Product>();

            // Subscribe the NotifyChange EventHandler for CollectionChanged event 
            order.CollectionChanged += NotifyChange;

            // Assign data source to DataGrid
            orderDataGrid.ItemsSource = order;

            // Initialize original number displays on GUI
            infoDisplay.Content = "Row Count: " + order.Count;
            UpdateTotal();
        }

        // Fill the four ComboBoxes with new objects
        private void InitializeComboBox()
        {
            beverageComboBox.ItemsSource = Inventory.GetItemsByCategory("Beverage");
            appetizerComboBox.ItemsSource = Inventory.GetItemsByCategory("Appetizer");
            mainCourseComboBox.ItemsSource = Inventory.GetItemsByCategory("Main Course");
            dessertComboBox.ItemsSource = Inventory.GetItemsByCategory("Dessert");
        }

        // Handle CollectionChanged event for order collection
        private void NotifyChange(object? sender, NotifyCollectionChangedEventArgs? e)
        {
            infoDisplay.Content = e.Action;

            if (e.NewItems != null)
            {
                // Whenever a new item has been added into the collection
                // let the item subscribe ProductPropertyChanged EventHandler
                // Recalculate the number displays
                foreach (Product added in e.NewItems)
                {
                    infoDisplay.Content += " - Added: " + added.Name + " - Row Count: " + order.Count;
                    added.PropertyChanged += ProductPropertyChanged;
                    UpdateTotal();
                }
            }

            // Whenever a old item has been removed from the collection
            // let the item unsubscribe ProductPropertyChanged EventHandler
            // Recalculate the number displays
            if (e.OldItems != null)
            {
                foreach (Product removed in e.OldItems)
                {
                    infoDisplay.Content += " - Removed: " + removed.Name + " - Row Count: " + order.Count;
                    removed.PropertyChanged -= ProductPropertyChanged;
                    UpdateTotal();
                }
            }
        }

        // Whenever the quantity of a product has been modified, recalculate the number displays
        private void ProductPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Quantity")
            {
                UpdateTotal();
            }
        }

        // When selecting a product from ComboBox
        // Increasing the quantity of the product by 1 if the product exists in the collection
        // Otherwise, add the product into the collection
        private void beverageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Product selectedProduct = (Product)comboBox.SelectedItem;

            if (selectedProduct != null)
            {
                Product existingProduct = order.FirstOrDefault(product => product.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    order.Add(selectedProduct);
                }
                beverageComboBox.SelectedIndex = -1;
            }
        }

        // When selecting a product from ComboBox
        // Increasing the quantity of the product by 1 if the product exists in the collection
        // Otherwise, add the product into the collection
        private void appetizerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Product selectedProduct = (Product)comboBox.SelectedItem;

            if (selectedProduct != null)
            {
                Product existingProduct = order.FirstOrDefault(product => product.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    order.Add(selectedProduct);
                }
                appetizerComboBox.SelectedIndex = -1;
            }
        }

        // When selecting a product from ComboBox
        // Increasing the quantity of the product by 1 if the product exists in the collection
        // Otherwise, add the product into the collection
        private void mainCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Product selectedProduct = (Product)comboBox.SelectedItem;

            if (selectedProduct != null)
            {
                Product existingProduct = order.FirstOrDefault(product => product.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    order.Add(selectedProduct);
                }
                mainCourseComboBox.SelectedIndex = -1;
            }
        }

        // When selecting a product from ComboBox
        // Increasing the quantity of the product by 1 if the product exists in the collection
        // Otherwise, add the product into the collection
        private void dessertComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Product selectedProduct = (Product)comboBox.SelectedItem;

            if (selectedProduct != null)
            {
                Product existingProduct = order.FirstOrDefault(product => product.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    order.Add(selectedProduct);
                }
                dessertComboBox.SelectedIndex = -1;
            }
        }

        // Initialize the collection, ComboBoxes and number displays 
        private void ClearBillButton_Click(object sender, RoutedEventArgs e)
        {
            order.Clear();
            InitializeComboBox();
            infoDisplay.Content = "Row Count: " + order.Count;
            subtotal = 0;
            tax = 0;
            total = 0;
            UpdateTotal();
        }

        // Calculate number displays based on all products in the collection
        private void UpdateTotal()
        {
            subtotal = order.Sum(product => product.Price * product.Quantity);
            tax = subtotal * taxRate;
            total = subtotal + tax;

            subtotalTextBlock.Text = subtotal.ToString("C2");
            taxTextBlock.Text = tax.ToString("C2");
            totalTextBlock.Text = total.ToString("C2");
        }

        // Redirect to webpage when user clicks the logo image
        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://www.centennialcollege.ca");
        }
    }
}
