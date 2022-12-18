using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Lb3_prog_2
{
    internal abstract class Vehicle : INotifyPropertyChanged
    {
        protected double costRatio = 0;
        protected double startCost = 0;
        protected List<Product.CategoryConteiner> Categories { get; private protected set; }
        protected bool isCanSelect;
        public bool IsCanSelect
        {
            get { return isCanSelect; }
            set
            {
                isCanSelect = value;
                OnPropertyChanged();
            }
        }
        public string TypeName { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public double CalculateCost(double weight)
        {
            return costRatio * weight + startCost;
        }

        public bool IsCanCarry(List<Product.CategoryConteiner> categoties)
        {
            foreach (var item in categoties)
            {
                if (!Categories.Contains(item)) return false;
            }
            return true;
        }

        public void SendByRoute(Order order)
        {
            string json = JsonSerializer.Serialize(order);
            File.AppendAllText($"d:\\h.json", json + "\n");
        }
    }
}
