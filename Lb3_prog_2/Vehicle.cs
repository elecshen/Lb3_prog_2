using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal abstract class Vehicle : INotifyPropertyChanged
    {
        protected static double distRatio = 0;
        protected static double startCost = 0;
        public double CurrentLoad { get; }
        public double LoadCapacity { get; }
        private ObservableCollection<Product> cargo;
        public ReadOnlyObservableCollection<Product> Cargo;

        public event PropertyChangedEventHandler PropertyChanged;

        public static double CalculateCost(double distance, double weight)
        {
            return distRatio * distance * weight + startCost;
        }

        public void AddCargo(Product product)
        {
            cargo.Add(product);
        }

        public void RemuveCargo(int id)
        {
            cargo.RemoveAt(id);
        }

        public abstract void/*waybill*/ SendByRoute(/*cargo*/);
    }
}
