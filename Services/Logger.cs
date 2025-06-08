using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSimulator.Services
{
    public static class Logger
    {
        private static readonly List<string> logs = new();

        public static void Log(string message)
        {
            logs.Add($"[{DateTime.Now:T}] {message}");
        }

        public static void ShowLastLogs(int count = 5)
        {
            Console.WriteLine("\nRecent Logs:");
            foreach (var log in logs.TakeLast(count))
            {
                Console.WriteLine(log);
            }
        }

        public static IEnumerable<string> FilterLogs(string keyword)
        {
            return logs.Where(log => log.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
