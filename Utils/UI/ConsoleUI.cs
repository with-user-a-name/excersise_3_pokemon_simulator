using System;

namespace Utils.UI
{


    public class ConsoleUI
    {
        //private int SavedLeftPos { get; set; }
        //private int SavedTopPos { get; set; }


        //public ConsoleUI()
        //{
        //    SavedTopPos = Console.CursorTop;
        //    SavedLeftPos = Console.CursorLeft;
        //}


        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }


        public void PressAnyKeyToContinue()
        {
            WrLn("");
            Wr("Press any key to continue...");
            Console.ReadKey();
        }


        public void Wr(string message)
        {
            Console.Write(message);
        }


        public void WrLn(string message)
        {
            Wr(message + Environment.NewLine);
            //Console.WriteLine(message);
        }


        //public void RestoreCursorPos()
        //{
        //    Console.CursorTop = SavedTopPos;
        //    Console.CursorLeft = SavedLeftPos;
        //}


        //public void SaveCursorPos()
        //{
        //    SavedTopPos = Console.CursorTop;
        //    SavedLeftPos = Console.CursorLeft;
        //}
    }


}
