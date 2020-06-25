using System;
using System.Collections.Generic;
namespace OOP_LAB_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write expression to read : ");
            string input = Console.ReadLine();
            var startex = new CompuondExpression();
            startex.value = input;
            startex.divide();
            
        }
    }


    abstract class Expression
    {
        public string value;
  
        abstract public void divide();
    }

    class Variable : Expression
    {
        public List<Expression> children = new List<Expression>();
        public override void divide()
        {
            
            for (int j = 1; j < value.Length; j++)
            {
                if (Char.IsDigit(value[j - 1]) && !Char.IsDigit(value[j]))
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("   *");
                    var lchiled = value.Substring(0, j);
                    var rchiled = value.Substring(j, value.Length - j);
                    var lex = new CompuondExpression();
                    var rex = new CompuondExpression();
                    lex.value = lchiled;
                    rex.value = rchiled;
                    children.Add(lex);
                    children.Add(rex);
                    Console.Write(lchiled);
                    Console.Write("    " + rchiled + "\n");
                    Console.WriteLine("---------------------");
                }
            }
        }
    }

    class CompuondExpression : Expression
    {
        
        public List<Expression> children = new List<Expression>();

        public void add(Expression ex)
        {
            children.Add(ex);
            
        }

        public void remove(Expression ex)
        {
            children.Remove(ex);
        }

        public void getChiledBySymbol(string sym)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("   " + sym);
            int i = value.IndexOf(sym);
            var lchiled = value.Substring(0, i);
            var rchiled = value.Substring(i + 1, value.Length - i - 1);

            Expression lex;
            if(lchiled.Contains('*') || lchiled.Contains('/') || lchiled.Contains('+') || lchiled.Contains('-'))
            {
                lex = new CompuondExpression();
            }
            else
            {
                lex = new Variable();
            }
            Expression rex;
            if (rchiled.Contains('*') || rchiled.Contains('/') || rchiled.Contains('+') || rchiled.Contains('-'))
            {
                rex = new CompuondExpression();
            }
            else
            {
                rex = new Variable();
            }
  
            lex.value = lchiled;
            rex.value = rchiled;

            children.Add(lex);
            children.Add(rex);
            Console.Write(lchiled);
            Console.Write("    " + rchiled  +"\n");
            Console.WriteLine("---------------------");
        }

        public override void divide()
        {
            if (value.Contains('+'))
            {
                getChiledBySymbol("+");

            }
            else if (value.Contains('-'))
            {
                getChiledBySymbol("-");


            }
            else if (value.Contains('*'))
            {
                getChiledBySymbol("*");


            }
            else if (value.Contains('/'))
            {
                getChiledBySymbol("/");

            }
            foreach (Expression child in children)
            {
                child.divide();
            }
        }
    }
}
