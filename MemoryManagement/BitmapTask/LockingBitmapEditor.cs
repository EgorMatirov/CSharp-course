using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BitmapTask
{
    public class LockingBitmapEditor : IDisposable, IBitmapEditor
    {
        private readonly Bitmap _bitmap;
        private readonly BitmapData _bitmapData;
        private readonly byte[] _rgbValues;

        public LockingBitmapEditor(Bitmap bitmap)
        {
            _bitmap = bitmap;
            var rect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
            _bitmapData = _bitmap.LockBits(rect, ImageLockMode.ReadWrite, _bitmap.PixelFormat);

            var bytes = _bitmapData.Stride*_bitmap.Height;
            _rgbValues = new byte[bytes];

            Marshal.Copy(_bitmapData.Scan0, _rgbValues, 0, bytes);
        }

        public int Width => _bitmap.Width;
        public int Height => _bitmap.Height;

        public void Dispose()
        {
            Marshal.Copy(_rgbValues, 0, _bitmapData.Scan0, _rgbValues.Length);
            _bitmap.UnlockBits(_bitmapData);
        }

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            const int channels = 4;
            var startOfPixelData = (y*_bitmap.Width + x)*channels;
            var newPixelData = new byte[] {r, g, b, 255};
            Array.Copy(newPixelData, 0, _rgbValues, startOfPixelData, channels);
        }
    }
}