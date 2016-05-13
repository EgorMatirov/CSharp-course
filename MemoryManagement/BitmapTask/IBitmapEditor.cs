namespace BitmapTask
{
    public interface IBitmapEditor
    {
        void SetPixel(int x, int y, byte r, byte g, byte b);
        int Width { get; }
        int Height { get; }
    }
}