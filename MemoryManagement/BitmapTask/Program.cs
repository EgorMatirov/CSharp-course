using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BitmapTask
{
    internal class Program
    {
        private static void FillBitmap(IBitmapEditor bitmapEditor)
        {
            for (var x = 0; x < bitmapEditor.Width; x++)
                for (var y = 0; y < bitmapEditor.Height; y++)
                    bitmapEditor.SetPixel(x, y, 255, 255, 255);
        }

        private static void Main()
        {
            const int width = 1000;
            const int height = 1000;
            var timer = new Timer.Timer();

            var bitmap = new Bitmap(width, height);

            using (timer.Start())
            {
                using (var bitmapEditor = new NaiveBitmapEditor(bitmap))
                {
                    FillBitmap(bitmapEditor);
                }
            }
            Console.WriteLine($"Naive: {timer.ElapsedMilliseconds}");

            using (timer.Start())
            {
                using (var bitmapEditor = new LockingBitmapEditor(bitmap))
                {
                    FillBitmap(bitmapEditor);
                }
            }
            Console.WriteLine($"Locking: {timer.ElapsedMilliseconds}");
        }
    }
}
