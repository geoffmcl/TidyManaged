using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyManaged;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test1 app. started...");
            // Note mistakes in html
            using (Document doc = Document.FromString("<html><title>test</tootle><body>asd</body>"))
            {
                doc.ShowWarnings = false;
                doc.Quiet = true;
                // doc.OutputXhtml = true;
                doc.CleanAndRepair();
                string parsed = doc.Save();
                Console.WriteLine(parsed);
            }
            Console.WriteLine("Test1 app. ending...");
        }
    }
}
