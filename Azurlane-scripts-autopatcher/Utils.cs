using System;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;

namespace Azurlane
{
    internal static class Utils
    {
        private const long BUFFER_SIZE = 4096;

        internal static void Command(string argument)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd";
                process.StartInfo.Arguments = $"/c {argument}";
                process.StartInfo.WorkingDirectory = PathMgr.Thirdparty();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();
            }
        }

        internal static void CreateZip(string zipFileName, string file)
        {
            using (var zip = Package.Open(zipFileName, FileMode.OpenOrCreate))
            {
                var fileName = ".\\" + Path.GetFileName(file);
                var uri = PackUriHelper.CreatePartUri(new Uri(fileName, UriKind.Relative));

                if (zip.PartExists(uri))
                    zip.DeletePart(uri);

                var part = zip.CreatePart(uri, "", CompressionOption.Normal);
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (var dest = part.GetStream())
                        CopyStream(fileStream, dest);
                }
            }
        }

        internal static void DeleteDirectory(string path)
        {
            foreach (var directory in Directory.GetDirectories(path))
                DeleteDirectory(directory);
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        internal static void Log(string message, Exception exception)
        {
            if (!File.Exists(PathMgr.Local("Logs.txt")))
                File.WriteAllText(PathMgr.Local("Logs.txt"), string.Empty);
            using (var streamWriter = new StreamWriter(PathMgr.Local("Logs.txt"), true))
            {
                streamWriter.WriteLine("=== START =================================================================================");
                streamWriter.WriteLine(message);
                streamWriter.WriteLine($"Date: {DateTime.Now.ToString()}");
                streamWriter.WriteLine($"Exception Message: {exception.Message}");
                streamWriter.WriteLine($"Exception StackTrace: {exception.StackTrace}");
                streamWriter.WriteLine("=== END ===================================================================================");
                streamWriter.WriteLine();
            }
            Program.ExceptionCount++;
        }

        private static void CopyStream(FileStream inputStream, Stream outputStream)
        {
            var bufferSize = inputStream.Length < BUFFER_SIZE ? inputStream.Length : BUFFER_SIZE;
            var buffer = new byte[bufferSize];
            var bytesRead = 0;
            long bytesWritten = 0;

            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesWritten += bufferSize;
            }
        }
    }
}