using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
           // Find the words in the collection that start with the letter 'L'
           List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
           
           IEnumerable <string> LFruits = 
           from x in fruits
           where x.StartsWith("L")
           select x;

           // Which of the following numbers are multiples of 4 or 6
           List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable <int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 ==0);
            foreach(int number in fourSixMultiples){
                //Console.WriteLine(number);
            }
                // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = 
            from y in names
            orderby y descending
            select y;

            // Build a collection of these numbers sorted in ascending order
            List<int> numbersTwo = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var ascend=
            from z in numbersTwo
            orderby z ascending
            select z;

            // foreach(int x in ascend){
            //     Console.WriteLine(x);
            // }
            // Output how many numbers are in this list
            List<int> numbersThree = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            int counter= numbersThree.Count();
            Console.WriteLine("There are {0} numbers", counter);

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            double sum= purchases.Sum();
            Console.WriteLine("The sum is {0:C}",sum);

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double expense= prices.Max();
            Console.WriteLine("The most expensive product cost {0:C}",expense);

            /*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            // foreach(int x in wheresSquaredo){
            //     if(x == x % x){
            //         Console.WriteLine(x);
            //     }
            //}
            IEnumerable <int> square=
             wheresSquaredo.TakeWhile(x=> Math.Sqrt(x) %1 !=0 );
             foreach(int z in square){
                 Console.WriteLine(z);
             }
                  // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };
         

          

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> richKids= 
            from r in customers
            where r.Balance>=1000000
            select r;

            IEnumerable<Customer> inOrder=
            from x in customers
            orderby x.Name ascending
            select x;
            

            var grouped= 
            from cust in customers
            where cust.Balance >= 100000
            group cust by cust.Bank into taco
            select new {bankName= taco.Key, count= taco.Count(), Customers= taco};

            var newReport=
            from b in customers
            where (b.Balance >= 1000000)
            orderby b.Name ascending
            join p in banks on b.Bank equals  p.Symbol
            select new {x= p.Symbol, banks= p.Name, nameof=b.Name};
            
            // foreach (var customer in grouped)
            // {
            //     Console.WriteLine($"{customer.bankName} - {customer.count}");
            //     foreach(var cust in customer.Customers){
            //         Console.WriteLine($"{cust.Name} - {cust.Balance}");
            //     }
            // }

            foreach(var meh in newReport){
                Console.WriteLine($"{meh.nameof} - {meh.banks}");

            }

            // foreach(Customer x in richKids){
            //     Console.WriteLine($"{x.Bank} {x.Name}");
            // }
            //   foreach(Customer n in inOrder){
            //     Console.WriteLine($"{n.Bank} {n.Name}");
            // }
        }
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
        public class Bank
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
        }
        public class Customerx
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
  
    }
}
