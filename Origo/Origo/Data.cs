using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    class Data
    {
        static Data()
        {
            Init();
        }

        private static string[] _rawTestCases { get; } = 
    new string[] { @"
1-1{1ABCDEF1}|
1-1{1FEDA1}|
6-1{1ABCDEF1}
" };

        private static string[] _rawTempates { get; } =
    new string[] { @"
1-1{1ABCDEFG1}
" };

        public static List<List<Route>> TestCases { get; private set; } = new List<List<Route>>();
        public static List<List<Route>> Templates { get; private set; } = new List<List<Route>>();

        private static void Init()
        {
            foreach(var testCase in _rawTestCases)
            {
                TestCases.Add(ParseRoutes(testCase));
            }
            foreach (var template in _rawTempates)
            {
                Templates.Add(ParseRoutes(template));
            }
        }

        private static List<Route> ParseRoutes(string testCase)
        {
            var result = new List<Route>();
            var routeStrings = testCase.Trim().Split('|').Select(s => s.Trim()).ToList();
            result =
                routeStrings.Select(routeString =>
                {
                    var route = new Route();

                    route.Id = routeString[0].ToString();
                    route.DayNum = int.Parse(routeString[2].ToString());
                    for (int i = 4; i < routeString.Length - 1; i++)
                    {
                        string stopString = routeString[i].ToString();
                        var stop = new Stop();
                        stop.Location = stopString;
                        route.Stops.Add(stop);
                    }

                    route.Stops.First().IsDepot = true;
                    route.Stops.Last().IsDepot = true;

                    return route;
                }).ToList();
            return result;
        }
    }
}
