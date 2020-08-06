namespace Academits.Dorosh.CSV
{
    class CSVProgram
    {
        static void Main()
        {
            string input = "..\\..\\input.txt";

            string output = "..\\..\\output.html";

            CSVConverter.ToCSV(input, output);
        }
    }
}