using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.XML;

namespace Salesforce_Package
{
    class ConsoleHelper{

        public static void WriteDocLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }   

        public static void WriteQuestionLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }    

         public static void WriteErrorLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }  

         public static void WriteDoneLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }  

        public static void WriteWarningLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }              
       
	}


	
}
