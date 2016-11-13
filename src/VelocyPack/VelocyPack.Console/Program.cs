﻿namespace VelocyPack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseArrayToSegment();

            System.Console.ReadLine();
        }

        static void ParseArrayToSegment()
        {
            // hex dump of [1, 2, 3]
            var arrayBytes = new byte[] { 0x02, 0x05, 0x31, 0x32, 0x33 };
            // parsed segment
            var arraySegment = VelocyPack.ToSegment(arrayBytes);

            PrintSegment(arraySegment);
        }

        static void PrintSegment(Segment segment, int indentLevel = 0)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                System.Console.Write("    ");
            }

            System.Console.WriteLine("{0} {1}->{2}: {3}", segment.ValueType, segment.StartIndex, segment.CursorIndex, segment.Type);

            if (segment.SubSegments != null)
            {
                indentLevel++;

                foreach (var subSegment in segment.SubSegments)
                {
                    PrintSegment(subSegment, indentLevel);
                }
            }
        }
    }
}