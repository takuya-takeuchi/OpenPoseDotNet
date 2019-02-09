using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static string[] GetFilesOnDirectory(string directoryPath, IEnumerable<string> extensions)
        {
            if (!extensions.Any())
                return new string[0];

            var exts = extensions.Select(s => $".{s}").ToArray();
            var list = Directory.EnumerateFiles(directoryPath).Where(s => exts.Contains(Path.GetExtension(s))).ToList();
            list.Sort();
            return list.ToArray();
        }

        public static string[] GetFilesOnDirectory(string directoryPath, string extension)
        {
            return GetFilesOnDirectory(directoryPath, new[] { extension });
        }

        public static string[] GetFilesOnDirectory(string directoryPath, Extensions extensions)
        {
            switch (extensions)
            {
                // Get files on directory with the desired extensions
                // Unknown kind of extensions
                case Extensions.Images:
                    {
                        var exts = new[]
                        {
                            // Completely supported by OpenCV
                            "bmp", "dib", "pbm", "pgm", "ppm", "sr", "ras",
                            // Most of them supported by OpenCV
                            "jpg", "jpeg", "png"
                        };
                        return GetFilesOnDirectory(directoryPath, exts);
                    }
                default:
                    throw new ArgumentOutOfRangeException($"Unknown kind of extensions (id = {extensions.ToString()}). Notify us of this error.");
            }
        }

        #endregion

    }

}
