using System;

namespace Lab__11
{
    public class TToy: TMerch
    {
        protected string country;
        static Random rnd = new Random();
        string[] countryNames = { "Россия", "Китай", "Франция", "Италия", "Япония" };

        public TMerch GetBaseMerch
        {
            get
            {
                return new TMerch(price);
            }
        }

        public TToy(Random r):base(r)
        {
            country = countryNames[rnd.Next(0, countryNames.Length - 1)];
        }

        public TToy(TToy obj) : base()
        {
            Country = obj.Country;
            Price = obj.Price;
        }

        public string Country { get => country; set { country = value; } }

        public TToy() : base()
        {
            country = "UnComman";
        }

        public TToy(string country, int rub, int kop) : base(rub, kop)
        {
            Country = country;
        }

        public override string Show()
        {
            return "TToy:\n Страна: " + Country + "\n Стоимость: " + price.ToString() + "\n";
        }

        public override string ToString()
        {
            return "TToy:\n Страна: " + Country + "\n Стоимость: " + price.ToString() + "\n";
        }


        public override bool Equals(object obj)
        {
            TToy product = (TToy)obj;

            if (country.ToLower().Equals(product.country.ToLower())  && product.Price == Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
