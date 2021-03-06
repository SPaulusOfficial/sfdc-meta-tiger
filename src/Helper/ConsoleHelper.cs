﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Xml;

namespace MetaTiger.Helper
{
    class ConsoleHelper{

        public static void WriteDocLine(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            try
            {
               Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note 
            }
            catch (System.Exception)
            {
              Console.WriteLine(value); 
            }
            //Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
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
            try
            {
               Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note 
            }
            catch (System.Exception)
            {
              Console.WriteLine(value); 
            }
            //Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
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
            try
            {
               Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note 
            }
            catch (System.Exception)
            {
              Console.WriteLine(value); 
            }
            //Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
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
            try
            {
               Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note 
            }
            catch (System.Exception)
            {
              Console.WriteLine(value);  
            }
            //Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
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
            try
            {
               Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note 
            }
            catch (System.Exception)
            {
              Console.WriteLine(value); 
            }
            //Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
            //
            // Reset the color.
            //
            Console.ResetColor();
        }              
       
	}


	
}
