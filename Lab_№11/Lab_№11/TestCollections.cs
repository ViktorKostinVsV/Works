using System;
using System.Collections.Generic;

namespace Lab__11
{
    public class TestCollections
    {
        public List<TMerch> list = new List<TMerch>();
        public List<string> listString = new List<string>();
        public SortedDictionary<TMerch, TToy> dict = new SortedDictionary<TMerch, TToy>();
        public SortedDictionary<String, TToy> dictString = new SortedDictionary<String, TToy>();

        static Random rnd = new Random();

        public TToy first;
        public TToy midle;
        public TToy last;
        public TToy emty = new TToy("Страна",0,0);

        // Создает словарь и лист из size элементов.
        public TestCollections(int size)
        {
            for (int i = 0; i < size; i++)
            {
                TToy toy = new TToy(rnd);

                if (i == 0)
                {
                    first =  new TToy(toy);
                    Console.WriteLine("Первый элемент: "+first);
                }
                else if (i == size / 2)
                {
                    midle = new TToy(toy);
                    Console.WriteLine("Средний элемент: "+midle);
                }
                else if (i == size - 1)
                {
                    last = new TToy(toy);
                    Console.WriteLine("Последний элемент: "+last);

                    Console.WriteLine("Элемент вне коллекции: " + emty);
                }

                try
                {
                    list.Add(toy.GetBaseMerch);
                    listString.Add(toy.GetBaseMerch.ToString());
                    dict.Add(toy.GetBaseMerch, toy);
                    dictString.Add(toy.GetBaseMerch.ToString(), toy);
                }
                catch
                {

                }
            }

            list.Sort();
        }

        // Выводит элементы словаря.
        public void ShowDict()
        {
            foreach (KeyValuePair<TMerch, TToy> obj in dict)
            {
                Console.WriteLine(obj.Value);
            }
        }

        public void ShowDictString()
        {
            foreach (KeyValuePair<String, TToy> obj in dictString)
            {
                Console.WriteLine(obj.Value);
            }
        }

        // Выводит элементы таблицы.
        public void ShowList()
        {
            foreach (TMerch de in list)
            {
                Console.WriteLine(de);
            }
        }
        public void ShowListString()
        {
            foreach (string de in listString)
            {
                Console.WriteLine(de);
            }
        }
    }
}
