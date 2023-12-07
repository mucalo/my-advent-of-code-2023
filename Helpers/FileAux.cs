namespace AOC23.Helpers
{
    public static class FileAux
    {
        public const string PathToFile = @"..\..\..\Inputs\";

        public static string[] GetInputData(string filePath)
        {
            return File.ReadAllLines(PathToFile + filePath);
        }
    }
}
