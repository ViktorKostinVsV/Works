using System;

namespace Lab__11
{
    public class TMilkProduct: TProduct
    {

        protected int fatPercentage;
        static Random rnd = new Random();

        public TMerch GetBaseMerch
        {
            get
            {
                return new TMerch(price);
            }
        }

        public TMilkProduct(Random r) : base(r)
        {
            fatPercentage = rnd.Next(1, 20);
        }

        public int FatPercentage
        {
            get => fatPercentage;

            set
            {
                if(value>=0 && value <= 100)
                {
                    fatPercentage = value;
                }
                else
                {
                    fatPercentage = 0;
                    Console.WriteLine("Неверное значение");
                }
            }
        }

        public TMilkProduct(): base()
        {
            FatPercentage = 0;
        }

        public TMilkProduct(int percentage, int weight, int rub, int kop) : base(weight, rub, kop)
        {
            FatPercentage = percentage;
        }

        public override string Show()
        {
            return "TMilkProduct:\n Вес: " + Weight + " кг." + "\n Процент жира: " + FatPercentage + "\n Стоимость: " + price.ToString() + "\n";
        }

        public override string ToString()
        {
            return "TMilkProduct:\n Вес: " + Weight + " кг." + "\n Процент жира: " + FatPercentage + "\n Стоимость: " + price.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            TMilkProduct product = (TMilkProduct)obj;

            if (product.weight == weight && product.Price == Price&&product.fatPercentage == fatPercentage)
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
