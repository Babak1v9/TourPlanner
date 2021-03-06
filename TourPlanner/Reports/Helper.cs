using System.IO;
using System.Windows.Media.Imaging;

namespace TourPlanner.Reports {
    public class Helper {
        public static BitmapImage LoadImage(byte[] imageData) {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData)) {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static byte[] ImageToByteArray(BitmapImage img) {
            using (var stream = new MemoryStream()) {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add((BitmapFrame.Create(img)));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
