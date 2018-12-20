using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace imagesharp_test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Image.Load(string path) is a shortcut for our default type. 
            // Other pixel formats use Image.Load<TPixel>(string path))
            using (Image<Rgba32> image = Image.Load("foo.jpg"))
            {
                image.Mutate(x => x
                    .Resize(image.Width / 2, image.Height / 2)
                    .Grayscale());
                image.Save("bar.jpg"); // Automatic encoder selected based on extension.
            }
        }
    }
}
