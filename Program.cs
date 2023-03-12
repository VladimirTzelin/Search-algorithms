/* Описание алгоритма бинарного поиска
Принцип работы алгоритма бинарного поиска
Основная последовательность действий алгоритма выглядит так:
1.	Сортируем массив данных.
2.	Делим его пополам и находим середину.
3.	Сравниваем срединный элемент с заданным искомым элементом.
4.	Если искомое число больше среднего — продолжаем поиск в правой части массива 
(если он отсортирован по возрастанию): делим ее пополам, повторяя пункт 3. 
Если же заданное число меньше — алгоритм продолжит поиск в левой части массива, 
снова возвращаясь к пункту 3.  */


// Реализация основной версии двоичного поиска. https://codelab.ru/source/csharp/binsearch
//В отсортированном массиве ищет элемент за не более чем log2n проходов, где n - длинна массива.
//Если искомых элементов в массиве несколько - возвращается первый из них.

int Go(int[] nums, int len, int target)
{
    int low = -1, upp = len, position = 0, mid = 0;
    // область поиска nums[low…upp]
    while (low + 1 != upp)  
         
    {   // находим среднее значение в пространстве поиска и сравнивает его с целью
        //mid = (low + upp) / 2;  // может произойти переполнение
        mid = upp - (upp - low) / 2;
        if (nums[mid] < target)
        {
            low = mid;
        }
        else
        {
            upp = mid;
        }
    }

    position = upp;
    if (position >= len || nums[position] != target)
    {
        position = -1;
    }
    return position;
}


// counting sort
//Вариант сортировки подсчетом
int[] BasicCountingSort(int[] array, int k)
{
    int[] count = new int[k + 1];   // массив счётчиков значений
    for (int i = 0; i < array.Length; i++)
    {
        count[array[i]]++;      // считаем количество значений элементов array[i]
    }

    int index = 0;
    for (int i = 0; i < count.Length; i++) // формируем итоговый отсортированный массив
    {
        for (int j = 0; j < count[i]; j++)
        {
            array[index] = i;
            index++;
        }
    }

    return array;
}

//метод для получения массива заполненного случайными числами
int[] GetRandomArray(int arraySize, int minValue, int maxValue)
{
    Random rnd = new Random();
    int[] randomArray = new int[arraySize];
    for (int i = 0; i < randomArray.Length; i++)
    {
        randomArray[i] = rnd.Next(minValue, maxValue);
    }

    return randomArray;
}

int Promt(string msg)
{
    Console.Write(msg + "-> ");
    return int.Parse(Console.ReadLine()!);
}

// Вдруг введено не положительное число!?
bool Check(int num)
{
    bool b = true;
    if (num < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Введено отрицательное число!!! \n");
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(0);
        b = false;
    }
    return b;
}

//Проверка введённых значений [rows,columns]
void CheckingData(int min, int max)
{
    if (min > max)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Введено недопустимое значение! Максимальное значение {max} < {min} ");
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(0);
    }
}


int arrSize = Promt("Укажите длину массива ");
Check(arrSize);
int minVal = Promt("Укажите минимальное значение в массиве ");
Check(minVal);
int maxVal = Promt("Укажите максимальное значение в массиве ");
Check(maxVal);
CheckingData(minVal, maxVal);
int[] arr = GetRandomArray(arrSize, minVal, maxVal);
Console.WriteLine("Входные данные: \t {0}", string.Join(", ", arr));
Console.WriteLine("Отсортированный массив:  {0}", string.Join(", ", BasicCountingSort(arr, maxVal)));

//int[] nums = { 2, 5, 6, 8, 9, 10 };

int target = Promt("Укажите искомое значение ");
int index = Go(arr, arrSize, target);

if (index != -1)
{
    Console.WriteLine($"Значение {target} найдено под индексом  {index}");
}
else
{
    Console.WriteLine($"Элемент {target} не найден в массиве");
}

return 0;




