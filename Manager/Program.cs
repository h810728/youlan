using HW.ImageResizer;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class Program
    {
        static void Main(string[] args)
        {

            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            ImageProcess imageProcess = new ImageProcess();
            ImageProcessAsync imageProcessAsync = new ImageProcessAsync();
            //先清除原本資料夾得內容
            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();
            var timeSync = sw.ElapsedMilliseconds;
            Console.WriteLine($"同步版時間: {sw.ElapsedMilliseconds} ms");

            sw.Reset();

            imageProcessAsync.Clean(destinationPath);
            sw.Start();
            imageProcessAsync.ResizeImages(sourcePath, destinationPath, 2.0).Wait();
            sw.Stop();
            var timeAsync = sw.ElapsedMilliseconds;
            Console.WriteLine($"非同步版時間: {sw.ElapsedMilliseconds} ms");

            var comparison = ((double)(timeSync - timeAsync) / timeSync) * 100;
            Console.WriteLine($"節省: {comparison:N2} % 時間");

            Console.ReadLine();
        }
    }
}
