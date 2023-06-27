using System.Text.RegularExpressions;

public class Program
{
    /// <summary>
    /// Метод валидации слова
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    private static bool IsValide(string word)
    {
        string pattern = "^[a-zA-Z]{0,9}$";

        if (!Regex.IsMatch(word, pattern)) return false;
        if (word is null) return false;

        return true;
    }

    static string FindMaxRhymeWord(string query, HashSet<string> words)
    {
        string maxRhymeWord = "";
        int maxRhyme = 0;

        foreach (string word in words)
        {
            if (word == query) continue;

            int rhyme = GetRhyme(query, word); // находим зарифмованность между запросом и текущим словом

            if (rhyme > maxRhyme) { // если зарифмованность с текущим словом больше максимальной зарифмованности
                maxRhyme = rhyme; // обновляем максимальную зарифмованность
                maxRhymeWord = word; // обновляем слово с максимальной зарифмованностью
            }
        }

        return maxRhymeWord; // возвращаем слово с максимальной зарифмованностью
    }

    static int GetRhyme(string word1, string word2)
    {
        int maxLength = Math.Min(word1.Length, word2.Length); // находим максимальную длину суффикса

        int rhyme = 0;
        for (int i = 1; i <= maxLength; i++) { // перебираем все возможные длины суффикса
            string suffix1 = word1.Substring(word1.Length - i); // находим суффикс первого слова
            string suffix2 = word2.Substring(word2.Length - i); // находим суффикс второго слова

            if (suffix1 == suffix2)
            { 
                rhyme = i; // обновляем зарифмованность
            }
            else
            { 
                break;
            }
        }

        return rhyme;
    }

    private static void Main(string[] args)
    {
        try
        {
            //количество наборов входных данных
            int DictionarySize = Convert.ToInt32(Console.ReadLine());

            if (DictionarySize > 50000 || DictionarySize < 2)
            {
                Console.WriteLine("Лимит словаря от 2 до 50000"); throw new Exception();
            }
            
            //словарь
            HashSet<string> words = new HashSet<string>(DictionarySize);

            for (int i = 0; i < DictionarySize; i++)
            {
                string word = Console.ReadLine();

                if (IsValide(word))
                {
                    words.Add(word);
                }
                else { Console.WriteLine("Слово не валидно"); throw new Exception(); }
            }

            //количество запросов
            int RequestsCount = Convert.ToInt32(Console.ReadLine());

            if (DictionarySize > 50000 || DictionarySize < 1)
            {
                Console.WriteLine("Лимит запросов от 1 до 50000"); throw new Exception();
            }

            //коллекция запросов
            List<string> requests = new List<string>(RequestsCount);

            //коллекция слов-рифм
            List<string> WordsForRhymes = new List<string>(RequestsCount);

            for (int i = 0; i < RequestsCount; i++)
            {
                //ввод слова-запроса
                string? request = Console.ReadLine();

                //проверяем валидность
                if (IsValide(request))
                {
                    requests.Add(request);
                }
                else { Console.WriteLine("Запрос не валиден"); throw new Exception(); }

                string maxRhymeWord = FindMaxRhymeWord(request, words);

                WordsForRhymes.Add(maxRhymeWord);
            }

            Console.WriteLine();

            //выводим рифмы
            foreach (var rhymeWord in WordsForRhymes)
            {
                Console.WriteLine(rhymeWord);
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}