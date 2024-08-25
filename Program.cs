using System;
using MySql.Data.MySqlClient;

namespace testBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            try
            {
                Console.WriteLine("Введите host сервера:");
                string host = Console.ReadLine();
                Console.WriteLine("Введите user id:");
                string userId = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();
                Console.WriteLine("Введите название базы:");
                string baseSql = Console.ReadLine();
                
                string connectionString = $"Server={host};Database={baseSql};User ID={userId};Password={password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Подключение успешно!");

                    bool exit = true;
                    while (exit)
                    {
                        Console.WriteLine("Введите название таблицы:");
                        string table = Console.ReadLine();
                        
                        Console.WriteLine("Введите название столбца:");
                        string column = Console.ReadLine();
                        
                        Console.WriteLine("Введите 1 - если значение будет цифрой\nВведите 2 -  если значение будет строкой");
                        int choose = Convert.ToInt32(Console.ReadLine());
                        switch (choose)
                        {
                            case 1:
                                AddInt(connection, table, column);
                                Console.WriteLine("Введите exit чтобы завершить, для продолжения поле можете оставить пустым");
                                string e1 = Console.ReadLine();
                                if (e1 == "exit")
                                {
                                    exit = false;
                                }
                                else
                                {
                                    exit = true;
                                }
                                break;
                            case 2:
                                AddString(connection, table, column);
                                Console.WriteLine("Введите exit чтобы завершить, для продолжения поле можете оставить пустым");
                                string e2 = Console.ReadLine();
                                if (e2 == "exit")
                                {
                                    exit = false;
                                }
                                else
                                {
                                    exit = true;
                                }
                                break;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("Вы ввели неверные данные для подключение к базе!");
                Menu();
            }
        }

        static void AddInt(MySqlConnection connection, string table, string column)
        {
            Console.WriteLine("Введите значение:");
            int value = Convert.ToInt32(Console.ReadLine());

            string query1 = $"INSERT INTO `{table}` (`{column}`) VALUES (@value)";

            using (MySqlCommand command = new MySqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();
            }
        }

        static void AddString(MySqlConnection connection, string table, string column)
        {
            Console.WriteLine("Введите значение:");
            string value2 = Console.ReadLine();

            string query2 = $"INSERT INTO `{table}` (`{column}`) VALUES (@value2)";

            using (MySqlCommand command = new MySqlCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@value2", value2);
                command.ExecuteNonQuery();
            }
        }
    }
}