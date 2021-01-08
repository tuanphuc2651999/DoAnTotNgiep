using DevExpress.DocumentView;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liz.DoAn
{
    public static class FileUtils
    {
        private const int OrientationKey = 0x0112;
        private const int NotSpecified = 0;
        private const int NormalOrientation = 1;
        private const int MirrorHorizontal = 2;
        private const int UpsideDown = 3;
        private const int MirrorVertical = 4;
        private const int MirrorHorizontalAndRotateRight = 5;
        private const int RotateLeft = 6;
        private const int MirorHorizontalAndRotateLeft = 7;
        private const int RotateRight = 8;
        public static string FolderUploads
        {
            get
            {
                // Lay thong tin temp folder tu web.config
                string tempFolderUploads = "..\\..\\Uploads\\ImagesNV";
                // Tao thu muc temp folder neu khong ton tai
                if (!Directory.Exists(tempFolderUploads))
                {
                    Directory.CreateDirectory(tempFolderUploads);
                    // Khi lam viec voi System.IO can phai GC.Collect
                    GC.Collect();
                }

                // Tra ra duong dan vat ly cua temp Folder
                return tempFolderUploads;
            }
        }
        public static void SaveFile(string pathFile, string nameFile, PictureEdit image)
        {
            string destFile = Path.Combine(FileUtils.FolderUploads, nameFile);   
            if(File.Exists(destFile))
            {
                File.Delete(destFile);
            }    
            image.Image.Save(destFile, GetImageFormat(pathFile));
        }
        public static ImageFormat GetImageFormat(string sourceFile)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
            {
                return ImageFormat.Png;
            }

            string extension = Path.GetExtension(sourceFile).ToLower();

            if (extension.Contains("bmp"))
            {
                return ImageFormat.Bmp;
            }

            if (extension.Contains("emf"))
            {
                return ImageFormat.Emf;
            }
            if (extension.Contains("exif"))
            {
                return ImageFormat.Exif;
            }
            if (extension.Contains("gif"))
            {
                return ImageFormat.Gif;
            }
            if (extension.Contains("ico"))
            {
                return ImageFormat.Icon;
            }
            if (extension.Contains("jpeg") || extension.Contains("jpg"))
            {
                return ImageFormat.Jpeg;
            }
            if (extension.Contains("png"))
            {
                return ImageFormat.Png;
            }
            return ImageFormat.Jpeg;
        }

        public static void WriteContentToFile(IDocument doc, String path)
        {
/*
            String fileName = doc.Name;
            String file = Path.Combine(path, fileName);
            try
            {
                FileStream fs = new FileStream(file, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                Stream s = doc.AccessContentStream(0);
                byte[] data = new byte[s.Length];
                s.Read(data, 0, data.Length);
                s.Close();
                bw.Write(data);
                bw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }*/
        }
        public static Image StringToImage(string pathHinh)
        {
            try
            {
                FileStream stream = File.OpenRead(pathHinh);
                byte[] fileBytes = new byte[stream.Length];
                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(fileBytes));
                return img;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
   
}
