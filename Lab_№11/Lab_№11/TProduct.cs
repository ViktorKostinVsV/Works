using System;


namespace Lab__11
{
    public class TProduct: TMerch, ICloneable
    {
        protected double weight;
        static Random rnd = new Random();

        public TMerch GetBaseMerch
        {
            get
            {
                return new TMerch(price);
            }
        }

        public TProduct(Random r) : base(r)
        {
            weight = rnd.Next(1, 10);
        }

        public double Weight
        {
            get => weight;

            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                {
                    weight = 0;
                    Console.WriteLine("Неверное значение");
                }
            }
        }

        public TProduct() : base()
        {
            weight = 0;
        }

        public TProduct(double weight, int rub, int kop) : base(rub, kop)
        {
            Weight = weight;
        }

        public TProduct ShallowCopy() //поверхностное копирование
        {
            return (TProduct)this.MemberwiseClone();
        }

        public object Clone()
        {
            return new TProduct(this.weight,this.price.Rubles,this.price.Kopeks);
        }

        public override string Show()
        {
            return "TProduct:\n Вес: " + Weight + " кг." + "\n Стоимость: " + price.ToString() + "\n";
        }

        public override string ToString()
        {
            return "TProduct:\n Вес: " + Weight + " кг." + "\n Стоимость: " + price.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            TProduct product = (TProduct)obj;

            if(product.weight == weight && product.Price == Price)
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
