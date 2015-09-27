using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origo
{
    class Reporter
    {
        public static string ReportDiff(List<Route> history, List<Route> templates)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var t in templates)
            {
                var matches = history.Where(h => h.Id == t.Id && h.DayNum == t.DayNum).ToList();
                sb.AppendLine("##############################");
                sb.AppendLine();
                sb.Append(ReportDiff(matches, t));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static string ReportDiff(List<Route> history, Route template)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Template DAY:{template.DayNum} ID:{template.Id}");

            foreach(var stop in template.Stops)
            {

                if (stop.IsDepot)
                {
                    sb.AppendLine($"{stop.Location}");
                }
                else
                {
                    double routeAffinity = 0;
                    double sequenceAffinity = 0;
                    double buddyAffinity = 0;

                    
                    var matches = history.Select(r => r.StopsString).Where(r => r.Contains(stop.Location)).ToList();

                    if (matches.Count > 0)
                    {
                        routeAffinity = 100 * (double)matches.Count / (double)history.Count;

                        double templateSequence = template.StopsString.IndexOf(stop.Location);
                        double avgSequence = matches.Average(m => m.IndexOf(stop.Location));
                        double offset = Math.Abs(templateSequence - avgSequence);
                        double normalizedOffset = offset / template.StopsString.Length;
                        sequenceAffinity =  100 * (1.0 - normalizedOffset);

                        char previousStop = template.StopsString[(int)templateSequence - 1];
                        var prevBuddyMatches = matches.Where(m => m[m.IndexOf(stop.Location) - 1] == previousStop).ToList();
                        char nextStop = template.StopsString[(int)templateSequence + 1];
                        var nextBuddyMatches = matches.Where(m => m[m.IndexOf(stop.Location) + 1] == nextStop).ToList();
                        double avgBuddyMatches = ((double)prevBuddyMatches.Count + (double)nextBuddyMatches.Count) / 2.0;
                        buddyAffinity = 100.0 * avgBuddyMatches / (double)matches.Count;
                    }
                    sb.Append($"{stop.Location}  ");
                    sb.Append($"Route Match: {((int)routeAffinity).ToString().PadLeft(3)}%  ");
                    sb.Append($"Sequence Match: {((int)sequenceAffinity).ToString().PadLeft(3)}%  ");
                    sb.Append($"Buddy Match: {((int)buddyAffinity).ToString().PadLeft(3)}%  ");
                    sb.AppendLine();
                }


            }

            sb.AppendLine("----------------");
            sb.AppendLine("Matching History...");
            foreach(var r in history)
            {
                sb.AppendLine(r.SummaryString);
            }
            return sb.ToString();
        }
    }
}
