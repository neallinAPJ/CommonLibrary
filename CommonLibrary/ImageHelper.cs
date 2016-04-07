using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class ImageHelper
    {
        /// <summary>
        /// 横向合并图片
        /// </summary>
        /// <param name="imageRight">右边的图片</param>
        /// <param name="imageLeft">左边的图片</param>
        /// <returns>合拼和的图片</returns>
        public static Bitmap MergeImageHorizontal(Bitmap imageRight, Bitmap imageLeft)
        {
            if (imageRight == null && imageLeft == null)
            {
                return null;
            }
            else if (imageRight != null && imageLeft != null)
            {
                //确定图片合并后的高度和宽度
                Bitmap newBitmap = new Bitmap(imageRight.Width + imageLeft.Width, Math.Max(imageRight.Height, imageLeft.Height));
                Graphics g = Graphics.FromImage(newBitmap);
                g.DrawImage(imageRight, 0, 0);
                g.DrawImage(imageLeft, imageRight.Width, 0);
                g.Dispose();
                return newBitmap;
            }
            return null;
        }
        /// <summary>
        /// 纵向合并图片
        /// </summary>
        /// <param name="imageTop">顶部的图片</param>
        /// <param name="imageBottom">底部的图片</param>
        /// <returns>合拼和的图片</returns>
        public static Bitmap MergeImageVertical(Bitmap imageTop,Bitmap imageBottom)
        {
            if (imageTop == null && imageBottom == null)
            {
                return null;
            }
            else if (imageTop != null && imageBottom != null)
            {
                //确定图片合并后的高度和宽度
                Bitmap newBitmap = new Bitmap(Math.Max(imageTop.Width, imageBottom.Width), imageTop.Height + imageBottom.Height);
                Graphics g = Graphics.FromImage(newBitmap);
                g.DrawImage(imageTop, 0, 0);
                g.DrawImage(imageBottom,0, imageTop.Height);
                g.Dispose();
                return newBitmap;
            }
            return null;
        }
        /// <summary> 
        /// 字节流转换成图片 
        /// </summary> 
        /// <param name="byt">要转换的字节流</param> 
        /// <returns>转换得到的Image对象</returns> 
        public static Image ByteToImg(byte[] byt)
        {
            MemoryStream ms = new MemoryStream(byt);
            Image img = Image.FromStream(ms);
            return img;
        }
        /// <summary>
        ///  图片转换成字节流 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image img)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                byte[] imageBytes = new byte[ms.Length];
                ms.Read(imageBytes, 0, imageBytes.Length);
                return imageBytes;
            }
        }
        /// <summary>
        /// 读取等比例压缩后的图片长和宽
        /// </summary>
        /// <param name="b">需要被压缩的图片</param>
        /// <param name="destHeight">压缩后的高度</param>
        /// <param name="destWidth">压缩后的宽度</param>
        /// <returns>等比例压缩后的图片长和宽</returns>
        public static Range GetZipImageRange(Image b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight)
            {

            }
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Range range = new Range();
            range.Width = sW;
            range.Heigh = sH;
            return range;
        }
    }
}
