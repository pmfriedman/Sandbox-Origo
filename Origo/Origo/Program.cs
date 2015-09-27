using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Origo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunReporter();   
            ReadLine();
        }

        public static void RunReporter()
        {
            WriteLine(Reporter.ReportDiff(Data.TestCases.First(), Data.Templates.First()));
        }

        public static void RunSolver()
        {
            int ix = 1;
            foreach (var testCase in Data.TestCases)
            {
                WriteLine($"Test Case {ix}");
                foreach (var r in testCase)
                {
                    WriteLine(r.SummaryString);
                }

                WriteLine($"Solution");
                foreach (var r in Solver.Solve(testCase))
                {
                    WriteLine(r.SummaryString);
                }
                WriteLine("-----------------------------");

                ix++;
            }
        }
    }
}
