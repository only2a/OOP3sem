﻿using Lab5.Ex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{


    class Printer
    {
        public void IAmPrinting(Pastry obj)
        {
            Console.WriteLine($"Type: {obj.ToString()}");
        }
    }

    abstract class Product
    {
        protected int countOfSelledProducts = 0;

        public override string ToString() => GetType().Name;
        public override int GetHashCode() => countOfSelledProducts;
        public override bool Equals(object obj) => GetType().Name == obj.ToString();
        //public virtual string Company => "Walmart";
    }

    abstract class Goods : Product
    {
        protected float _money = 150.75f;

        public void TopUp(float value)
        {
            if (value < 0) throw new ExForTop("You can not top up negative value", value);
            if (value > 999999) throw new ExForTop("Too much...", value);

            Debug.Assert(value <= 999999, "Mnogo");
            _money += value;
            Console.WriteLine($"----------After receiving {value} dollars -------"); ShowMoney();
        }
        public void ShowMoney()
        {
            Console.WriteLine($"Now you have {_money}$\n");
        }
        public abstract float Price();
        public abstract float Weight();
        public abstract void Buy(int amount = 1);
    }

    class Flowers : Goods
    {
        private float _cost = 2.5f;
        private int _weight = 80;

        public override void Buy(int amount = 1)
        {
            if (_money >= amount * _cost)
            {
                _money -= amount * _cost;
                Console.WriteLine($"----------After buying {amount} Flowers for {_cost}dollars-------"); ShowMoney();
                countOfSelledProducts++;
            }
            else
                throw new ExForBy("You don't have enough money");
        }
        public override float Price() { return _cost; }
        public override float Weight() => _weight;
    }

    class Clocks : Goods
    {
        private float _cost = 149.55f;
        private int _weight = 300;

        public override void Buy(int amount = 1)
        {
            if (_money >= amount * _cost)
            {
                _money -= amount * _cost;
                Console.WriteLine($"----------After buying clocks for {_cost}dollars-------");  ShowMoney();
                countOfSelledProducts++;
            }
            else
                throw new ExForBy("You don't have enough money");
        }

        public override float Price() => _cost;
        public override float Weight() => _weight;
    }

    abstract class Pastry
    {
        public override string ToString() => GetType().Name;
        public abstract void Print();
    }

    sealed class Cake : Pastry, IPastry
    {
        public override void Print()
        {
            Console.WriteLine($"|Abstract|\tType of this object: {ToString()}");
        }

        void IPastry.Print()
        {
            Console.WriteLine($"|Interface|\tType of this object: {ToString()}");
        }
    }

    sealed class Sweets : Pastry, IPastry
    {

        public enum Type
        {
            Roshen = 0,
            Kommunarka,
            Spartak
        }

        public Info[] companies;

        public struct Info
        {
            private float _price;
            private Type _type;

            public float Price
            {
                get => _price;
                set => _price = value;
            }
            public Type Type
            {
                get => _type;
                set => _type = value;
            }
        }

        public Sweets()
        {
            companies = new Info[3];
            companies[0].Type = Type.Roshen;
            companies[0].Price = 1.2f;
            companies[1].Type = Type.Kommunarka;
            companies[1].Price = 0.8f;
            companies[2].Type = Type.Spartak;
            companies[2].Price = 0.7f;
        }

        public override void Print()
        {
            Console.WriteLine($"|Abstract|\tType of this object: {ToString()}");
        }

        void IPastry.Print()
        {
            Console.WriteLine($"|Interface|\tType of this object: {ToString()}");
        }
    }
}
