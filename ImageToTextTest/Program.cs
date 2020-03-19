using System;
using System.Drawing;
using System.Drawing.Imaging;
using Tesseract;

namespace ImageToTextTest
{
    class Program
    {
        static Rectangle pointFirstName = new Rectangle(366, 73, 726, 81);
        static Rectangle pointLastName = new Rectangle(425, 153, 676, 75);

        static string firstName = "";
        static string lastName = "";
        
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\SO\Desktop\ScanResults\IMG_20200318_0005.png";
            using (var engine = new TesseractEngine(@"./tessdata", "tur", EngineMode.Default))
            {

                using (Bitmap orjinalImage = new Bitmap(filePath))
                {
                    using (Bitmap firstNameImage = orjinalImage.Clone(pointFirstName, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    {
                        firstNameImage.Save("firstName.png", System.Drawing.Imaging.ImageFormat.Png);
                        using (var fImg = Pix.LoadFromFile("firstName.png"))
                        {
                            using (var result = engine.Process(fImg))
                            {
                                var resultText = result.GetText();
                            }
                        }
                    }

                    using (Bitmap lastNameImage = orjinalImage.Clone(pointLastName, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    {
                        lastNameImage.Save("lastName.png", System.Drawing.Imaging.ImageFormat.Png);
                        using (var fImg = Pix.LoadFromFile("lastName.png"))
                        {
                            using (var result = engine.Process(fImg))
                            {
                                var resultText = result.GetText();
                            }
                        }
                    }
                }

            }

            Console.WriteLine("Proccess Complated");
            Console.ReadLine();
        }
    }
}
