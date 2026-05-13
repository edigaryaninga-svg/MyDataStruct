using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string postfix = "567*+1-";
        Stack<int> stack = new Stack<int>();

        foreach (char token in postfix)
        {
            if (char.IsDigit(token))
            {
                stack.Push(token - '0');
            }
            else
            {
                int right = stack.Pop();
                int left = stack.Pop();
                int result = 0;

                switch (token)
                {
                    case '+':
                        result = left + right;
                        break;
                    case '-':
                        result = left - right;
                        break;
                    case '*':
                        result = left * right;
                        break;
                    case '/':
                        result = left / right;
                        break;
                }

                stack.Push(result);
            }
        }

        Console.WriteLine("Result: " + stack.Pop());
    }
}