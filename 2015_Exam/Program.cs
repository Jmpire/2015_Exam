using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Exam
{
    class Program
    {
        class Warehouse
        {
            public string name;
            List<Product> products;
            public Warehouse(string nName)
            {
                this.name = nName;
                products = new List<Product>();
            }
            // Add new products
            public void Add(Product p)
            {
                products.Add(p);
            }
            // Remove product
            public void Remove(int pos)
            {
                products.RemoveAt(pos);
            }
            public double Total() // a
            {
                double sum = 0;
                foreach (Product product in products)
                {
                    sum += product.GetPrice();
                }
                return sum;
            }
            public List<string> Find(double amount) // b
            {
                List<string> x = new List<string>();
                foreach(Product product in products)
                {
                    if(product.GetPrice() > amount)
                    {
                        x.Add(product.name);
                    }
                }
                return x;
            }
            public List<string> By_Country(string country, ImportedP p)
            {
                List<string> nproducts = new List<string>();
                foreach(Product product in products)
                {
                    if(product is ImportedP && p.origin.Equals(country))
                    {
                       nproducts.Add(product.name);
                    }
                }
                return nproducts;
            }

            
        }
        abstract class Product
        {
            private int code;
            public string name;
            protected double cost;
            public int amount;

            public int getCode()
            {
                return code;
            }
            public Product(int nCode, string nName, double nCost, int nAmount)
            {
                this.code = nCode;
                this.name = nName;
                this.cost = nCost;
                this.amount = nAmount;
            }
            public abstract double GetPrice();
        }
        class DomesticP: Product
        {
            public string producer;
            public DomesticP(int nCode, string nName, double nCost, int nAmount, string nProducer):
                base(nCode, nName, nCost, nAmount)
            {
                this.producer = nProducer;
            }
            public override double GetPrice()
            {
                return cost + (cost * 0.01);
            }
        }
        class ImportedP: Product
        {
            public string origin;
            public ImportedP(int nCode, string nName, double nCost, int nAmount, string nOrigin) :
                base(nCode, nName, nCost, nAmount)
            {
                this.origin = nOrigin;
            }
            public override double GetPrice()
            {
                return cost + (cost * 0.05);
            }
        }
        static void ShiftLeft()
        {
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(3);
            int first;
            first = numbers[0];
            numbers.Remove(first);
            numbers.Add(first);
           
        }
        static void Main(string[] args)
        {

        }
    }
}