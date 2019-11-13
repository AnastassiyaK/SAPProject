namespace SAPBusiness.Tutorial
{
    using System.IO;

    public class MDFileCreator
    {
        public void SaveInFile(string fileName, Tutorial tutorial)
        {
            System.IO.File.WriteAllText($@"{Directory.GetCurrentDirectory()}\TestData\{fileName}.md", tutorial.ToString());
        }
    }
}
