using System;
using System.Drawing;

namespace BitmapTask
{
    public class NaiveBitmapEditor : IDisposable, IBitmapEditor
    {
        private readonly Bitmap _bitmap;

        public NaiveBitmapEditor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public int Width => _bitmap.Width;
        public int Height => _bitmap.Height;

        public void Dispose() {}

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            _bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
        }
    }
}