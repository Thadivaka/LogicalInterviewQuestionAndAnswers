using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldmanSachsInterviewQuestions
{
    public class Program
    {
        static DateTime dt;
        static string s;
        static int i;
        static int? iq;
        public static void Main(string[] args)
        {
            //numberOfItems("**|**|*|*****|****|*", new List<int>(), new List<int>());
            //numberOfItems("|**|*|*", new List<int>{ 1, 1 }, new List<int> { 5, 6 });
            //AverageAndGrade();
            //OddLeftEvenRight();
            //FindCountOfPairNumbers();
            //BubbleSort();
            //SecondSmallestNumber();
            //SmallestNumber();
            //RemoveConsecutiveCharacterPairs();
            //CharacterRepatingMaximumTimes();
            //FirstNonRepeativeChar();
            //ReverseString();
            //Pangram();

            //PangramMissingLetters();
            //StringInputWithCount();
            //SumOfFibonacciSeries();
            //Multiplication();
            //Division();
            //IsPrimeNumber();
            //Armstrong();
            //SortedLinkedList();
            //FindReportingEmployee();
            //FloydTriangle();
            //RobotFormat();
            //Console.WriteLine("{0} {1}", Sainsburys.Foo(10), Sainsburys.Bar(10));
            //Console.ReadKey();
            ////FindLargest(new int[] { 5, 8, 1, 2, 3, 4, 6 });
            //string[] l = { "abc", "def", "ABC", "DEF" };
            //var output = l.Where(s => Char.IsUpper(s[0]))
            //                    .Aggregate((current, next) => current + next);
            ////Console.WriteLine(l.Where(s => Char.IsUpper(s[0]))
            ////                    .Aggregate((current, next) => current + next));

            //var input = new List<int>() { 90, 80, 70 };
            //var procs = new List<Func<int>>();
            //foreach (var val in input)
            //{
            //    procs.Add(() => val);
            //}
            //foreach (var proc in procs)
            //{
            //    Console.WriteLine(proc());
            //}

            //C c = new C();
            //c.foo();


            //Console.WriteLine("{0}, {1}, {2}, {3}", dt == null, s == null, i == null, iq == null);

            //Console.ReadKey();
            //FindMinimumNumber();
            //string[] l = { "abc", "def", "ABC", "DEF" };
            //Console.WriteLine(l.Where(s => Char.IsUpper(s[0]))
            //                    .Aggregate((current, next) => current + next));
            List<string> input = new List<string> { "88 99 200", "88 99 300", "99 32 100", "12 12 15" };
            ProcessLogs(input, 2);
        }

        public static List<string> ProcessLogs(List<string> logs, int threshold)
        {
            List<string> logs2 = new List<string>();
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (string log in logs)
            {
                int senderUserId = Convert.ToInt32(log.Split(' ')[0]);
                int ReceiveUserId = Convert.ToInt32(log.Split(' ')[1]);

                if(result.Any(r => r.Key == senderUserId))
                {
                    var senderValue = result.Where(r => r.Key == senderUserId).FirstOrDefault().Value;

                    result[senderUserId] = senderValue + 1;
                }
                if(result.Any(r => r.Key == ReceiveUserId))
                {
                    var receiverValue = result.Where(r => r.Key == ReceiveUserId).FirstOrDefault().Value;

                    result[ReceiveUserId] = receiverValue + 1;
                }
                if(result.Count == 0 && !result.ContainsKey(senderUserId))
                {
                    result[senderUserId] = 1;
                }
                if (result.Count == 0 && !result.ContainsKey(ReceiveUserId))
                {
                    result[ReceiveUserId] = 1;
                }
            }
            var thresholdResult = result.Where((r) => r.Value >= threshold).OrderBy(tr => tr.Value);
            foreach(var item in thresholdResult)
            {
                logs2.Add(item.Key.ToString());
            }

            return logs2;
        }
        //|||**|*|*|**||||**|***
        public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            List<int> resultArray = new List<int>();
            for (int i = 0; i < startIndices.Count; i++)
            {
                string subStringValue = s.Substring(startIndices[i] - 1, endIndices[i]);
                int starCount = 0;
                int pipeCount = 0;
                int totalStartCount = 0;
                bool betweenPipe = false;
                foreach (char c in subStringValue)
                {
                    if (c == '|')
                    {
                        pipeCount++;
                        betweenPipe = true;
                    }
                    else if (betweenPipe && pipeCount == 1 && c == '*')
                    {
                        starCount++;
                    }
                    if (pipeCount % 2 == 0)
                    {
                        if (starCount > 0)
                        {
                            totalStartCount += starCount;
                            starCount = 0;
                        }
                        pipeCount = 1;
                    }
                }
                resultArray.Add(totalStartCount);
            }

            return resultArray;
            //return null;

            //int pipeCount = 0;
            //int starCount = 0;
            //bool hasPipe = false;
            //var splitPipe = x.Split('|');
            //for(int i=0; i < x.Length; i++)
            //{
            //    if (x[i] == '|')
            //    {
            //        hasPipe = true;
            //        pipeCount++;
            //    }
            //    if(x[i] == '*' && hasPipe)
            //    {
            //        starCount++;
            //        hasPipe = false;
            //    }
            //}

            return null;
        }
        private static int FindLargest(int[] array)
        {
            int largest = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largest)
                {
                    largest = array[i];
                }
            }
            return largest;
        }

        public static void OddLeftEvenRight()
        {
            int[] arr = new int[] { 3, 5, 6, 8, 1 };

            int i = 0, j = arr.Length - 1;

            while (i < j)
            {
                if (arr[i] % 2 == 1)
                    i++;
                else
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j--;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
            //arr.ToList().ForEach(num => Console.WriteLine(num.ToString()));
            //Console.ReadKey();
        }

        public static void FindCountOfPairNumbers()
        {
            int pairCount = 7;
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == pairCount)
                    {
                        Console.WriteLine(arr[i] + "," + arr[j]);
                    }
                }
            }
            //Console.ReadKey();
        }

        public static void BubbleSort()
        {
            int[] arr = new int[] { 3, 2, 8, 6, 9, 1 };

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                string.Join(", ", arr);
            }
            Console.WriteLine(string.Join(", ", arr));
            //Console.ReadKey();
        }

        public static void SecondSmallestNumber()
        {
            int[] arr = new int[] { 7, 5, 8, 6, 9, 1 };

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Second smallest number is : {0}", arr[1]);
            //Console.ReadKey();
        }

        public static void SmallestNumber()
        {
            int[] arr = new int[] { 7, 5, 8, 6, 9, 1 };

            int smallNumber = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < smallNumber)
                {
                    smallNumber = arr[i];
                }
            }
            Console.WriteLine("Smallest number is : {0}", smallNumber);
            Console.ReadKey();
        }

        public static void RemoveConsecutiveCharacterPairs()
        {
            //string inputStr = "saabbs";
            string inputStr = "aaabbbccc";
            int length = inputStr.Length - 1;
            string result = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= length; i++)
            {
                if (i == length)
                {
                    result += inputStr[length];
                    //stringBuilder.Append(inputStr[length].ToString());
                }
                else
                {
                    if (inputStr[i] != inputStr[i + 1])
                    {
                        result += inputStr[i];
                        //stringBuilder.Append(inputStr[i].ToString());
                    }
                }
            }

            //string str = "aaabbbccc";
            //string str1 = "";
            //string[] arr = str.Split(new string[] { "" }, StringSplitOptions.None);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!str1.EndsWith(arr[i]))
            //    {
            //        str1 += arr[i];
            //    }

            //}

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static void CharacterRepatingMaximumTimes()
        {
            string input = "aabbbbbcAAAhhhhhhhd";
            //string input = "aabbbbbcAAA";

            int startIndex = 0;
            int maxTimes = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int numberofTimes = 0;
                int j = i + 1;
                for (j = i; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        numberofTimes++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (numberofTimes > maxTimes)
                {
                    maxTimes = numberofTimes + 1;
                    startIndex = i;
                }
                i = j;
            }
            Console.WriteLine("Start Index : {0} Number of times : {1}", startIndex, maxTimes);
            Console.ReadKey();
        }

        public static void FirstNonRepeativeChar()
        {
            //string input = "papaya";
            string input = "apple";
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                bool repeativeChar = false;
                for (int j = 0; j < input.Length; j++)
                {
                    if (i != j && input[i] == input[j])
                    {
                        repeativeChar = true;
                        break;
                    }
                }
                if (!repeativeChar)
                {
                    result = input[i].ToString();
                    break;
                }
            }
            Console.WriteLine("Non Repeative first char is {0}", result);
            Console.ReadKey();
        }
        public static void ReverseString()
        {
            string input = "abbc";
            string result = string.Empty;
            // int i = 0; int j = input.Length - 1;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i].ToString();
            }
            if (input == result)
            {
                Console.WriteLine("Palandrome string");
            }
            else
            {
                Console.WriteLine("Non Palandrome string");
            }
            Console.ReadKey();
        }

        public static void Pangram()
        {
            string input = "The quick brown fox jumps over the dog";
            //string input = "The quick brown fox jumps over the lazy dog";
            input = input.Replace(" ", "");
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (result.ToLower().IndexOf(input[i]) == -1)
                {
                    result += input[i].ToString().ToLower();
                }
            }
            if (result.Count() == 26)
            {
                Console.WriteLine("This is Pangram");
            }
            else
            {
                Console.WriteLine("This is not Pangram");
            }

            Console.ReadKey();
        }

        public static void PangramMissingLetters()
        {
            String s = "abcdefghijklmnopqrstuv";
            //String s = "abcd";
            s = s.ToLower();
            string result = string.Empty;
            for (int i = 97; i <= 122; i++)
            {
                bool isExists = false;
                for (int j = 0; j <= s.Length - 1; j++)
                {
                    if (i == s[j])
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                {
                    result += (char)i;
                }

            }
            Console.WriteLine("Result : {0}", result.ToString());
            Console.ReadKey();
        }

        public static void StringInputWithCount()
        {
            String s = "a";
            string result = string.Empty;
            //String s = "abcd";
            //s = s.ToLower();
            char currentCharcter = s[0];
            int count = 1;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (currentCharcter == s[i])
                {
                    count++;
                }
                else
                {
                    result += currentCharcter;
                    result += count;
                    currentCharcter = s[i];
                    count = 1;
                }
            }

            result += currentCharcter;
            result += count;
            Console.WriteLine("Result : {0}", result.ToString());
            Console.ReadKey();
        }

        public static void SumOfFibonacciSeries()
        {
            int input = 8;
            int firstNumber = 0;
            int secondnumber = 1;

            int sum = 0;

            while (firstNumber <= input)
            {
                sum += firstNumber;
                int nextNumber = firstNumber + secondnumber;
                firstNumber = secondnumber;
                secondnumber = nextNumber;
            }
            //int previous = 0;
            //string fibonacciNumbers = "01";
            //int fibonacciAdding = 1;
            //for (int i = 1; i < input; i++)
            //{
            //    fibonacciAdding += Convert.ToInt16(fibonacciNumbers[i - 1]) + Convert.ToInt16(fibonacciNumbers[i]);
            //    fibonacciNumbers += fibonacciAdding.ToString();

            //}
            Console.WriteLine("Result : {0}", sum);
            Console.ReadKey();
        }

        public static void Multiplication()
        {
            int a = 5;
            int b = 6;

            int result = 0;
            for (int i = 1; i <= b; i++)
            {
                result += a;
            }

            Console.WriteLine("Result : {0}", result);
        }

        public static void Division()
        {
            int a = 1;
            int b = 2;

            int result = 0;
            int divResult = 0;
            if (a > b && a > 0 && b > 0)
            {
                while (result < a)
                {
                    result += b;
                    divResult++;
                }
            }
            else
            {
                Console.WriteLine("Not a valid division number");
            }

            Console.WriteLine("Result : {0}", divResult);
        }

        public static void IsPrimeNumber()
        {
            bool isPrimeNumber = false;
            int number = 17;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                    isPrimeNumber = false;
            }
        }

        public static void Armstrong()
        {
            //bool isPrimeNumber = false;
            int number = 407;
            string num = number.ToString();
            int result = 0;
            foreach (char digiChar in num)
            {
                int digit = int.Parse(digiChar.ToString());
                result += (int)Math.Pow(digit, 3);
            }
            if (result == number)
            {
                Console.WriteLine("Is Armstrong Number");
            }
            else
            {
                Console.WriteLine("Is not a Armstrong Number");
            }
            //for (int i = 0; i <= num.Length; i++)
            //{
            //    int CountNumberOfTimes = 0;
            //    while(CountNumberOfTimes < 3)
            //    {
            //        result += result * Convert.ToInt32(num[i]);
            //    }
            //}

            //Console.WriteLine("The Armstrong value is : {0}", result);
        }

        public static void SortedLinkedList()
        {
            LinkedList<int> linkList = new LinkedList<int>();
            linkList.AddLast(1);
            linkList.AddLast(1);
            linkList.AddLast(2);
            linkList.AddLast(2);
            linkList.AddLast(3);
            linkList.AddLast(4);
            linkList.AddLast(4);
            linkList.AddLast(5);
            linkList.AddLast(6);

            List<int> list = new List<int>();
            list.Add(linkList.FirstOrDefault());
            int previousItem = linkList.FirstOrDefault();
            foreach (var item in linkList)
            {
                if (previousItem != item)
                {
                    previousItem = item;
                    list.Add(item);
                }
            }
            var outputList = list;

        }

        public static void FindMinimumNumber()
        {
            int[] arr = { 3, 4, 5, 1, 2 };
            int minNum = arr[0];
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (minNum > arr[i])
                {
                    minNum = arr[i];
                }
            }
            Console.WriteLine("Min Number {0}", minNum);
        }

        public static void FindReportingEmployee()
        {
            int inputEmployee = 9;
            Dictionary<int, List<int>> empList = new Dictionary<int, List<int>>();
            empList.Add(1, new List<int>() { 2, 3, 4});
            empList.Add(5, new List<int>() { 6, 7, 8 });
            empList.Add(9, new List<int>() { 10, 11, 12 });

            List<int> outputList = new List<int>();

            foreach(var item in empList)
            {
                if(item.Key == inputEmployee)
                {
                    outputList = item.Value;
                }
                else
                {
                    foreach(var valItem in item.Value)
                    {
                        if(inputEmployee == valItem)
                        {
                            outputList.Add(item.Key);
                        }
                    }
                }
            }
            foreach(var item in outputList)
            {
                Console.WriteLine("EmployeeReports to - {0} ", item);
            }
            Console.ReadKey();
        }

        public static void FloydTriangle()
        {
            int input = 5;
            int count = 0;
            for(int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(++count + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static void RobotFormat()
        {
            string input = "UDLRURLUDRL";
            int x = 0;
            int y = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'U')
                {
                    x++;
                }
                if (input[i] == 'D')
                {
                    --x;
                }
                if (input[i] == 'R')
                {
                    y++;
                }
                if (input[i] == 'L')
                {
                    --y;
                }
            }
            //Console.WriteLine("X axis is : {0} and Y axis is : {1} ", x, y);
            Console.WriteLine("New Integer[{0}, {1}]", x, y);
            Console.ReadKey();
        }

        public static void AverageAndGrade()
        {
            string[,] studentListArray = new string[,] { { "Bobby", "87", "83", "88", "85" }, { "Charles", "100", "94", "92", "90" }, { "David", "56", "58", "54", "59" } };

            for (int i = 0; i <= studentListArray.GetLength(0) - 1; i++)
            {
                var marks = 0;
                var average = 0;
                var studentName = studentListArray[i, 0];
                int numberOfRows = studentListArray.GetLength(1) - 1;
                for (int j = 1; j <= numberOfRows; j++)
                {
                    marks += Int32.Parse(studentListArray[i, j]);
                }
                average = marks / numberOfRows;
                //studentAverageDict[studentName] = marks;
                if (average > 90)
                {
                    Console.WriteLine(studentName + " has aquired Grade : " + "A");
                }

                else if (average > 80 && average < 90)
                {
                    Console.WriteLine(studentName + " has aquired Grade : " + "B");
                }

                else if (average < 60)
                {
                    Console.WriteLine(studentName + " has aquired Grade : " + "c");
                }
            }

        }

       
    }
}
