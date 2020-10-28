using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using testCase.Services;

namespace testCase.Models
{
    public class PolishSolver : IPolishSolver
    {
        static char Separator = ' ';
        static List<char> Operators = new List<char>("+-*/^");
        public double? Calculate(string data)
        {
            var stack = new Stack<double>();
            string buff = "";
            for (var i = 0; i < data.Length; i++)
            {
                if (Operators.Contains(data[i]))
                {
                    try
                    {
                        var right = stack.Pop();
                        var left = stack.Pop();
                        var operator_impl = Operation(data[i]);
                        var result = operator_impl(left, right);
                        stack.Push(result);
                    }
                    catch
                    {
                        return null; // not enough operands stored in stack, bad expression
                    }
                }
                else if (data[i] == Separator)
                {
                    if (!string.IsNullOrEmpty(buff))
                    {
                        if (!double.TryParse(buff, out double num))
                        {
                            return null;    // bad char in expression
                        }
                        stack.Push(num);
                        buff = "";
                    }
                }
                else if (!char.IsDigit(data[i]) && data[i] != '.')
                {
                    return null; // bad char in expression
                }
                else buff += data[i]; // accumulate current reading number
            }
            if (stack.Count != 1)
            {
                return null;    // not completed expression
            }
            return stack.Pop();
        }

        public static Func<double, double, double> Operation(char symbol)
        {
            switch (symbol)
            {
                case '+':
                    {
                        return (x, y) => x + y;
                    }
                case '*':
                    {
                        return (x, y) => x * y;
                    }
                case '/':
                    {
                        return (x, y) => x / y;
                    }
                case '-':
                    {
                        return (x, y) => x - y;
                    }
                case '^':
                    {
                        return Math.Pow;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
