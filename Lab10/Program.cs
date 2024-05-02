using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Данные с прошлой работы, в варианте был словарь (Dictionary)
        Dictionary<string, int> data = GenerateSampleData();
        
        // Параллельная сортировка данных
        
        // 4 Замерка времени выполнения 
        Stopwatch stopwatch = Stopwatch.StartNew();
        KeyValuePair<string, int>[] sortedData = ParallelSort(data.ToArray());
        stopwatch.Stop();

        Console.WriteLine($"Время выполнения параллельной сортировки: {stopwatch.ElapsedMilliseconds} ms");

        // Вывод результатов только первых 100
        foreach (var pair in sortedData.Take(100)) 
        {
            Console.WriteLine($"Word: {pair.Key}, Frequency: {pair.Value}");
        }
    }

    // 2 Реализовать параллельную сортировку массива по выбранному полю (используйте многопоточность для разделения массива на подмассивы и их сортировки. 3 Создать несколько потоков 
    static KeyValuePair<string, int>[] ParallelSort(KeyValuePair<string, int>[] array)
    {
        int length = array.Length;
        int range = length / 4; // Для 4 потоков
        var tasks = new Task<KeyValuePair<string, int>[]>[4];

        for (int i = 0; i < 4; i++)
        {
            int start = i * range;
            int end = (i == 3) ? length : start + range;
            tasks[i] = Task.Run(() =>
            {
                return array.Skip(start).Take(end - start).OrderBy(pair => pair.Value).ToArray();
            });
        }

        Task.WaitAll(tasks);

        // Слияние отсортированных подмассивов
        return MergeSortedArrays(tasks.Select(t => t.Result).ToArray());
    }

    static KeyValuePair<string, int>[] MergeSortedArrays(KeyValuePair<string, int>[][] arrays)
    {
        return arrays.SelectMany(x => x).OrderBy(x => x.Value).ToArray(); // Простое слияние с дополнительной сортировкой
    }

    
    // 1 Реализовать метод, который в 4 потока заполняет массив из 1 миллиона объектов случайными данными
    static Dictionary<string, int> GenerateSampleData()
    {
        Random random = new Random();
        Dictionary<string, int> data = new Dictionary<string, int>();
        for (int i = 0; i < 1000000; i++) // Генерируем 1 миллион записей
        {
            string key = $"word_{i}";
            int frequency = random.Next(1, 100);
            data[key] = frequency;
        }
        return data;
    }
}
