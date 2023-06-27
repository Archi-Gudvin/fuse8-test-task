using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

internal class Program
{
    /// <summary>
    /// Метод валидации логина
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    private static bool IsValide(string login)
    {
        string pattern = "^[a-zA-Z0-9_][a-zA-Z0-9-_]{1,23}$";

        if (!Regex.IsMatch(login, pattern)) return false;

        return true;
    }


    private static void Main(string[] args)
    {
        try
        {
            int SumNumberOfRegistrationAttempts = 0;

            int SumLoginsLenght = 0;

            //количество наборов входных данных
            int NumberOfSets = Convert.ToInt32(Console.ReadLine());

            if (NumberOfSets > Math.Pow(10, 4) || NumberOfSets < 1)
            {
                Console.WriteLine("Лимит числа от 1 до 10^4"); throw new Exception();
            }

            //список ответов правильности логина для конкретного набора данных
            List<string> Answers = new List<string>();

            for (int i = 0; i < NumberOfSets; i++)
            {
                //количество попыток регистрации в системе
                int NumberOfRegistrationAttempts = Convert.ToInt32(Console.ReadLine());

                if (NumberOfRegistrationAttempts > 2 * Math.Pow(10, 5) || NumberOfRegistrationAttempts < 1)
                {
                    Console.WriteLine("Лимит числа от 1 до 2*10^5"); break;
                }

                //коллекция с введенными логинами
                List<string> logins = new List<string>(NumberOfRegistrationAttempts);

                for (int l = 0; l < NumberOfRegistrationAttempts; l++)
                {
                    //вводим логин
                    string? login = Console.ReadLine();
                    
                    if (login.Length > 255 || login.Length < 1)
                    {
                        Console.WriteLine("Лимит строки от 1 до 255"); break;
                    }
                    else if (login is null) { Console.WriteLine("Значение не введено"); break; }

                    //добавляем в коллекцию
                    logins.Add(login); SumLoginsLenght += login.Length;
                }

                //проверяем валидность
                for (int j = 0; j < logins.Count; j++)
                {
                    if (IsValide(logins[j]))
                    {
                        Answers.Add("YES");
                    }
                    else { Answers.Add("NO"); };
                }

                Answers.Add(" ");

                SumNumberOfRegistrationAttempts += NumberOfRegistrationAttempts;
            }

            if (SumNumberOfRegistrationAttempts > 2 * Math.Pow(10, 5) || SumLoginsLenght > Math.Pow(10, 4))
            {
                throw new Exception();
            }

            Console.WriteLine( );

            //выводим ответы
            foreach (var answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}