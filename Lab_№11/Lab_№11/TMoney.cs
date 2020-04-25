using System;

namespace Lab__11
{
    public class TMoney
    {
        /* Тип данных TMoney.
         * 
         * Содержит поля:
         * Целочисленное rublrs - рубли;
         * Целочисленное kopeks - копейки;
         * Статическое целочисленное objectCount - cчетчик новых объектов.
         * 
         * Содержит конструкторы:
         * TMoney() - Содает обЪект с нулевыми значениями;
         * TMoney(int rub, int kop) - Создает обЪект со значениями reb и kop;
         * 
         * Содержит методы:
         * Show - Выводит кол-во созданных объектов;
         * 
         * Перегруженные методы:
         * ToString - Выводит rbles,kopeks.
         * Оператор ++ (Добавляет 1 копейку);
         * Оператор -- (Вычитает 1 копейку)
         * Оператор double (Выводит кол-во копеек)
         * Оператор int (выводит кол-во рублей)
         * Оператор - (Вычитает типы TMoney и int)
         * Оператор - (Вычитает типы int и TMoney)
         * Оператор - (Вычитает типы TMoney и TMoney)
         * Оператор < (Возвращает наименьший тип TMoney) 
         * Оператор > (Возвращает наибольший тип TMoney
         */


        int rubles;                   // Поле рублей
        int kopeks;                   // Поле копеек.
        static int objectCount = 0;   // Счетчик созданных объектов.

        public TMoney()
        {
            rubles = 0;
            kopeks = 0;

            objectCount++;
        }   // Money

        public TMoney(int rub, int kop)
        {
            Rubles = rub;
            Kopeks = kop;

            objectCount++;
        }   // Money

        public TMoney(string money)
        {
            string[] rubKop = money.Split(',');

            Rubles = int.Parse(rubKop[0]);
            Kopeks = int.Parse(rubKop[1]);

            objectCount++;
        }   // Money

        public int Rubles
        {
            get => rubles;
            set
            {
                if (value > 0)
                    rubles = value;
                else
                    rubles = 0;
            }
        }   // Rubles.

        public int Kopeks
        {
            get => kopeks;
            set
            {
                if (value <= 99 && value >= 0)
                {
                    kopeks = value;
                }
                else if (value < 0)
                {
                    if (Rubles >= 1)
                    {
                        Rubles--;
                        kopeks = 100 + value;
                    }
                    else
                    {
                        kopeks = 0;
                    }
                }
                else if (value > 99)
                {
                    rubles = rubles + value / 100;
                    kopeks = value % 100;
                }
            }
        }   // Kopeks.

        public static void Show()
        {
            Console.WriteLine("Создано объектов - " + objectCount);
        }   // Show

        public override string ToString()
        {
            return Rubles + "," + Kopeks + " рублей";
        }   // ToString

        static public TMoney MinusMoneyStatic(TMoney first, TMoney second)
        {
            TMoney newMoney = new TMoney();

            newMoney.Rubles = first.Rubles - second.Rubles;
            if (first.Rubles - second.Rubles >= 1)
            {
                newMoney.Kopeks = first.Kopeks - second.Kopeks;
            }
            else
            {
                newMoney.Kopeks = 0;
            }

            return newMoney;
        }   // MinusMoneyStatic

        public TMoney MinusMoney(TMoney second)
        {
            TMoney newMoney = new TMoney();

            newMoney.Rubles = Rubles - second.Rubles;
            if (Rubles - second.Rubles >= 1)
            {
                newMoney.Kopeks = Kopeks - second.Kopeks;
            }
            else
            {
                newMoney.Kopeks = 0;
            }

            return newMoney;
        }   // MinusMoney

        public void PlusMoney(TMoney second)
        {

            Rubles += second.Rubles;
            Kopeks += second.Kopeks;

        }

        public static TMoney operator ++(TMoney first)
        {
            first.Kopeks++;

            return first;
        }   // operator ++.

        public static TMoney operator --(TMoney first)
        {
            first.Kopeks--;

            return first;
        }   // operator --.

        public static explicit operator double(TMoney first) => double.Parse("0," + first.Kopeks);   // Явное преобразование double

        public static implicit operator int(TMoney first) => first.Rubles;      // Неявное преобразование int

        public static TMoney operator -(TMoney first, int second)
        {
            TMoney newMoney = new TMoney();

            newMoney.Kopeks += second;

            return MinusMoneyStatic(first, newMoney);
        }   // operator - (Money - int)

        public static TMoney operator -(int first, TMoney second)
        {
            TMoney newMoney = new TMoney();

            newMoney.Kopeks += first;

            return MinusMoneyStatic(newMoney, second);
        }   // operator - (int - Money)

        public static TMoney operator -(TMoney first, TMoney second)
        {
            return MinusMoneyStatic(first, second);
        }   // operator - (Money - Money)


        public static bool operator <(TMoney first, TMoney second)
        {
            if (first.Rubles < second.Rubles)
                return true;
            else if (first.Rubles > second.Rubles)
                return false;
            else
            {
                if (first.Kopeks < second.Kopeks)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator >(TMoney first, TMoney second)
        {
            if (first.Rubles > second.Rubles)
                return true;
            else if (first.Rubles < second.Rubles)
                return false;
            else
            {
                if (first.Kopeks > second.Kopeks)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator ==(TMoney first, TMoney second)
        {
            if (first.Rubles == second.Rubles && first.Kopeks == second.Kopeks)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(TMoney first, TMoney second)
        {
            if (first.Rubles == second.Rubles && first.Kopeks == second.Kopeks)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
