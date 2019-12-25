using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace cSharp8Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Indexes();
            Patterns();
            SpanTest();
            AsyncStream().GetAwaiter().GetResult();
        }

        static void Indexes()
        {
            Index myIndex1 = 2;
            var myIndex2 = ^2;
            var people = new[] {"Tom", "Bob", "Sam", "Kate", "Alice"};
            var peopleRange1 = people[^2..];
            var peopleRange3 = people[^3..^1];
            var selected1 = people[myIndex1];
            var selected2 = people[myIndex2];
            Console.WriteLine(selected1);
            Console.WriteLine(selected2);
            var peopleRange = people[1..4];
            string? st = null;
            foreach (var person in peopleRange)
            {
                Console.WriteLine(person);
            }
        }

        static void Patterns()
        {
            Console.WriteLine(GetWelcome("", ""));
        }

        static string GetWelcome(string lang, string daytime) => (lang, daytime) switch
        {
            ("english", "morning") => "Good morning",
            ("english", "evening") => "Good evening",
            ("german", "morning") => "Guten Morgen",
            ("german", "evening") => "Guten Abend",
            _ => "Здрасьть"
        };

        static void SpanTest()
        {
            int[] temperatures =
            {
                10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
                18, 16, 15, 16, 17, 14, 9, 8, 10, 11,
                12, 14, 15, 15, 16, 15, 13, 12, 12, 11
            };
            Span<int> temperaturesSpan = temperatures;

            var firstDecade = temperaturesSpan.Slice(0, 10);

            temperaturesSpan[0] = 25;
            Console.WriteLine(firstDecade[0]);
        }

        static async Task AsyncStream()
        {
            await foreach (var number in GetNumbersAsync())
            {
                Console.WriteLine(number);
            }
        }

        static async IAsyncEnumerable<int> GetNumbersAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
}