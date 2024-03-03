//Written by Software Engineer @Devflovv
using NUnit.Framework;
using System;
using System.IO;

namespace PhotoAlbumApp.Tests{
    public class ProgramTests
    {
         [SetUp]
        public void Setup()
        {
            // Output a message indicating that the test setup is being executed
            Console.WriteLine("Test setup is being executed...");
        }

        [Test]
        public static void Main_ValidInput_AlbumIdIsSet()
        {
           
            var input = "3"; 
            var reader = new StringReader(input);
            Console.SetIn(reader);

            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                var output = sw.ToString().Trim();

                Console.WriteLine('123');
                Assert.IsTrue(output.Contains("Photo-Album 3:")); 
                return;
            }
        }

        [Test]
        public void Main_InvalidInput_RetryPrompted()
        {
            
            var input = "invalid\n3"; 
            var reader = new StringReader(input);
            Console.SetIn(reader);

            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(null);
                var output = sw.ToString().Trim();

                
                Assert.IsTrue(output.Contains("Invalid input.")); // Check if retry prompt is shown
                Assert.IsTrue(output.Contains("Photo-Album 3:")); // Check if output contains the album ID after valid input
            }
        }
    }
}
