class Program
{
    static void Main(string[] args)
    {
        //написать цикл для ввода 5 фамилий
        Console.WriteLine("Введите фамилию");

        NumberRead numberRead = new NumberRead();
        numberRead.NumberEnterEvent += ShowNumber;

        while (true)
        {
            try
            {
                numberRead.NumRead();
            }
            catch (FormatException)
            {
                Console.WriteLine("Значение некорректно");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Возникло исключение ArgumentException");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Возникло исключение InvalidCastException");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Возникло исключение NullReferenceException");
            }
        }

        static void ShowNumber(int num)
        {
            switch (num)
            {
                case 1: Console.WriteLine("Сортировка А-Я");
                    break;
                case 2: Console.WriteLine("Сортировка Я-А");
                    break;
            }
        }
    }
}

class NumberRead
{
    public delegate void NumberEnterDelegate(int num);
    public event NumberEnterDelegate NumberEnterEvent;

     public void NumRead()
    {
        Console.WriteLine("Введите число 1 для сортировки А-Я, введите число 2 для сортировки Я-А");

        int num = Convert.ToInt32(Console.ReadLine());

        if (num != 1 && num != 2) throw new FormatException();

        NumberEnter(num);
    }

    protected virtual void NumberEnter(int num)
    {
        NumberEnterEvent?.Invoke(num);
    }
}

//событие для сортировки
class Sorting
{
    public delegate void SortingDelegate();
    public event SortingDelegate SortingEvent;

    public void Sort()
    {

    }
    protected virtual void SortingProcess()
    {
        SortingEvent?.Invoke();
    }
}