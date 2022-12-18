using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lb3_prog_2
{
    class InformationSystem : INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;
        public ReadOnlyObservableCollection<Product> Products { get; }
        private ObservableCollection<ProductsConteiner> selectedProducts;
        public ReadOnlyObservableCollection<ProductsConteiner> SelectedProducts { get; }
        private ObservableCollection<Order> orders;
        public ReadOnlyObservableCollection<Order> Orders { get; }
        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                if (selectedOrder != null)
                    foreach (var v in vehicles)
                    {
                        v.IsCanSelect = v.IsCanCarry(SelectedOrder.Categories.ToList());
                    }
                CheckSelected();
                OnPropertyChanged();
            }
        }
        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                selectedVehicle = value;
                CheckSelected();
                OnPropertyChanged();
            }
        }

        private void CheckSelected()
        {
            if (SelectedVehicle != null && SelectedOrder != null && SelectedVehicle.IsCanSelect)
            {
                OfferCost = SelectedVehicle.CalculateCost(SelectedOrder.Weight);
                IsSelected = true;
            }
            else
            {
                OfferCost = 0;
                IsSelected = false;
            }
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Vehicle> vehicles;
        public ReadOnlyObservableCollection<Vehicle> Vehicles { get; }
        private double offerCost = 0;
        public double OfferCost
        {
            get { return offerCost; }
            set
            {
                offerCost = value;
                OnPropertyChanged();
            }
        }

        public static List<Product.CategoryConteiner> CategoriesList { get; private set; }
        public List<string> Cities { get; }

        public InformationSystem()
        {
            CategoriesList = new List<Product.CategoryConteiner>()
            {
                new Product.CategoryConteiner("1", "aaaaaa"),
                new Product.CategoryConteiner("2", "bbbbbb"),
                new Product.CategoryConteiner("3", "cccccc"),
                new Product.CategoryConteiner("4", "dddddd")
            };
            Factory cFactory = new CarFactory();
            Factory tFactory = new TrainFactory();
            Factory pFactory = new PlaneFactory();
            vehicles = new ObservableCollection<Vehicle>()
            {
                cFactory.CreateVehicle(),
                tFactory.CreateVehicle(),
                pFactory.CreateVehicle(),
            };
            Vehicles = new ReadOnlyObservableCollection<Vehicle>(vehicles);
            products = new ObservableCollection<Product>()
            { new Product("Продукт 1", 100, CategoriesList[0]), new Product("Продукт 2", 200, CategoriesList[3]),
            new Product("Продукт 3", 50, CategoriesList[2])
            };
            Products = new ReadOnlyObservableCollection<Product>(products);
            selectedProducts = new ObservableCollection<ProductsConteiner>();
            SelectedProducts = new ReadOnlyObservableCollection<ProductsConteiner>(selectedProducts);
            orders = new ObservableCollection<Order>();
            Orders = new ReadOnlyObservableCollection<Order>(orders);
            SelectedOrder = null;
            Cities = new List<string>()
            {
                "Москва", "Томск", "Тюмень", "Новосибирск", "Питер"
            };
        }

        private Command addToSelectedCommand;
        public Command AddToSelectedCommand
        {
            get
            {
                return addToSelectedCommand ??
                    (addToSelectedCommand = new Command(obj =>
                    {
                        var conts = selectedProducts.Where(s => s.Product.Name.Equals((string)obj));
                        if (conts.Count() > 0)
                        {
                            var cont = conts.First();
                            cont.Count += 1;
                        }
                        else
                            selectedProducts.Add(new ProductsConteiner(products.Where(p => p.Name.Equals((string)obj)).First(), 1));
                    }));
            }
        }

        private Command removeFromSelectedCommand;
        public Command RemoveFromSelectedCommand
        {
            get
            {
                return removeFromSelectedCommand ??
                    (removeFromSelectedCommand = new Command(obj =>
                    {
                        var conts = selectedProducts.Where(s => s.Product.Name.Equals((string)obj));
                        if (conts.Count() > 0)
                        {
                            var cont = conts.First();
                            if (cont.Count == 1)
                                selectedProducts.Remove(cont);
                            else
                                cont.Count -= 1;
                        }
                    }));
            }
        }

        private Command createOrderCommand;
        public Command CreateOrderCommand
        {
            get
            {
                return createOrderCommand ??
                    (createOrderCommand = new Command(obj =>
                    {
                        if (selectedProducts.Count > 0)
                        {
                            orders.Add(new Order(SelectedProducts.ToList(), (string)obj));
                        }
                    }));
            }
        }

        private Command sendOrderCommand;
        public Command SendOrderCommand
        {
            get
            {
                return sendOrderCommand ??
                    (sendOrderCommand = new Command(obj =>
                    {
                        SelectedVehicle.SendByRoute(SelectedOrder);
                        orders.Remove(SelectedOrder);
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
