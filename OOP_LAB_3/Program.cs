using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool RUN = true;
            while (RUN)
            {

                Context context = new Context();
                Console.WriteLine("Write elements of A plurality: ");
                string inputA = Console.ReadLine();
                Console.WriteLine("Write elements of B plurality: ");
                string inputB = Console.ReadLine();
                Console.WriteLine("Write elements of U plurality: ");
                string inputU = Console.ReadLine();

                List<string> A = inputA.Split(" ").ToList();
                List<string> B = inputB.Split(" ").ToList();
                List<string> U = inputU.Split(" ").ToList();

                Console.WriteLine("Operation : ");

                string inputOP = Console.ReadLine();

                if (inputOP == "AND")
                {
                    context.setOperation(new AND_Operation());
                }
                else if (inputOP == "OR")
                {
                    context.setOperation(new OR_Operation());
                }
                else if (inputOP == "EQUALS")
                {
                    context.setOperation(new EQUALS_Operation());
                }
                else if (inputOP == "NOT")
                {
                    context.setOperation(new NOT_Operation());
                }
                else if (inputOP == "CONTAINS")
                {
                    context.setOperation(new CONTAINS_Operation());
                }
                else if (inputOP == "COMPARISON")
                {
                    context.setOperation(new COMPARISON_Operation());
                }
                else if (inputOP == "COMPOUND")
                {
                    context.setOperation(new COMPOUND_Operation());
                }
                else
                {
                    Console.WriteLine("NO SUCH A OPERATION");
                }

                List<string> result = context.executeOperation(A, B, U);

                Console.WriteLine("RESULT: ");
                Console.Write("( ");
                foreach (string el in result)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine(" )");
                Console.Clear();
            }
        }
    }

    abstract class Operation
    {
        public abstract List<string> execute(List<string> A, List<string> B, List<string> U);
    }

    class AND_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            List<string> C = new List<string>();
            
            foreach(string a in A)
            {
                foreach(string b in B)
                {
                    if(a == b && !C.Contains(a))
                    {
                        C.Add(a);
                    }
                }
            }

            return C;
        }
    }

    class OR_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            List<string> C = new List<string>();

            foreach (string a in A)
            {
                C.AddRange(A);
                C.AddRange(B);
                C = C.Distinct().ToList();
            }

            return C;
        }
    }

    class EQUALS_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            bool A_EQUALS(string s)
            {
               return B.Contains(s);
            }
            bool B_EQUALS(string s)
            {
                return A.Contains(s);
            }
            List<string> C = new List<string>();
            if (A.TrueForAll(A_EQUALS) && B.TrueForAll(B_EQUALS))
            {
                C.Add("True");
            }
            else
            {
                C.Add("False");
            }

            return C;
        }
    }

    class NOT_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            List<string> C = new List<string>();

            C = U.Except(A).ToList();

            return C;
        }
    }

    class CONTAINS_Operation : Operation
    {
        
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            bool Contains(String s)
            {
                return B.Contains(s);
            }

            List<string> C = new List<string>();

            if (A.TrueForAll(Contains))
            {
                C.Add("True");
            }
            else
            {
                C.Add("False");
            }

            return C;
        }
    }

    class COMPARISON_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            List<string> C = new List<string>();

            A = A.Distinct().ToList();
            B = B.Distinct().ToList();

            if(A.Count() > B.Count())
            {
                C.Add("A > B");
            }
            else if (A.Count() < B.Count())
            {
                C.Add("A < B");
            }
            else
            {
                C.Add("A and B are even");
            }
            return C;
        }
    }

    class COMPOUND_Operation : Operation
    {
        public override List<string> execute(List<string> A, List<string> B, List<string> U)
        {
            List<string> C = new List<string>();

            C.AddRange(A);
            C.AddRange(B);

            return C;
        }
    }

    class Context
    {
        private Operation operation;

        public void setOperation(Operation op)
        {
            operation = op;
        }

        public List<string> executeOperation(List<string> A, List<string> B, List<string> U)
        {
            return operation.execute(A,B,U);
        }
    }
}
