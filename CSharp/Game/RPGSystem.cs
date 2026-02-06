namespace TextRPG.Game
{
    class RPGSystem
    {
        //시스템 문구 공통
        private static void WriteWithColor(string text, ConsoleColor color = ConsoleColor.White, bool newLine = true)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = prevColor;
        }



        // 시스템 유저입력
        public static string GetUserResponse()
        {
            WriteWithColor("[USER]", newLine: false);
            return Console.ReadLine();
        }

        public static void EmptyLine() => Console.WriteLine("");
        public static void ConsoleWrite(object word) => Console.WriteLine(word);
        public static void Message(object word) => WriteWithColor($"[SYS]{word}", ConsoleColor.Yellow);
        public static void Warn(object word) => WriteWithColor($"[SYS]{word}", ConsoleColor.Cyan);
        public static void Alert(object word) => WriteWithColor($"[SYS]{word}", ConsoleColor.Red);

    }
}
