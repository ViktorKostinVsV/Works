using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lab__11
{
    class Program
    {
        // Ввод пользователя.
        static int UserChoice(int min, int max)
        {
            bool check;
            int choice;

            do
            {
                check = int.TryParse(Console.ReadLine(), out choice);

                if (!check || choice < min || choice > max)
                {
                    Console.Write("Неверный выбор." +
                        "\nПовторите ввод: ");
                }
            } while (!check || choice < min || choice > max);

            return choice;
        }
        // Ввод пользователя элемента TMoney.
        static TMoney UserChoice()
        {
            bool check = false;

            do
            {
                string input = Console.ReadLine();
                string[] mas = input.Split(',');

                int non;

                if (mas.Length != 2 || !int.TryParse(mas[0], out non) || !int.TryParse(mas[1], out non))
                {
                    Console.Write("Введите стоимость по образцу (Рубли,Копейки): ");
                    check = false;
                }
                else
                {
                    return new TMoney(input);
                }
            } while (!check);

            return null;
        }
        // Создает объект типа TMerch
        static TMerch CreateTMerch()
        {
            TMerch merch = new TMerch();

            Console.Write("Введите стоимость продукта (Рубли,Копейки) : ");
            merch.Price = UserChoice();

            return merch;
        }
        // Создает объект типа TToy
        static TToy CreateTToy()
        {
            TToy toy = new TToy();

            Console.Write("Введите стоимость продукта (Рубли,Копейки) : ");
            toy.Price = UserChoice();
            Console.Write("Введите Страну производителя: ");
            toy.Country = Console.ReadLine();

            return toy;
        }
        // Создает объект типа TMilkProduct
        static TMilkProduct CreateTMilkProduct()
        {
            TMilkProduct milk = new TMilkProduct();

            Console.Write("Введите стоимость продукта (Рубли,Копейки) : ");
            milk.Price = UserChoice();
            Console.Write("Введите вес продукта: ");
            milk.Weight = UserChoice(0, int.MaxValue);
            Console.Write("Введите жирность продукта (от 0% до 100%) : ");
            milk.FatPercentage = UserChoice(0, 100);

            return milk;
        }
        // Создает объект типа TProduct
        static TProduct CreateTProduct()
        {
            TProduct product = new TProduct();

            Console.Write("Введите стоимость продукта (Рубли,Копейки) : ");
            product.Price = UserChoice();
            Console.Write("Введите вес продукта: ");
            product.Weight = UserChoice(0, int.MaxValue);

            return product;
        }
        // Выбор добавляемого предмета.
        static object ChoiceAddElement()
        {
            Console.Write("1. Добавить продукт." +
                    "\n2. Добавить молочный продукт." +
                    "\n3. Добавить игрушку." +
                    "\n4. Добавить мерч." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");

            int choice = UserChoice(0, 4);

            if (choice == 0)
            {
                return null;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        TProduct product = CreateTProduct();
                        return product;
                    case 2:
                        TMilkProduct milk = CreateTMilkProduct();
                        return milk;
                    case 3:
                        TToy toy = CreateTToy();
                        return toy;
                    case 4:
                        TMerch merch = CreateTMerch();
                        return merch;
                    default:
                        return null;
                }
            }
        }

        #region TaskOne
        // Создание заполненой таблицы.
        static Hashtable MakeHashtable()
        {
            TToy toy1 = new TToy("Китай", 900, 50);
            TToy toy2 = new TToy("Иран", 250, 50);
            TProduct product1 = new TProduct(10, 25000, 00);
            TProduct product2 = new TProduct(8, 6000, 00);
            TMilkProduct milkProduct1 = new TMilkProduct(5, 1, 56, 00);
            TMilkProduct milkProduct2 = new TMilkProduct(5, 1, 90, 00);
            TMilkProduct milkProduct3 = new TMilkProduct(5, 1, 48, 00);
            TMilkProduct milkProduct4 = new TMilkProduct(2, 5, 240, 00);

            Hashtable table = new Hashtable();
            table.Add("1", toy1);
            table.Add("2", toy2);
            table.Add("3", product1);
            table.Add("4", product2);
            table.Add("5", milkProduct1);
            table.Add("6", milkProduct2);
            table.Add("7", milkProduct3);
            table.Add("8", milkProduct4);

            return table;
        }
        // Создание клона таблицы.
        static Hashtable MakeHashtable(Hashtable table)
        {
            Hashtable newTable = new Hashtable();

            foreach (DictionaryEntry de in table)
            {
                newTable.Add(de.Key, de.Value);
            }

            return newTable;
        }
        // Вывод элементов таблицы.
        static void ShowHashtable(Hashtable table)
        {
            foreach(DictionaryEntry de in table)
            {
                TMerch merch = (TMerch)de.Value;
                Console.WriteLine("Ключ предмета: " + de.Key + ": " + merch.Show()); ;
            }
        }
        // Добавление элемента в таблицу.
        static void AddElement(Hashtable table)
        {
            Console.Clear();
            object o = ChoiceAddElement();

            if (o != null)
            {
                string keyCode;

                Console.Write("Введите ключ предмета: ");

                do
                {
                    keyCode = Console.ReadLine();
               
                    if (table.ContainsKey(keyCode))
                    {
                        Console.Write("Предмет с таким ключом уже существует." +
                            "Введите другой ключ: ");
                    }
                    else
                    {
                        table.Add(keyCode, o);
                        break;
                    }      
                    
                } while (true);                
            }
        }
        // Удаление элемента из таблицы.
        static void DeleteElement(Hashtable table)
        {
            Console.Write("Введите ключ предмета, который хотите удалить: ");
            string delNumber = Console.ReadLine();
            table.Remove(delNumber);
        }
        // Выбор запроса для первого задания.
        static void StageOne(ref Hashtable table)
        {
            Console.Write("1. Кол-во элементво определенного вида." +
                    "\n2. Удаление элементов определенного вида." +
                    "\n3. Печать элементов определеноого вида." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");

            int choice = UserChoice(0, 3);

            Console.WriteLine();

            if (choice == 0)
            {
                
            }
            else
            {
                switch (choice)
                {
                    case 1:

                        Console.Write("\n1. Кол-во TProduct и производных." +
                    "\n2. Кол-во TMilkProduct." +
                    "\n3. Кол-во TToy." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");

                        int delElement = UserChoice(0, 3);

                        Console.WriteLine();

                        if (delElement == 0)
                        {
                            break;
                        }
                        else
                        {
                            switch (delElement)
                            {
                                case 1:
                                    TProduct product = new TProduct();
                                    int count1 = 0;

                                    foreach (DictionaryEntry de in table)
                                    {
                                        product = de.Value as TProduct;
                                        if (product != null)
                                        {
                                            count1++;
                                        }
                                    }
                                    Console.WriteLine("Кол-во TProduct: " + count1);

                                    break;
                                case 2:
                                    TMilkProduct milk = new TMilkProduct();
                                    int count2 = 0;

                                    foreach (DictionaryEntry de in table)
                                    {
                                        milk = de.Value as TMilkProduct;
                                        if (milk != null)
                                        {
                                            count2++;
                                        }
                                    }
                                    Console.WriteLine("Кол-во TMilkProduct: " + count2);

                                    break;
                                case 3:
                                    TToy toy = new TToy();
                                    int count3 = 0;

                                    foreach (DictionaryEntry de in table)
                                    {
                                        toy = de.Value as TToy;
                                        if (toy != null)
                                        {
                                            count3++;
                                        }
                                    }
                                    Console.WriteLine("Кол-во TToy: " + count3);

                                    break;
                            }
                        }

                        break;
                    case 2:
                        Console.Write("\n1. Удалить TProduct и производные." +
                    "\n2. Удалить TMilkProduct." +
                    "\n3. Удалить TToy." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");

                        int delElement2 = UserChoice(0, 3);

                        Console.WriteLine();

                        Hashtable copyTable = MakeHashtable(table);

                        if (delElement2 == 0)
                        {
                            break;
                        }
                        else
                        {
                            switch (delElement2)
                            {
                                case 1:

                                    TProduct product = new TProduct();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        product = de.Value as TProduct;
                                        if (product != null)
                                        {
                                            copyTable.Remove(de.Key);
                                        }
                                    }
                                    Console.WriteLine("TProduct удалены.");

                                    break;
                                case 2:
                                    TMilkProduct milk = new TMilkProduct();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        milk = de.Value as TMilkProduct;
                                        if (milk != null)
                                        {
                                            copyTable.Remove(de.Key);
                                        }
                                    }
                                    Console.WriteLine("TMilkProduct удалены.");

                                    break;
                                case 3:
                                    TToy toy = new TToy();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        toy = de.Value as TToy;
                                        if (toy != null)
                                        {
                                            copyTable.Remove(de.Key);
                                        }
                                    }
                                    Console.WriteLine("TToy удалены.");

                                    table = copyTable;

                                    break;
                            }
                        }

                        break;
                    case 3:

                        Console.Write("\n1. Печать TProduct и производные." +
                    "\n2. Печать TMilkProduct." +
                    "\n3. Печать TToy." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");

                        int delElement3 = UserChoice(0, 3);

                        Console.WriteLine();

                        if (delElement3 == 0)
                        {
                            break;
                        }
                        else
                        {
                            switch (delElement3)
                            {
                                case 1:
                                    TProduct product = new TProduct();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        product = de.Value as TProduct;
                                        if (product != null)
                                        {
                                            TMerch merch = (TMerch)de.Value;
                                            Console.WriteLine("Ключ предмета: " + de.Key + ": " + merch.Show()); ;
                                        }
                                    }
                                    

                                    break;
                                case 2:
                                    TMilkProduct milk = new TMilkProduct();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        milk = de.Value as TMilkProduct;
                                        if (milk != null)
                                        {
                                            TMerch merch = (TMerch)de.Value;
                                            Console.WriteLine("Ключ предмета: " + de.Key + ": " + merch.Show()); ;
                                        }
                                    }

                                    break;
                                case 3:
                                    TToy toy = new TToy();

                                    foreach (DictionaryEntry de in table)
                                    {
                                        toy = de.Value as TToy;
                                        if (toy != null)
                                        {
                                            TMerch merch = (TMerch)de.Value;
                                            Console.WriteLine("Ключ предмета: " + de.Key + ": " + merch.Show()); ;
                                        }
                                    }

                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        // Задание 1.
        static void TaskOne()
        {
            Hashtable table = MakeHashtable();

            while (true)
            {
                Console.Write("1. Добавить элемент." +
                    "\n2. Удалить элемент." +
                    "\n3. Просмотреть все элементы." +
                    "\n4. Запросы для 1 задания." +
                    "\n5. Поиск элемента." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");
                int choice = UserChoice(0, 5);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            AddElement(table);
                            break;
                        case 2:
                            DeleteElement(table);
                            break;
                        case 3:
                            ShowHashtable(table);
                            break;
                        case 4:
                            StageOne(ref table);
                            break;
                        case 5:
                            SearchObject(ref table);
                            break;
                    }
                }
            }
        }
        // Поиск объекта.
        static void SearchObject(ref Hashtable table)
        {
            TProduct product = new TProduct();

            Console.Write("Введите стоимость продукта (Рубли,Копейки) : ");
            product.Price = UserChoice();

            foreach (DictionaryEntry de in table)
            {
                TMerch merch = (TMerch)de.Value;

                if (merch.Price == product.Price)
                {
                    Console.WriteLine("Ключ предмета: " + de.Key + ": " + merch.Show());
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Такого предмета не существует");
                }
            }
        }
        #endregion

        #region TaskTwo       
        // Создает заполненный словарь.
        static Dictionary<string, TMerch> MakeDictionary()
        {
            TToy toy1 = new TToy("Китай", 900, 50);
            TToy toy2 = new TToy("Иран", 250, 50);
            TProduct product1 = new TProduct(10, 25000, 00);
            TProduct product2 = new TProduct(8, 6000, 00);
            TMilkProduct milkProduct1 = new TMilkProduct(5, 1, 56, 00);
            TMilkProduct milkProduct2 = new TMilkProduct(5, 1, 90, 00);
            TMilkProduct milkProduct3 = new TMilkProduct(5, 1, 48, 00);
            TMilkProduct milkProduct4 = new TMilkProduct(2, 5, 240, 00);

            Dictionary<string, TMerch> table = new Dictionary<string, TMerch>();
            table.Add("1", toy1);
            table.Add("2", toy2);
            table.Add("3", product1);
            table.Add("4", product2);
            table.Add("5", milkProduct1);
            table.Add("6", milkProduct2);
            table.Add("7", milkProduct3);
            table.Add("8", milkProduct4);

            return table;
        }
        // Выводит элементы словаря на экран.
        static void ShowMethod(Dictionary<string, TMerch> table)
        {
            foreach (KeyValuePair<string, TMerch> obj in table)
            {
                Console.WriteLine("Ключ предмета: " + obj.Key + ": " + obj.Value.Show());
            }
            Console.WriteLine("////////////////////////////////////////////////////////////////////\n");
        }
        // Добавляет элемент в словарь.
        static Dictionary<string, TMerch> AddElement(Dictionary<string, TMerch> table)
        {
            TMerch newObj = (TMerch)ChoiceAddElement();

            Console.WriteLine("Введите ключ добавляемого предмета: ");
            string key = Console.ReadLine();

            while (true)
            {
                if (!table.ContainsKey(key))
                {
                    table.Add(key, newObj);
                    return table;
                }
                else
                {
                    Console.Write("Данный ключ уже существует." +
                        "\nВведите другой ключ: ");
                    key = Console.ReadLine();
                }
            }
        }
        // Удаляет элемент из словаря.
        static Dictionary<string, TMerch> DeleteElement(Dictionary<string, TMerch> table)
        {
            Console.Write("Введите ключ удаляемого предмета: ");
            string key = Console.ReadLine();

            if (!table.ContainsKey(key))
            {
                Console.WriteLine("Предмета с таким ключом не существует.");
                Console.ReadLine();
            }
            else
            {
                table.Remove(key);
            }

            return table;
        }
        // Ищет элемент с максимальной стоимостью.
        static void SearchMaxPrice(Dictionary<string, TMerch> table)
        {
            TMerch maxPrice = new TMerch(0, 0);
            string key = null;

            foreach (KeyValuePair<string, TMerch> obj in table)
            {
                if (maxPrice.Price < obj.Value.Price)
                {
                    maxPrice = obj.Value;
                    key = obj.Key;
                }
            }

            Console.WriteLine("Самый дорогой элемент с ключом: " + key + ": " + table[key].Show());
        }
        // Ищет элемент с минимальной стоимостью.
        static void SearchMinPrice(Dictionary<string, TMerch> table)
        {
            TMerch maxPrice = new TMerch(int.MaxValue, 0);
            string key = null;

            foreach (KeyValuePair<string, TMerch> obj in table)
            {
                if (maxPrice.Price > obj.Value.Price)
                {
                    maxPrice = obj.Value;
                    key = obj.Key;
                }
            }

            Console.WriteLine("Самый дорогой элемент с ключом: " + key + ": " + table[key].Show());
        }
        // Печатает выбранные эллементы.
        static void PrintElements(Dictionary<string, TMerch> table)
        {
            Console.Write("1. Кол-во TProduct и производных." +
                    "\n2. Кол-во TMilkProduct." +
                    "\n3. Кол-во TToy." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");
            int delElement = UserChoice(0, 3);
            Console.WriteLine();

            if (delElement == 0)
            {
                return;
            }
            else
            {
                switch (delElement)
                {
                    case 1:
                        TProduct product = new TProduct();
                        int count1 = 0;

                        foreach (KeyValuePair<string, TMerch> obj in table)
                        {
                            product = obj.Value as TProduct;
                            if (product != null)
                            {
                                count1++;
                            }
                        }
                        Console.WriteLine("Кол-во TProduct: " + count1);

                        break;
                    case 2:
                        TMilkProduct milk = new TMilkProduct();
                        int count2 = 0;

                        foreach (KeyValuePair<string, TMerch> obj in table)
                        {
                            milk = obj.Value as TMilkProduct;
                            if (milk != null)
                            {
                                count2++;
                            }
                        }
                        Console.WriteLine("Кол-во TMilkProduct: " + count2);

                        break;
                    case 3:
                        TToy toy = new TToy();
                        int count3 = 0;

                        foreach (KeyValuePair<string, TMerch> obj in table)
                        {
                            toy = obj.Value as TToy;
                            if (toy != null)
                            {
                                count3++;
                            }
                        }
                        Console.WriteLine("Кол-во TToy: " + count3);

                        break;
                }
            }
        }
        // Выбор запроса для второго задания.
        static void StageTwo(Dictionary<string, TMerch> table)
        {
            Console.Write("1. Найти самый дорогой элемент." +
                        "\n2. Найти самый дешовый элемент." +
                        "\n3. Печать элементов определенного вида." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
            int choice = UserChoice(0, 3);
            Console.WriteLine();

            if (choice == 0)
            {
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        SearchMaxPrice(table);
                        Console.ReadLine();
                        break;
                    case 2:
                        SearchMinPrice(table);
                        Console.ReadLine();
                        break;
                    case 3:
                        PrintElements(table);
                        Console.ReadLine();
                        break;
                }
            }
        }
        // Сортирует словарь.
        static Dictionary<string, TMerch> SortDictionary(Dictionary<string, TMerch> table)
        {
            var newTable = table.OrderBy(o => o.Key);
            table = new Dictionary<string, TMerch>(newTable);
            return table;
        }
        // Ищет элемент в словаре.
        static void SearchElement(Dictionary<string, TMerch> table)
        {
            table = SortDictionary(table);

            Console.WriteLine("Введите ключ искомого предмета: ");
            string key = Console.ReadLine();

            if (!table.ContainsKey(key))
            {
                Console.WriteLine("Предмета с таким ключом не существует.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ключ предмета: " + key + ": " + table[key].Show());
                Console.ReadLine();
            }
        }
        // Задание 2.
        static void TaskTwo()
        {
            Dictionary<string, TMerch> table = MakeDictionary();

            while (true)
            {
                ShowMethod(table);

                Console.Write("1. Добавить элемент." +
                        "\n2. Удалить элемент." +
                        "\n3. Запросы для 2 задания." +
                        "\n4. Поиск элемента." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 4);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            table = AddElement(table);
                            break;
                        case 2:
                            table = DeleteElement(table);
                            break;
                        case 3:
                            StageTwo(table);
                            break;
                        case 4:
                            SearchElement(table);
                            break;
                    }

                    Console.Clear();
                }
            }
        }

        #endregion

        #region TaskThree

        // Измеряет время поиска.
        static void CheckTime(TestCollections test)
        {
            Stopwatch stopwatch = new Stopwatch();
            long testList, testDict;

            #region Сравнение List<TKey> и List<String>
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("Сравнение List<TKey> и List<String>");
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine("List<TKey>: " + test.list.Contains(test.first.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<String>: " + test.listString.Contains(test.first.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска первого элемента в List<TKey>: " + testList
                + "\nВремя поиска первого элемента в List<String>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<TKey>: " + test.list.Contains(test.midle.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<String>: " + test.listString.Contains(test.midle.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска среднего элемента в List<TKey>: " + testList
                + "\nВремя поиска среднего элемента в List<String>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<TKey>: " + test.list.Contains(test.last.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<String>: " + test.listString.Contains(test.last.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска последнего элемента в List<TKey>: " + testList
                + "\nВремя поиска последнего элемента в List<String>: " + testDict);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<TKey>: " + test.list.Contains(test.emty.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("List<String>: " + test.listString.Contains(test.emty.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска элемента вне коллекции List<TKey>: " + testList
                + "\nВремя поиска последнего вне коллекции List<String>: " + testDict);
            Console.WriteLine();
            #endregion

            #region Сравнение SortedDictionary<TKey, TValue>:  и SortedDictionary<String, TValue> по ключу
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("Сравнение SortedDictionary<TKey, TValue>:  и SortedDictionary<String, TValue> по ключу");
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsKey(test.first.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsKey(test.first.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска первого элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска первого элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsKey(test.midle.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsKey(test.midle.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска среднего элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска среднего элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsKey(test.last.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsKey(test.last.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска последнего элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска последнего элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsKey(test.emty.GetBaseMerch));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsKey(test.emty.GetBaseMerch.ToString()));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска элемента вне коллекции SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска элемента вне коллекции SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();
            #endregion

            #region Сравнение SortedDictionary<TKey, TValue>:  и SortedDictionary<String, TValue> по значению
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine("Сравнение SortedDictionary<TKey, TValue>:  и SortedDictionary<String, TValue> по значению");
            Console.WriteLine("///////////////////////////////////////////////////////");
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsValue(test.first));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsValue(test.first));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска первого элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска первого элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsValue(test.midle));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsValue(test.midle));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска среднего элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска среднего элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();


            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsValue(test.last));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsValue(test.last));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска последнего элемента в SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска последнего элемента в SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<TKey, TValue>: " + test.dict.ContainsValue(test.emty));
            stopwatch.Stop();
            testList = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("SortedDictionary<String, TValue>: " + test.dictString.ContainsValue(test.emty));
            stopwatch.Stop();
            testDict = stopwatch.ElapsedTicks;
            Console.WriteLine();


            Console.WriteLine("Время поиска элемента вне коллекции SortedDictionary<TKey, TValue>: " + testList
                + "\nВремя поиска элемента вне коллекции SortedDictionary<String, TValue>: " + testDict);
            Console.WriteLine();
            #endregion
        }

        #region List<String>
        // Добавляет элемент в List<String>
        static TestCollections AddElementListString(TestCollections test)
        {         
            Console.Clear();

            TToy o = CreateTToy();

            if (test.listString.Contains(o.GetBaseMerch.ToString()))
            {
                Console.Write("Предмет с таким ключом уже существует." +
                    "Введите другой ключ: ");
            }
            else
            {
                Console.WriteLine("Предмет добавлен");
                test.listString.Add(o.GetBaseMerch.ToString());
            }

            return test;
        }
        // Удаляет элемт из List<String>
        static TestCollections DeleteElementListString(TestCollections test)
        {

            Console.Write("Введите стоимость предмета, который хотите удалить (руб,коп): ");
            TMerch merch = new TMerch(UserChoice());
            if (test.listString.Contains(merch.ToString()))
            {
                Console.WriteLine("Предмет удален.");
                test.listString.Remove(merch.ToString());
            }
            else
            {
                Console.WriteLine("Предмета не существует.");
            }

            return test;
        }
        // Работа с List<String>
        static void WorkWithListString(TestCollections test)
        {
            while (true)
            {

                Console.Write("1. Добавить элемент." +
                        "\n2. Удалить элемент." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 2);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            test = AddElementListString(test);
                            break;
                        case 2:
                            test = DeleteElementListString(test);
                            break;
                    }
                }
            }
        }
        #endregion

        #region List<TKey>
        // Добавляет элемент в List<TKey>
        static TestCollections AddElementListTKey(TestCollections test)
        {
            Console.Clear();
            TMerch o = (TMerch)ChoiceAddElement();

            if (o != null)
            {
                
                if (test.list.Contains(o))
                {
                    Console.Write("Предмет с такой ценой уже существует.");
                }
                else
                {
                    Console.WriteLine("Предмет добавлен");
                    test.list.Add(o);
                }

            }

            return test;
        }
        // Удаляет элемт из List<TKey>
        static TestCollections DeleteElementListTKey(TestCollections test)
        {
            Console.Write("Введите стоимость предмета, который хотите удалить (руб,коп): ");
            TMerch merch = new TMerch(UserChoice());
            if (test.list.Contains(merch))
            {
                Console.WriteLine("Предмет удален.");
                test.list.Remove(merch);
            }
            else
            {
                Console.WriteLine("Предмета не существует.");
            }

            return test;
        }
        // Работа с List<TKey>
        static void WorkWithListTKey(TestCollections test)
        {
            while (true)
            {

                Console.Write("1. Добавить элемент." +
                        "\n2. Удалить элемент." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 2);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            test = AddElementListTKey(test);
                            break;
                        case 2:
                            test = DeleteElementListTKey(test);
                            break;
                    }
                }
            }
        }
        #endregion

        #region SortedDictionary<String, TValue>
        // Добавляет элемент в SortedDictionary<String, TValue>
        static TestCollections AddElementSortString(TestCollections test)
        {
            Console.Clear();
            TToy o = CreateTToy();

            if (o != null)
            {           
                if (test.dictString.ContainsKey(o.GetBaseMerch.ToString()))
                {
                    Console.WriteLine("Предмет с такой ценой уже существует.");
                }
                else
                {
                    Console.WriteLine("Предмет добавлен");
                    test.dictString.Add(o.GetBaseMerch.ToString(), o);
                }
            }

            return test;
        }
        // Удаляет элемт из SortedDictionary<String, TValue>
        static TestCollections DeleteElementSortString(TestCollections test)
        {
            Console.Write("Введите стоимость предмета, который хотите удалить (руб,коп): ");
            TMerch merch = new TMerch(UserChoice());
            if (test.dictString.ContainsKey(merch.ToString()))
            {
                Console.WriteLine("Предмет удален.");
                test.dictString.Remove(merch.ToString());
            }
            else
            {
                Console.WriteLine("Предмета не существует.");
            }

            return test;
        }
        // Работа с SortedDictionary<String, TValue>
        static void WorkWithSortString(TestCollections test)
        {
            while (true)
            {

                Console.Write("1. Добавить элемент." +
                        "\n2. Удалить элемент." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 2);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            test = AddElementSortString(test);
                            break;
                        case 2:
                            test = DeleteElementSortString(test);
                            break;
                    }
                }
            }
        }
        #endregion

        #region SortedDictionary<TKey, TValue>
        // Добавляет элемент в SortedDictionary<String, TValue>
        static TestCollections AddElementSortTKey(TestCollections test)
        {
            Console.Clear();
            TToy o = CreateTToy();

            if (o != null)
            {
                if (test.dict.ContainsKey(o.GetBaseMerch))
                {
                    Console.WriteLine("Предмет с такой ценой уже существует.");
                }
                else
                {
                    Console.WriteLine("Предмет добавлен");
                    test.dict.Add(o.GetBaseMerch, o);
                }
            }

            return test;
        }
        // Удаляет элемт из SortedDictionary<String, TValue>
        static TestCollections DeleteElementSortTKey(TestCollections test)
        {
            Console.Write("Введите стоимость предмета, который хотите удалить (руб,коп): ");
            TMerch merch = new TMerch(UserChoice());
            if (test.dict.ContainsKey(merch))
            {
                Console.WriteLine("Предмет удален.");
                test.dict.Remove(merch);
            }
            else
            {
                Console.WriteLine("Предмета не существует.");
            }
            
            return test;
        }
        // Работа с SortedDictionary<String, TValue>
        static void WorkWithSortTKey(TestCollections test)
        {
            while (true)
            {

                Console.Write("1. Добавить элемент." +
                        "\n2. Удалить элемент." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 2);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            test = AddElementSortTKey(test);
                            break;
                        case 2:
                            test = DeleteElementSortTKey(test);
                            break;
                    }
                }
            }
        }
        #endregion

        //Печать коллекцй.
        static void PrintCollections(TestCollections test)
        {
            while (true)
            {
                Console.Write("1. Вывести List<String>" +
                    "\n2. Вывести List<TKey>" +
                    "\n3. Вывести SortedDictionary<String, TValue>" +
                    "\n4. Вывести SortedDictionary<TKey, TValue>" +
                    "\n0. Выход." +
                    "\nВыберите действие: ");
                int choice = UserChoice(0, 3);
                Console.Clear();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            test.ShowListString();
                            break;
                        case 2:
                            test.ShowList();
                            break;
                        case 3:
                            test.ShowDictString();
                            break;
                        case 4:
                            test.ShowDict();
                            break;
                    }
                }
            }
        }


        // Задание 3.
        static void TaskThree()
        {
            Console.Write("Введите кол-во элементов в коллекциях: ");
            int user = UserChoice(0, int.MaxValue);

            TestCollections test = new TestCollections(user);

            while (true)
            {              
                Console.Write("1. Измерить время поиска элементов." +
                        "\n2. Работа с List<String>." +
                        "\n3. Работа с List<TKey>." +
                        "\n4. Работа с List<String, TValue>." +
                        "\n5. Работа с List<TKey, TValue>" +
                        "\n6. Печать коллекций." +
                        "\n0. Выход." +
                        "\nВыберите действие: ");
                int choice = UserChoice(0, 6);
                Console.WriteLine();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            CheckTime(test);
                            Console.WriteLine("Продолжить...");
                            Console.ReadLine();
                            break;
                        case 2:
                            WorkWithListString(test);
                            break;
                        case 3:
                            WorkWithListTKey(test);
                            break;
                        case 4:
                            WorkWithSortString(test);
                            break;
                        case 5:
                            WorkWithSortTKey(test);
                            break;
                        case 6:
                            PrintCollections(test);
                            break;
                    }                    
                    Console.Clear();
                }

            }          
        }
        #endregion

        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("1. Заданиe 1." +
                    "\n2. Задание 2." +
                    "\n3. Задание 3." +
                    "\n0. Выход." +
                    "\nВыберите действие: ");
                int choice = UserChoice(0, 3);
                Console.Clear();

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            TaskOne();
                            break;
                        case 2:
                            TaskTwo();
                            break;
                        case 3:
                            TaskThree();
                            break;
                    }
                }
            }           
        }
    } 
}
