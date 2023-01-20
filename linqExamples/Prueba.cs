namespace linqExamples
{
    public class Prueba
    {

        //Basic linQ
        static public void Marcas()
        {
            string[] cars =
            {
                "Audi A5",
                "Bmw X5",
                "Mercedez GLE",
                "Mercedez AMG",
                "Audi Etron",
                "Toyota Corolla",
                "Toyota Prado"
            };



            //SELECT * OF CARS

            var carlist = from ca in cars select ca;

            foreach (var ca in carlist)
            {
                Console.WriteLine(ca);
            }


            //SELECT WHERE car is Mercedez ( SELECT Mercedez)
            var mercedezList = from m in cars where m.Contains("Mercedes") select m;

            foreach (var li in mercedezList)
            {
                Console.WriteLine(li);
            }


        }




        //number linQ
        static public void NumbersLinq()
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            //each number multipled 3
            //take all number but 9
            //order number by ascending value

            var NumbersList = numbers
                                    .Select(num => num * 3) //{3,6,9}
                                    .Where(num => num != 9) //{all but 9}
                                    .OrderBy(num => num); //order asc

        }



        //text LinQ

        static public void TextLinq()
        {
            string[] letters =
            {
                "A",
                "b",
                "C",
                "ed",
                "rd",
                "pr",
                "mx",
                "xm"
            };



            //select first element to list
            var firstElement = letters.First();

            //select first element that contain "b" or default
            var bText = letters.FirstOrDefault(text => text.Equals("b"));

            //select first element that contain "d" or default
            var dText = letters.FirstOrDefault(text => text.Contains("d"));

            //select last element that contain "x" or default
            var xLastText = letters.LastOrDefault(text => text.Contains("x"));

            // single values
            var uniqueText = letters.Single();
            var uniqueOrDefaultText = letters.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEventNumber = { 0, 2, 6 };

            //obtain {4,8}

            var MyEventNumbers = evenNumbers.Except(otherEventNumber); //compara que numero no estan en la otra lista 


            //OBJECT linQ
            var Enterprice = new[]
            {
                new Enterprice()
                {
                    Id=1,
                    Name="Enterprise1",
                    employee = new []
                    {
                        new employees
                        {
                            Id=1,
                            Name="Starlyn",
                            Email="Starlyn@gmail.com",
                            Salary = 87000
                        },
                        new employees
                        {
                            Id=2,
                            Name="marian",
                            Email="Marian@gmail.com",
                            Salary = 82000
                        },
                        new employees
                        {
                            Id=3,
                            Name="lusi",
                            Email="luis@gmail.com",
                            Salary = 92000
                        }

                    }


                },

                new Enterprice()
                {
                        Id=4,
                        Name="Enterprise2",
                        employee = new[]
                        {
                            new employees
                            {
                            Id=4,
                            Name="lola",
                            Email="lola@gmail.com",
                            Salary = 33000
                            },
                            new employees
                            {
                            Id=5,
                            Name="mario",
                            Email="mario@gmail.com",
                            Salary = 42000
                            },
                            new employees
                            {
                            Id=6,
                            Name="lucy",
                            Email="lucy@gmail.com",
                            Salary = 33233
                            }
                        }
                }

            };

        }

        //JOINS

        static public void linqCollecction()
        {
            var firstList = new List<string>() { "a", "b", "c", "d" };
            var secondList = new List<string>() { "a", "b", "c", "d" };



            //inner join

            var ElementJoin = from FirstElement in firstList
                              join SecondElement in secondList
                              on FirstElement equals SecondElement
                              select new { FirstElement,SecondElement };

            //outer join - left

            var leftOuterJoin = from FirstElement in firstList
                                join secondElement in secondList
                                on FirstElement equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where FirstElement != temporalElement
                                select new { Element = FirstElement };



            //OUTER JOIN - Right

            var RightOuterJoin = from secondElement in secondList
                                join FirstElement in firstList
                                on secondElement equals FirstElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };



            //Union
            var union = leftOuterJoin.Union(RightOuterJoin);




            //SKIP

            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9
            };

            var skipTwoFirstElement = myList.Skip(2); //{3,4,5,6,7,8,9}

            var skipTwoLastElement = myList.SkipLast(2); //{1,2,3,4,5,6,7};

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); //{4,5,6,7,8,9}


            //Take
            var takeTwoFirstElement = myList.Take(2); //{ 1,2}

            var takeTwoLastElement = myList.TakeLast(2); // { 8, 9}

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // {1,2,3}

           

            

        }

        //paging with Skip & Take
        static public IEnumerable<t> GetPage<t> (IEnumerable<t> collection, int pageNumber, int resultPerPage)
        {
            int StartIndex = (pageNumber - 1) * resultPerPage;
            return collection.Skip(StartIndex).Take(resultPerPage);
        }



        //variables
        static public void LinQVariable()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0} ", numbers.Average());

            foreach(var number in numbers) 
            {
                Console.WriteLine("Numbers: {0} Square: {1} ", number, Math.Pow(number, 2));
            }


        }


        //Zip
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> ZipNumbers = numbers.Zip(stringNumbers,(number, word) => number + "=" + word);

            //salida
            //{ 1 = one, two=2 ....}

        }

        //Repeat and Range 

        static public void RepeatAndRangeLinQ()
        {
            //Range with linQ
            //generate collection of numbers 1 --1000
            IEnumerable<int> firs1000 = Enumerable.Range(1, 1000); //primer parametro:inicio, segundo parametro:final;

            //Repeat with linQ
            //generate a collection of letter "X" repeat
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}

        }

        
        static public void AlllinQ()
        {
            var ClassRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Pedro",
                    grade = 90,
                    Certified = true,
                },

                new Student
                {
                    Id = 2,
                    Name = "Manuel",
                    grade = 98,
                    Certified = true,
                },

                new Student
                {
                    Id = 3,
                    Name = "Nina",
                    grade = 70,
                    Certified = true,
                },

                new Student
                {
                    Id = 4,
                    Name = "Mario",
                    grade = 50,
                    Certified = false,
                },

                new Student
                {
                    Id = 5,
                    Name = "Mario",
                    grade = 50,
                    Certified = false,
                }
            };

            var CertifiedStudents = from student in ClassRoom
                                    where student.Certified == true
                                    select student;

            var NotCertifiedStudent = from student in ClassRoom
                                      where student.Certified == false
                                      select student;

            var appovedStudentNames = from student in ClassRoom
                                      where student.Certified == true && student.grade >= 50
                                      select student.Name;


            var certifiedQuery = ClassRoom.GroupBy(student => student.Certified);

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("----- {0} ----- ", group.Key);
                foreach(var students in group) 
                {
                    Console.WriteLine(students.Name);
                } 

            }

        }


        //all = todos tienen que cumplir con una condicion
        //any = alguna tiene que cumplir con una condicion 
        static public void AllLinQ()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true por que todos los numeros son menores de 10
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

        }


        //Aggregate
        static public void Aggregate()
        {
            int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int numbers = numbs.Aggregate((prevAgg, current) => prevAgg + current);
            //Output 
            // 0, 1 => 1
            //1,2 => 3,
            //3,4 => 7
            //etc..exte

            string[] words = { "Hello,", "my", "name", "is", "Starlyn" };
            string greeting = words.Aggregate((prevAgg, current) => prevAgg + current);
            //output
            //"","hello," => hello
            //"hello","my" => hello my
            //"hello my","name" => hello, my name
            //etc..
        }

        
        //Distint
        static public void distintValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            IEnumerable<int> values = numbers.Distinct();
        }


        //group by
        static public void groupByExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //obtain only even number and generated two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            //we will have two group
            //1.the group that doesn't fit the condition (odd number)
            //2. the group tha fits the condition

            foreach(var num in grouped) 
            { 
                foreach (var value in grouped)
                {
                    Console.WriteLine(value); // 1,3,5,7,9.... 2,4,6,8....
                }
            }

        }


       
        

        static public string letter(string text) 
        {
            
            return text.Remove(0, text.Length - 1);

        }

        static public void Main(String[] args)
        {
            letter("mario es calvo");
        }


      
        
    }
}