using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    class Solver
    {
        public static List<Route> Solve(List<Route> testCase)
        {
            List<Route> solution = new List<Route>();

            Route r = new Route();
            r.Id = "1";
            r.DayNum = 1;
            r.Stops.AddRange(testCase.First().Stops);

            solution.Add(r);

            return solution;
        }
    }
}
