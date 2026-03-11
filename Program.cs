using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig;

class Program
{
  public static void Main(string[] args)
  {  
    Console.WriteLine("Enter the path to your PDF:");
    string path = Console.ReadLine() ?? "";
    string content = ReadTextFromPdf(path);

    string[] boringWords = { "the", "is", "at", "and", "a", "of", "in", "to", "it", "i", "so",
  "furthermore", "moreover", "nevertheless", "consequently", 
  "although", "whereas", "however", "additionally", 
  "underneath", "between", "beside", "amongst", 
  "toward", "within", "upon", "amid", 
  "whom", "those", "each", "every", 
  "itself", "whose", "any", "such", 
  "initially", "generally", "specifically", "relatively", 
  "actually", "virtually", "partially", "normally", 
  "instance", "factor", "element", "aspect", 
  "method", "process", "utility", "standard" 
};
    string[] words = content.Split(' ');
    string result = "";

    foreach (string word in words)
    {
      if (boringWords.Contains(word.ToLower()))
      {
        result += word + " ";
      }
      else
      {
        result += new string('█', word.Length) + " ";
      }
    }

    Console.WriteLine(result);
  }

  static string ReadTextFromPdf(string filePath)
  {
    string text = "";
    using (PdfDocument document = PdfDocument.Open(filePath))
    {
      foreach (var page in document.GetPages())
      {
        text += page.Text;
      }
    }
    return text;
  }
}
