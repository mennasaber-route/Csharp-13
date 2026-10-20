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

        internal class Pair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Pair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        public static void Swap<T>(ref T a , ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static T Findmax<T>(T[] items) where T : IComparable<T>
        {
           if(items != null && items.Length > 0)
           {
                T max = items[0];
                for (int i= 1; i< items.Length; i++)
                {
                    if (items[i].CompareTo(max) > 0)
                    {
                        max = items[i];
                    }              
                }
                return max;
            }
            return default;
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

            #region  Question 3
            //Q3:What are multiple type parameters? Write Pair<TKey, TValue>.
            // Multiple type parameters are when a generic class or method can take more than one type parameter.

            Pair<int, string> pair = new Pair<int, string>(1 , "Menna");
            Console.WriteLine(pair.Key);
            Console.WriteLine(pair.Value);

            #endregion

            //  *******   Part 2 : C# Advanced 1 **********
            #region  Question 4
            //Q4: What is a generic method? Write Swap<T> method.
            // A generic method is a method that can take one or more type parameters,
            // also can be ageneric even if the class is not generic.

            int a = 10, b = 20;
            Program.Swap(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);

            #endregion


            #region  Question 5
            //Q5: Write a generic method FindMax<T> that finds maximum value

            int [] items = [ 1, 2, 3, 4, 5 ];
            Console.WriteLine(Program.Findmax(items));

            #endregion
        }
    }
}
