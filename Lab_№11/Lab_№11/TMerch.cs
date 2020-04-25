using System;

namespace Lab__11
{
    public class TMerch: IComparable
    {
        protected TMoney price;
        static Random rnd = new Random();

        public TMoney Price { get => price; set { price = value; } }

        public TMerch()
        {
            price = new TMoney();
        }

        public TMerch(int rub, int kop)
        {
            price = new TMoney(rub,kop);
        }

        public TMerch(TMoney money)
        {
            price = money;
        }

        public TMerch(Random r)
        {
            price = new TMoney(rnd.Next(1, 10000) + "," + rnd.Next(1, 100));
        }

        public void SetPrice(int rub, int kop)
        {
            price = new TMoney(rub, kop);
        }

        public int CompareTo(object obj)
        {
            TMerch objPrice = (TMerch)obj;

            if(price > objPrice.price)
            {
                return 1;
            }else if (price < objPrice.price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        virtual public string Show()
        {
            return "TMerch:\n Стоимость: " + Price.ToString() + "\n";
        }

        public override string ToString()
        {
            return "TMerch:\n Стоимость: " + Price.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            TMerch product = (TMerch)obj;

            if (product.Price == Price)
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
