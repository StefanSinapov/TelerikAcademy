namespace MatrixTraversers
{
    using System;
    using log4net;
    using log4net.Config;

    internal class WalkInMatrixTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WalkInMatrixTest));

        internal static void Main()
        {
            BasicConfigurator.Configure();
            

            byte matrixSize = ReadInput();
            var generatedMatrix = MatrixTraversal.GenerateMatrix(matrixSize);
            PrintMatrixOnConsole(generatedMatrix);
            log.Debug("success");
        }

        private static byte ReadInput()
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();

            byte n;
            while (!byte.TryParse(input, out n) || n <= 0 || n > 100)
            {
                Console.WriteLine(" - Invalid input: You haven't entered a correct positive number!");
                input = Console.ReadLine();
            }

            return n;
        }

        private static void PrintMatrixOnConsole(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}