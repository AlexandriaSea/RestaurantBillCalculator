using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillCalculator
{
    public class Product : INotifyPropertyChanged
    {
        // Every product will have a initial quantity of 1
        private int _quantity = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        // Whenever the quantity of product has been changed, invoke PropertyChanged EventHandler
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public Product(int id, string name, string category, double prince)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = prince;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
