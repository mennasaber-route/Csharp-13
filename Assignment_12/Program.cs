namespace Assignment_12
{
    internal class Program
    {
        internal class Container<T>
        {
            public List<T> items = new List<T>();
            public void Add(T item)
            {
                items.Add(item);
            }

            public T Get(int index)
            {
                return items[index];
            }

        }


        static void Main(string[] args)
        {

            // *******   C# Advanced **********

            #region  Question 1

            // Q1: What is a generic class? Why use generics?
            // generic class is a class that can have more than one type parameter, generic classes can be written once and can be used for different data types
            // without making a new class for each data type , we can also know the data type when calling it at compilation time,

            // We use generics for code Reusability,Type Safety,better performance,cleaner code and to reduce Duplication.

            #endregion


            #region  Question 2
            //Q2: Write a generic class Container<T> with Add and Get methods.

            Container<int> number = new Container<int>();
            number.Add(10);
            number.Add(20);

            Console.WriteLine(number.Get(0));
            Console.WriteLine(number.Get(1));

            #endregion


        }
    }
}
