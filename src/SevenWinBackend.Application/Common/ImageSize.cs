using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Common
{
    /// <summary>
    /// 图片尺寸
    /// </summary>
    internal class ImageSize
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// 图片尺寸
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public ImageSize(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new Exception("图片尺寸不是正确的尺寸，必须大于0");
            }
            Width = width;
            Height = height;
        }


        /// <summary>
        /// 获取相同比率的图片尺寸
        /// </summary>
        /// <param name="sourceSize">原图片尺寸</param>
        /// <param name="maxSize">重设最大的图片尺寸</param>
        /// <returns>返回新的相同比率尺寸</returns>
        public static ImageSize GetSameRateSize(ImageSize sourceSize, ImageSize maxSize)
        {
            int newWidth = sourceSize.Width;
            int newHeight = sourceSize.Height;
            if (sourceSize.Width > maxSize.Width)
            {
                newWidth = maxSize.Width;
                newHeight = newWidth * sourceSize.Height / sourceSize.Width;
            }
            if (newHeight > maxSize.Height)
            {
                newHeight = maxSize.Height;
                newWidth = newHeight * sourceSize.Width / sourceSize.Height;
            }
            return new ImageSize(newWidth, newHeight);
        }
    }
}
