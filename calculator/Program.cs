using System;
using System.Collections.Generic;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string exp = "((3+7)-3*4)/2+6"; //56*29-+.
            var ans = infixToPostfix(exp);
            var result = CalculatePostfix(ans);
            Console.WriteLine(result);
        }

        private static string infixToPostfix(string exp) 
        {
            Stack<char> stack = new Stack<char>();

            var examples = exp.ToCharArray();

            string result = "";

            foreach(var item in examples)
            {  
                if (item != ')' && item != '(' && item != '+' && item != '-' && item != '*' && item != '/') 
                { 
                    result = result + item;
                } 

                else if (item == '(') 
                { 
                    stack.Push(item); 
                } 
    
                //  If the scanned character is an ')', pop and output from the stack   
                // until an '(' is encountered.  
                else if (item == ')') 
                { 
                    while (stack.Count > 0 && stack.Peek() != '(') 
                    {
                        result = result + stack.Pop();
                    } 
    
                    if (stack.Count > 0 && stack.Peek() != '(') 
                    { 
                        throw new ArgumentException("invalid expression "); 
                    } 
                    else
                    { 
                        stack.Pop(); 
                    } 
                } 
                else // an operator is encountered 
                { 
                    while (stack.Count > 0 && Priorities(item) <= Priorities(stack.Peek())) 
                    { 
                        result = result + stack.Pop();
                    } 
                    stack.Push(item); 
                } 
            }
            // pop all the operators from the stack  
            while (stack.Count > 0) 
            { 
                result = result + stack.Pop();
            } 
    
            return result; 
        }

        private static int CalculatePostfix(string postfix)
        {
            Stack<int> answer = new Stack<int>();
            var post = postfix.ToCharArray();

            foreach (var item in post)
            {
                if (item == '+' || item == '-' || item == '/' || item == '*')
                {
                    var x = answer.Peek();
                    answer.Pop();

                    var y = answer.Peek();
                    answer.Pop();

                    answer.Push(Operator(item, y, x));
                }
                else
                {
                    answer.Push(Int32.Parse(item.ToString()));
                }
            }

            return answer.Peek();
        }

        private static int Operator(char oper, int x, int y)
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

        private static int Priorities(char ch) 
        { 
            switch (ch) 
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
            return -1; 
        } 
    }
}
