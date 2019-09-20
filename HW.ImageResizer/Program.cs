using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace HW.ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");

            ImageProcessAsync imageProcess = new ImageProcessAsync();

            //先清除原本資料夾得內容
            imageProcess.Clean(destinationPath);

            //取得效能數值
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //開始進行圖片
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0).Wait();

            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }
    }
}
