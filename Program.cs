using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1_3
{
    public class Books
    {

        public void AddBooks(string name, string author, string genre, int Released, int width, int height, string binding_format, string source, string review, string Path)
        {
            //string Path = @"D:\СУБД\lab1\list.txt";
            name.Replace(";", ",");
            author.Replace(";", ",");
            genre.Replace(";", ",");
            review.Replace(";", ",");
            string date = Convert.ToString(DateTime.Now);
            string read_date = Convert.ToString(DateTime.Now);
            string text = "" + name + ";" + author + ";" + genre + ";" + Released + ";" + width + ";" + height + ";" + binding_format + ";" + source + ";" + date + ";" + read_date + ";" + review;
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string ReadBooks(string Path)
        {
            
            string line = "";
            /*using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
            {                
                line = sr.ReadToEnd();                              
            }*/
            using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
            {
                string ln;
                while ((ln = sr.ReadLine()) != null)
                {
                    line += ln + "\n";
                }
            }
            return line;
        }
        public void PrintBooks(string Path)
        {
            
            string line = ReadBooks(Path);
            Print(line);
        }
        public void Print(string line)
        {
            string[] aut = { "Название", "Автор", "Жанр", "Год выпуска", "Ширина", "Длина", "Переплет", "Способ получения", "Дата добавления", "Дата прочтения", "Рецензия", "Hello" };
            string[] lines = line.Split(new char[] { '\n' });

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    Console.WriteLine(i + ") ");
                    string[] words = lines[i].Split(new char[] { ';' });
                    for (int j = 0; j < words.Length; j++)
                    {
                        Console.WriteLine("{0}: {1}", aut[j % (words.Length-1)], words[j]);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                
            }                   
        }
        public void SearthBooks(int type, string param, string Path, Books books)
        {
            string line = books.ReadBooks(Path);
            string[] lines = line.Split(new char[] { '\n' });
            int[] num = new int[lines.Length];
            int n = 0;
            for (int i = 0; i < lines.Length-1; i++)
            {
                string[] words = lines[i].Split(new char[] { ';' });
                /*if (words[type] == param)
                {
                    num[n] = i;
                    n++;
                }*/
                if (words.Length > type)
                {
                    if (words[type].Contains(param))
                    {
                        num[n] = i;
                        n++;
                    }
                }
            }
            
            if(n == 0)
                {
                Console.WriteLine("Книга не найдена!");
                Console.WriteLine("Нажми любую кнопку для продожения...");
                Console.ReadLine();
                return;
            }
            else
            {
                if(n==1)
                {
                    n = 0;
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("input " + i);
                        Print(lines[num[i]]);
                    }
                    Console.WriteLine("Выберите номер книги:");
                    n = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine("Вы выбрали книгу:");
            if (n < num.Length)
            {
                Print(lines[num[n]]);
            }
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0-Выход");
            Console.WriteLine("1-Редактирование данных книги");
            Console.WriteLine("2-Удаление книги");
            Console.WriteLine("Другое число-выход в главное меню");
            int swich;
            swich = Convert.ToInt32(Console.ReadLine());
            switch (swich)
            {
                case 0:
                    return;
                    //break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Что вы хотите заменить?");
                    Console.WriteLine("0-Автора");
                    Console.WriteLine("1-Название");
                    Console.WriteLine("2-Жанр");
                    Console.WriteLine("3-Год");
                    Console.WriteLine("4-Ширину");
                    Console.WriteLine("5-Высоту");
                    Console.WriteLine("6-Переплет");
                    Console.WriteLine("7-Способ получения");
                    Console.WriteLine("10-Рецензию");
                    Console.WriteLine("Другой символ-выход в главное меню");
                    int swich2 = 0;
                    try
                    {
                        swich2 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        break;
                    }
                    switch (swich2)
                    {
                        case 0:
                            Console.WriteLine("Введите новый параметр:");
                            string A0 = Console.ReadLine();
                            A0.Replace(";", ",");
                            lines[num[n]] = Rename(lines[num[n]], swich2, A0);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            //Save(Addtext(lines), Path);
                            Save(lines, Path);
                            break;
                        case 1:
                            Console.WriteLine("Введите новый параметр:");
                            string A1 = Console.ReadLine();
                            A1.Replace(";", ",");
                            lines[num[n]] = Rename(lines[num[n]], swich2, A1);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            //Save(Addtext(lines), Path);
                            Save(lines, Path);
                            break;
                        case 2:
                            Console.WriteLine("Введите новый параметр:");
                            string A2 = Console.ReadLine();
                            A2.Replace(";", ",");
                            lines[num[n]] = Rename(lines[num[n]], swich2, A2);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            //Save(Addtext(lines), Path);
                            Save(lines, Path);
                            break;
                        case 3:
                            Console.WriteLine("Введите новый параметр:");
                            string B = Console.ReadLine();
                            try
                            {
                                int B1 = Convert.ToInt32(B);
                                if (B1 < 0 || B1 > 2021)
                                {
                                    Console.WriteLine("Ошибка ввода года");
                                    Console.WriteLine("Нажми любую кнопку для продожения...");
                                    Console.ReadLine();
                                    break;
                                }
                                lines[num[n]] = Rename(lines[num[n]], swich2, B);
                                //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                                Save(lines, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число!"); ;
                            }                            
                            break;
                        case 4:
                            Console.WriteLine("Введите новый параметр:");
                            string B2 = Console.ReadLine();
                            try
                            {
                                int B1 = Convert.ToInt32(B2);
                                if (B1 < 0 || B1 > 200)
                                {
                                    Console.WriteLine("Ошибка ввода длины");
                                    Console.WriteLine("Нажми любую кнопку для продожения...");
                                    Console.ReadLine();
                                    break;
                                }
                                lines[num[n]] = Rename(lines[num[n]], swich2, B2);
                                //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                                Save(lines, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число!");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            Console.WriteLine("Введите новый параметр:");
                            string B3 = Console.ReadLine();
                            try
                            {
                                int B1 = Convert.ToInt32(B3);
                                if (B1 < 0 || B1 > 200)
                                {
                                    Console.WriteLine("Ошибка ввода ширины");
                                    Console.WriteLine("Нажми любую кнопку для продожения...");
                                    Console.ReadLine();
                                    break;
                                }
                                lines[num[n]] = Rename(lines[num[n]], swich2, B3);
                                //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                                Save(lines, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число!");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            string binding_format = Console.ReadLine();
                            Dictionary<int, string> binding = new Dictionary<int, string>(5);
                            binding.Add(1, "мягкий");
                            binding.Add(2, "твердый");
                            Console.WriteLine("Выберите тип переплета: ");
                            foreach (KeyValuePair<int, string> keyValue in binding)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                            }
                            try
                            {
                                binding_format = binding[Convert.ToInt32(Console.ReadLine())];
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка ввода переплета");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                                break;
                            }                            
                            lines[num[n]] = Rename(lines[num[n]], swich2, binding_format);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            Save(lines, Path);
                            break;
                        case 7:
                            Console.WriteLine("Введите способ получения: ");
                            Dictionary<int, string> sources = new Dictionary<int, string>(5);
                            sources.Add(1, "покупка");
                            sources.Add(2, "подарок");
                            sources.Add(3, "наследство");
                            Console.WriteLine("Выберите тип переплета: ");
                            string source = Console.ReadLine();
                            foreach (KeyValuePair<int, string> keyValue in sources)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                            }
                            try
                            {
                                source = sources[Convert.ToInt32(Console.ReadLine())];
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка ввода give");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("Введите новый параметр:");
                            lines[num[n]] = Rename(lines[num[n]], swich2, source);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            //Save(Addtext(lines), Path);
                            Save(lines, Path);
                            break;
                        case 10:
                            Console.WriteLine("Введите новый параметр:");
                            string A10 = Console.ReadLine();
                            A10.Replace(";", ",");
                            lines[num[n]] = Rename(lines[num[n]], swich2, A10);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            //Save(Addtext(lines), Path);
                            Save(lines, Path);
                            break;
                        default:
                            break;

                    }
                    /*if (swich2 >= 0 && swich2 <= 2 ||swich2 ==7||swich2 ==10)
                    {
                        Console.WriteLine("Введите новый параметр:");
                        string B = Console.ReadLine();
                        lines[num[n]] = Rename(lines[num[n]], swich2, B);
                        //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                        //Save(Addtext(lines), Path);
                        Save(lines, Path);
                    }
                    else
                    {
                        if(swich2 >=3 && swich2<=5)
                        {
                            Console.WriteLine("Введите новый параметр:");
                            string B = Console.ReadLine();
                            try
                            {
                                Convert.ToInt32(B);
                                lines[num[n]] = Rename(lines[num[n]], swich2, B);
                                //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                                Save(lines, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число!"); ;
                            }
                            
                        }
                        if(swich2 == 6)
                        {                            
                            Console.WriteLine("Выберите тип переплета: ");
                            Console.WriteLine("1 - мягкий");
                            Console.WriteLine("другое - твердый");
                            string binding_format = Console.ReadLine();
                            if (binding_format == "1")
                            {
                                binding_format = "мягкий";
                            }
                            else
                            {
                                binding_format = "твердый";
                            }
                            lines[num[n]] = Rename(lines[num[n]], swich2, binding_format);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            Save(lines, Path);
                        }

                    }*/
                    break;
                case 2:
                    Console.Clear();
                    //Delete(lines, num[n], Path);
                    lines[num[n]] = "";
                    Save(lines, Path);
                    break;
                default:
                    Console.Clear();
                    return;
                    //break;
            }

        }
        public void SearthBooks(int param, string Path, Books books)
        {
            string line = books.ReadBooks(Path);
            string[] lines = line.Split(new char[] { '\n' });
            //Console.WriteLine(param + ">=" + lines.Length);
            //Console.WriteLine(lines[param]);
            if (param >= lines.Length | lines[param] =="")
            {
                Console.WriteLine("Нет книги с таким номером");
                Console.WriteLine("Нажми любую кнопку для продожения...");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("Вы выбрали книгу:");            
            Print(lines[param]);
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0-Выход");
            Console.WriteLine("1-Редактирование данных книги");
            Console.WriteLine("2-Удаление книги");
            Console.WriteLine("Другое число-выход в главное меню");
            int swich;
            swich = Convert.ToInt32(Console.ReadLine());
            switch (swich)
            {
                case 0:
                    return;
                //break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Что вы хотите заменить?");
                    Console.WriteLine("0-Автора");
                    Console.WriteLine("1-Название");
                    Console.WriteLine("2-Жанр");
                    Console.WriteLine("3-Год");
                    Console.WriteLine("4-Ширину");
                    Console.WriteLine("5-Высоту");
                    Console.WriteLine("6-Переплет");
                    Console.WriteLine("7-Способ получения");
                    Console.WriteLine("10-Рецензию");
                    Console.WriteLine("Другой символ-выход в главное меню");
                    int swich2 = 0;
                    try
                    {
                        swich2 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        break;
                    }
                    if (swich2 >= 0 && swich2 <= 2 || swich2 == 7 || swich2 == 10)
                    {
                        Console.WriteLine("Введите новый параметр:");
                        string B = Console.ReadLine();
                        lines[param] = Rename(lines[param], swich2, B);
                        //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                        //Save(Addtext(lines), Path);
                        Save(lines, Path);
                    }
                    else
                    {
                        if (swich2 >= 3 && swich2 <= 5)
                        {
                            Console.WriteLine("Введите новый параметр:");
                            string B = Console.ReadLine();
                            try
                            {
                                Convert.ToInt32(B);
                                lines[param] = Rename(lines[param], swich2, B);
                                //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                                Save(lines, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Вы ввели не число!"); ;
                            }

                        }
                        if (swich2 == 6)
                        {
                            Console.WriteLine("Выберите тип переплета: ");
                            Console.WriteLine("1 - мягкий");
                            Console.WriteLine("другое - твердый");
                            string binding_format = Console.ReadLine();
                            if (binding_format == "1")
                            {
                                binding_format = "мягкий";
                            }
                            else
                            {
                                binding_format = "твердый";
                            }
                            lines[param] = Rename(lines[param], swich2, binding_format);
                            //lines[num[n]] = Rename(lines[num[n]], 9, Convert.ToString(DateTime.Now));
                            Save(lines, Path);
                        }

                    }
                    break;
                case 2:
                    Console.Clear();
                    //Delete(lines, num[n], Path);
                    lines[param] = "";
                    Save(lines, Path);
                    break;
                default:
                    Console.Clear();
                    return;
                    //break;
            }
        }
        public string Rename(string oldline, int tupe, string B)
        {
            string newline = "";
            string[] words = oldline.Split(new char[] { ';' });
            words[tupe] = B;
            words[9] = Convert.ToString(DateTime.Now);
            newline = Addlines(words);
            return newline;
        }
        public string Addlines(string[] worlds)
        {
            string line = "";
            foreach(string s in worlds)
            {
                line += s + ";";
            }
            line.Trim('\n');
            line.Trim(';');
            return line;
        }
        public string Addtext(string[] worlds)
        {
            string line = "";
            foreach(string s in worlds)
            {
                if (line != "\n")
                {
                    line += s + "\n";
                }
            }
            return line;
        }
        public void Save(string[] lines, string Path)
        {
            StringBuilder result = new StringBuilder();
            string line = "";
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
                if (lines[i] != "\n" && lines[i] != "")
                {
                    string newLine = String.Concat(lines[i], Environment.NewLine);                    
                    result.Append(newLine);
                }
            }
            Console.WriteLine(result);
            Console.WriteLine("Для сохранения файла нажмите enter\nЕсли что-то не так - завершите программу!!!");
            Console.ReadKey();
            /*using (FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fileStream);
                sw.Write(result);
                sw.Close();
                fileStream.Close();
            }*/
            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(result);
            }
        }
        /*public void Delete(string[] lines,int n, string Path)
        {
            lines[n] = "\n";
            string result = Addtext(lines);
            Save(result, Path);
        }*/


    }
    public class Menu
    {
        string name = "hello";
        string author = "igor";
        string genre = "Horror";
        int Released = 2000;
        int width = 10;
        int height = 20;
        string binding_format = "";
        string source = "";
        string revie = "";
        string line;
        
        //books.AddBooks(name, author, genre);
        //books.ReadBooks();
        //books.Delete(name, Path);
        //books.Rename(name, "new");
        //books.ReadBooks();
        //Console.ReadKey();

        int num;
        int type;
        bool flag = true;
        public void MenuList(Books books, string Path)
        {
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Внимание! Не забудьте указать путь файла(808 строка)!\nВ случае ввода недопустимых данных, вас выкинет в главное меню.");
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("0-Выход");
                Console.WriteLine("1-Просмотр всего списка книг");
                Console.WriteLine("2-Добавление новой книги");
                Console.WriteLine("3-Поиск нужной книги по названию, жанру, автору");
                //Console.WriteLine("4-Редактирование данных книги");
                //Console.WriteLine("5-Удаление книги");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());                    

                    switch (num)
                    {
                        case 0:
                            flag = false;
                            break;
                        case 1:
                            Console.Clear();
                            books.PrintBooks(Path);
                            Console.ReadKey();

                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Введите название: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите автора: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Введите жанр: ");
                            genre = Console.ReadLine();
                            foreach (char s in genre)
                            {
                            if (Char.IsDigit(s))
                            {
                                Console.WriteLine("неверный жанр");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                                break;
                            }
                            }
                            Console.WriteLine("Введите год: ");
                            try
                            {
                                Released = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                break;
                            }
                            if(Released<0||Released>2021)
                            {
                                Console.WriteLine("Ошибка ввода года");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("Введите ширину: ");
                            try
                            {
                                width = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                break;
                            }
                            Console.WriteLine("Введите длину: ");
                            try
                            {
                                height = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                break;
                            }
                            Dictionary<int, string> binding = new Dictionary<int, string>(5);
                            binding.Add(1, "мягкий");
                            binding.Add(2, "твердый");
                            Console.WriteLine("Выберите тип переплета: ");
                            foreach (KeyValuePair<int, string> keyValue in binding)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                            }                            
                            try
                            {
                            binding_format = binding[Convert.ToInt32(Console.ReadLine())];
                            }
                            catch
                            {
                            Console.WriteLine("Ошибка ввода переплета");
                            Console.WriteLine("Нажми любую кнопку для продожения...");
                            Console.ReadLine();
                            break;
                            }
                            /* 
                            binding_format = Console.ReadLine();
                            Console.WriteLine("1 - мягкий");
                            Console.WriteLine("другое - твердый");
                            binding_format = Console.ReadLine();
                            if (binding_format == "1")
                            {
                                binding_format = "мягкий";
                            }
                            else
                            {
                                binding_format = "твердый";
                            }*/
                            Console.WriteLine("Введите способ получения: ");
                            Dictionary<int, string> sources = new Dictionary<int, string>(5);
                            sources.Add(1, "покупка");
                            sources.Add(2, "подарок");
                            sources.Add(3, "наследство");
                            Console.WriteLine("Выберите тип переплета: ");
                            foreach (KeyValuePair<int, string> keyValue in sources)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                            }
                            try
                            {
                                source = sources[Convert.ToInt32(Console.ReadLine())];
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка ввода give");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                                break;
                            }
                            //source = Console.ReadLine();
                            Console.WriteLine("Введите рецензию: ");
                            revie = Console.ReadLine();
                            books.AddBooks(name, author, genre, Released, width, height, binding_format, source, revie, Path);
                            break;
                        case 3:
                            Console.Clear();
                            books.PrintBooks(Path);
                            Console.WriteLine("Выберите тип поиска");
                            Console.WriteLine("1-название");
                            Console.WriteLine("2-автор");
                            Console.WriteLine("3-жанр");
                            Console.WriteLine("4-по номеру(для следующей лабораторной, в текущей версии не доработан!)");
                            try
                            {
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type == 1 || type == 2 || type == 3)
                                {
                                    Console.WriteLine("Введите точное название:");
                                    string param = Console.ReadLine();
                                    type--;
                                    books.SearthBooks(type, param, Path, books);
                                }
                                else
                                {
                                    if (type == 4)
                                    {
                                        Console.WriteLine("Введите номер:");
                                        int param = Convert.ToInt32(Console.ReadLine());
                                        books.SearthBooks(param, Path, books);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка ввода param4");
                                        Console.WriteLine("Нажми любую кнопку для продожения...");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка ввода mmenu");
                                Console.WriteLine("Нажми любую кнопку для продожения...");
                                Console.ReadLine();
                            }
                            break;
                        /*case 4:                            
                                books.Clean(Path);
                            break;
                            */

                        default:
                            Console.Clear();
                            Console.WriteLine("Ошибка ввода defaut");
                            Console.WriteLine("Нажми любую кнопку для продожения...");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Выход");
                    Console.WriteLine("Вы ввели недопустимое значение в главном меню или произошла какая-то ошибка!");
                    Console.WriteLine("Возможно вы не указали путь к файлу в Main внизу программы");
                    Console.WriteLine("Нажми любую кнопку для завершения...");
                    Console.ReadLine();
                    flag = false;
                }
            }
        }
    }
        
        class Program
    {
        static void Main(string[] args)
        {
            //string Path = @"D:\СУБД\list.txt"; //Путь к файлу..\
            string Path = @"..\..\list.txt";
            var books = new Books();
            var menu = new Menu();
            //books.PrintBooks(Path);
            //Console.ReadKey();
            menu.MenuList(books,Path);
            //Console.ReadKey();
        }
    }
}
