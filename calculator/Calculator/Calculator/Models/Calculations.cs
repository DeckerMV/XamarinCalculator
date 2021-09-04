using System.Collections.Generic;

namespace Calculator.Models
{
     public static class Calculations
    {
        public static decimal CalculateInput(string input)
        {
            //the same input but splitted, so: "10+5" becomes ["10", "+", "5"]
            List<string> splittedInput = new List<string>();
            //stack for storing operators based on the RPN algorithm
            Stack<string> operatorStack = new Stack<string>();
            //the same splittedInput but formatted as PostFix, so: ["10", "+", "5"] becomes ["10", "5", "+"]
            List<string> splittedPostFixExp = new List<string>();

            void PopUntilLowerPrecedence(string token)
            {//function for poping the stack until the token has higher precedence than operatorStack.Peek()
                while (operatorStack.Count != 0)
                {
                    if ((token == "×" || token == "÷") && (operatorStack.Peek() == "+" || operatorStack.Peek() == "-"))
                    {//upcoming token has NOW greater precendence
                        break;
                    }
                    splittedPostFixExp.Add(operatorStack.Pop());
                }
                operatorStack.Push(token);
            }


            if (input.EndsWith("+") || input.EndsWith("-") || input.EndsWith("×") || input.EndsWith("÷"))
            {
                input = input.Remove(input.Length - 1);
            }
            else if (input.LastIndexOf("÷0") != -1)
            {
                input = input.Remove(input.LastIndexOf("÷"));
            }

            if (!(input.Contains("+") || input.Contains("-") || input.Contains("×") || input.Contains("÷")))
            {
                return decimal.Parse(input);
            }
            else
            {
                string strNumber = "";
                foreach (char theChar in input)
                {//looping through the string to append each operand and operator to the splittedInput List
                    if (theChar != '+' && theChar != '-' && theChar != '×' && theChar != '÷')
                    {
                        strNumber += theChar;
                    }
                    else
                    {
                        splittedInput.Add(strNumber);
                        splittedInput.Add(theChar.ToString());
                        strNumber = string.Empty;
                    }
                }
                splittedInput.Add(strNumber);

                //formatting the splittedInput to the PostFixed format
                foreach (string token in splittedInput)
                {
                    if (token != "+" && token != "-" && token != "×" && token != "÷") //isOperand
                    {
                        splittedPostFixExp.Add(token);
                    }
                    else
                    {
                        if (operatorStack.Count != 0)
                        {
                            if ((token == "×" || token == "÷") && (operatorStack.Peek() == "+" || operatorStack.Peek() == "-"))
                            {//upcoming token has greater precedence than top element on stack
                                operatorStack.Push(token);
                            }
                            else if ((token == "+" || token == "-") && (operatorStack.Peek() == "×" || operatorStack.Peek() == "÷"))
                            {//upcoming token has lower precedence than top element on stack
                                PopUntilLowerPrecedence(token);
                            }
                            else
                            {//upcoming token has the same precedence than top element on stack (basically the same as the previous condition)
                                PopUntilLowerPrecedence(token);
                            }
                        }
                        else
                        {
                            operatorStack.Push(token);
                        }
                    }
                }

                while (operatorStack.Count != 0)
                {//Poping each operator in the stack to the end of the PostFixExpression
                    splittedPostFixExp.Add(operatorStack.Pop());
                }

                //calculating result by using the PostFixExpression
                for (int i = 0; i < splittedPostFixExp.Count; i++)
                {
                    if (splittedPostFixExp[i] == "+" || splittedPostFixExp[i] == "-" || splittedPostFixExp[i] == "×" || splittedPostFixExp[i] == "÷")
                    {
                        decimal left = decimal.Parse(splittedPostFixExp[i - 2]);
                        decimal right = decimal.Parse(splittedPostFixExp[i - 1]);
                        decimal result = 0M;

                        switch (splittedPostFixExp[i])
                        {
                            case "+":
                                result = left + right;
                                break;
                            case "-":
                                result = left - right;
                                break;
                            case "×":
                                result = left * right;
                                break;
                            case "÷":
                                result = left / right;
                                break;
                        }

                        for (int j = i; j > i - 3; j--)
                        {
                            splittedPostFixExp.RemoveAt(j);
                        }

                        splittedPostFixExp.Insert(i - 2, result.ToString());

                        i = 0;
                    }
                }

                return decimal.Parse(splittedPostFixExp[0]);
            }
        }
    }
}
