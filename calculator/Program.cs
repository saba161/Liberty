using System;
using System.Collections.Generic;
using System.Linq;

namespace ostrov2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> number = new Stack<int>();
            Stack<char> operators = new Stack<char>();

            var s = "1+2*(3+4/2-(1+2))*2+1".ToCharArray();

            foreach(var item in s)
            {
                if(item == '+' || item == '-' || item == '/' || item == '*' || item == '(' || item == ')')
                {
                    if(operators.Count() != 0)
                    {
                        if(Priorities(operators.Peek()) < Priorities(item) || item == '(' || item == ')')
                        {
                            operators.Push(item);
                        }
                        else
                        {
                            int x = number.Peek();
                            number.Pop();
                            int y = number.Peek();
                            number.Pop();
                            int result = Operator(operators.Peek(), y, x);
                            operators.Pop();
                            number.Push(result);
                            operators.Push(item);
                        }
                    }
                    else
                    {
                        operators.Push(item);
                    }
                }
                else
                {
                    number.Push(int.Parse(item.ToString()));
                }
            }
        }
        public static void Chek(char item)
        {
            
        }

        public static int Priorities(char oper)
        {
            switch(oper)
            {
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
            }

            return 0;
        }

        public static int Operator(char oper, int x, int y)
        {
            switch(oper)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '*':
                    return x * y;
                case '/':
                    return x / y; 
            }
            throw new ArgumentException("Unexpected operator string: " + oper);
        }
    }
}
