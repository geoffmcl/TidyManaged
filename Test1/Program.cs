/* 
 * Test1 Project - Program.cs - HTML Parser
 * 
 * (c) 2016 (W3C) MIT, ERCIM, Keio University
 * See tidy.h for the copyright notice.
 *
 * Uses 'TidyManaged.dll`, loading 'tidy.dll' - Paths must 
 * be set appropriately.
 * 
 */

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
                doc.ShowWarnings = false;   // these do not seem to work???
                doc.Quiet = true;
                // doc.OutputXhtml = true; // does not seem to work?
                doc.CleanAndRepair();
                string parsed = doc.Save();
                Console.WriteLine(parsed);
            }
            Console.WriteLine("Test1 app. ending...");
        }
    }
}
