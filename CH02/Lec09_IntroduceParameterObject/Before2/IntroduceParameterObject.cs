using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Edge
    {
        public double Width { get; }
        public Point Start { get; }
        public Point End { get; }

        public Edge(double width, Point start, Point end)
        {
            Width = width;
            Start = start;
            End = end;
        }
    }

    public class IntroduceParameterObjectExamples
    {
        public void DrawEdge(Graphics graphics, Edge edge)
        {
            graphics.SetStokeWidth(edge.Width);
            graphics.DrawLine(edge.Start.X, edge.Start.Y, edge.End.X, edge.End.Y);
        }

        public void DrawEdgeCall(Graphics graphics)
        {
            var start = new Point(0.0, 0.0);
            var end = new Point(100.0, 0.0);
            var edge = new Edge(2.0, start, end);
            DrawEdge(graphics, edge);
        }
    }

    public class DateTimeRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateTimeRange(DateTime start, DateTime end) 
        {
            Start = start;
            End = end;
        }

        public bool Contains(DateTime time)
        {
            return time == Start ||
                   time == End ||
                   time > Start && time < End;
        }
    }

    public class LogFile
    {
        List<LogEvent> logEvents = new List<LogEvent>();

        public IEnumerable<LogEvent> GetEvents(DateTimeRange range)
        {
            var result = new List<LogEvent>();
            foreach (var logEvent in logEvents)
            {
                if (range.Contains(logEvent.Time))
                    result.Add(logEvent);
            }
            return result;
        }

        public void RemoveEvents(DateTimeRange range)
        {
            var result = new List<LogEvent>();
            var count = logEvents.Count;
            for (var i = count - 1; i >= 0; i--)
            {
                var logEvent = logEvents[i];
                if (range.Contains(logEvent.Time))
                {
                    result.RemoveAt(i);
                }
            }
        }
    }
}