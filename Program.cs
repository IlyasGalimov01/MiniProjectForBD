using System;
using MySql.Data.MySqlClient;

namespace testBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
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

                    
                    while (true)
                    {
                        Console.WriteLine("Введите название таблицы:");
                        string table = Console.ReadLine();
                        
                        Console.WriteLine("Введите название столбца:");
                        string column = Console.ReadLine();
                        
                        AddValueOnTable(connection, table, column);
                        
                        Console.WriteLine("Введите exit чтобы завершить, для продолжения поле можете оставить пустым");
                        string e = Console.ReadLine();
                        if (e == "exit")
                        {
                            return;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("Вы ввели неверные данные для подключение к базе!");
                Start();
            }
        }
        
        static void AddValueOnTable(MySqlConnection connection, string table, string column)
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