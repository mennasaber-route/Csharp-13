using System.Data;
using System.Reflection.Metadata;
using static Assignment_12.Program;

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

        public class MyContainer<T> where T : struct
        {
            public int Value { get; set; }
            public MyContainer(int value)
            {
                Value = value;
            } 
        }

        public class MyContainer2<T> where T : class
        {
            public string TValue { get; set; }
            public MyContainer2(string value)
            {
                TValue = value;
            }
        }


        public class Factory<T> where T : new()
        {
            public T Create()
            {
                return new T();
            }
        }
        public class Student
        {
            public string Name { get; set; } = "";
        }

        public class Invoice : IPrintable
        {
            public void Print()
            {
                Console.WriteLine("Printing Invoice");
            }
        }

        public class PrintableContainer<T> where T : IPrintable
        {
            public void PrintItem(T item)
            {
                item.Print();
            }
        }

        public class  Person
        {
            public string Name { get; set; } = "";
        }

        public class Employee : Person
        {
            public int EmployeeId { get; set; }
        }

        public class PersonContainer<T> where T : Person
        {
            public void PrintName(T Person)
            {
                Console.WriteLine(Person.Name);
            }
        }

        public class Product : IEntity
        {
            public int Id { get; set; }
        }

        public class EntityManager<T>
            where T : class, IEntity, new()
        {
            public T CreateEntity()
            {
                return new T();
            }
        }



        // // //
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


            #region  Question 6
            //Q6: What is a generic interface? Write IRepository<T>
                  // A generic interface is a contract that interface can take one or more type parameters.

            //ProductRepository productRepository = new ProductRepository();
            //Product product1 = new Product( 1, "Laptop", 100.0m );
            //Product product2 = new Product(2, "PC", 200.0m);
            //Product product3 = new Product(3, "Iphone", 400.0m);

            //productRepository.Create(product1);
            //productRepository.Create(product2);
            //productRepository.Create(product3);


            //List<Product> products = productRepository.GetAll();
            //foreach (Product product in products)
            //{
            //    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            //}
            
            //productRepository.GetById(2);
            //productRepository.Update(2, new Product(2, "Tablet", 150.0m));
            //productRepository.Delete(3);

            #endregion


            #region  Question 7
            //Q7: What is the 'struct' constraint? Write an example
                 // The struct constraint is a generic Primary constraint , such as int , double, and
                 // you can use it on your data type only once or zero.

            MyContainer<int> myContainer = new MyContainer<int>(10);
            Console.WriteLine(myContainer.Value);

            #endregion


            #region  Question 8
            //Q8: What is the 'class' constraint? Write an example
            // The class constraint is a generic Primary constraint , such as string, and
            // you can use it on your data type only once or zero.

            MyContainer2<string> myContainer2 = new MyContainer2<string>("Menna");
            Console.WriteLine(myContainer2.TValue);

            #endregion


            #region  Question 9
            //Q9: What is the 'new()' constraint? Write an example
            //The new() constraint requires the type argument to have a public parameterless constructor.
            //It allows the generic class or method to create an object using new T()

            Factory<Student> factory = new Factory<Student>();
            Student student = factory.Create();
            Console.WriteLine("Student created");

            #endregion


            #region  Question 10
            //Q10:  What is the interface constraint? Write an example
            // The interface constraint requires the type argument to implement a specific interface.

            PrintableContainer<Invoice> printableContainer = new PrintableContainer<Invoice>();
            printableContainer.PrintItem(new Invoice());

            #endregion


            #region  Question 11
            //Q11: What is the base class constraint? Write an example.

            // A base class constraint restricts the generic type parameter
            // to a specified base class or one of its derived classes.

            PersonContainer<Employee> personContainer = new PersonContainer<Employee>();
            Employee employee = new Employee { Name = "Menna", EmployeeId = 1 };
            personContainer.PrintName(employee);

            #endregion


            #region  Question 12
            //Q12: How do you apply multiple constraints? Write an example

            //Multiple constraints can be applied to a generic type parameter by listing the required constraints
            //after where T :, separated by commas.

            EntityManager<Product> manager = new EntityManager<Product>();

            Product product = manager.CreateEntity();
            product.Id = 100;

            Console.WriteLine(product.Id);

            #endregion


            #region  Question 13
            //Q13: What does the 'default' keyword do in generics?
            
                // The default keyword is used to return the default value of a generic type parameter.

            #endregion

        }
    }
}
