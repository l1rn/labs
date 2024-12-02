using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab55
{
    internal class Flat
    {
        protected long personalAccount;
        protected double squareFlat;
        protected int quantityResidents;
        protected double squarePrice;
        protected double quantityResidentsPrice;
        public Flat(long PersonalAccount, double SquareFlat,
            int QuanrityResidents, double SquarePrice, double QuanityResidentsPrice)
        {
            this.personalAccount = PersonalAccount;
            this.squareFlat = SquareFlat;
            this.quantityResidents = QuanrityResidents;
            this.squarePrice = SquarePrice;
            this.quantityResidentsPrice = QuanityResidentsPrice;
        }

        public long GetPersonalAccount()
        {
            return personalAccount;
        }
        public virtual void PrintAllInfo()
        {
            Console.WriteLine($"Лицевой счёт: " + personalAccount);
            Console.WriteLine($"Площадь квартиры: " + squareFlat + " кв.м.");
            Console.WriteLine($"Количество проживающих: " + quantityResidents);
            Console.WriteLine($"Оплата за площадь: " + squarePrice + " руб.");
            Console.WriteLine($"Оплата за количество проживающих: " + quantityResidentsPrice + " руб.");
        }

        internal class GovernmentFlat : Flat
        {
            private double allRentPrice;
            public GovernmentFlat(long PersonalAccount, double SquareFlat,
            int QuanrityResidents, double SquarePrice, double QuanityResidentsPrice, double AllRentPrice) 
                : base(PersonalAccount, SquareFlat,
            QuanrityResidents, SquarePrice, QuanityResidentsPrice)
            {
                allRentPrice = AllRentPrice;
            }
            

            public override void PrintAllInfo()
            {
                base.PrintAllInfo();
                Console.WriteLine("Общая плата за найм: " + allRentPrice + " руб.");
            }
        }

        internal class PrivatizeFlat : Flat
        {
            private double priceRepairFlat;
            private double allPriceFlat;

            public PrivatizeFlat(long PersonalAccount, double SquareFlat,
            int QuanrityResidents, double SquarePrice, double QuanityResidentsPrice, double PriceRepairFlat)
            : base (PersonalAccount, SquareFlat, QuanrityResidents, SquarePrice, QuanrityResidents)
            {
                this.priceRepairFlat = PriceRepairFlat;
                allPriceFlat = priceRepairFlat + quantityResidentsPrice + squarePrice;
            }

            public override void PrintAllInfo()
            {

                base.PrintAllInfo();
                Console.WriteLine("Плата за кап. ремонт: " + priceRepairFlat + " руб.");
                Console.WriteLine("Общая плата за квартиру: " + allPriceFlat + " руб.");
            }
        }



    }
    
}
