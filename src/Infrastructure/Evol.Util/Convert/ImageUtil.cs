using System.IO;

namespace Evol.Util.Convert
{
    /// <summary>
    /// 图片工具类
    /// </summary>
    public class ImageUtil
    {
        /// <summary>
        /// 图片转Base64字符串
        /// </summary>
        /// <param name="imageSteam">图片文件流</param>
        /// <returns></returns>
        public string ToBase64Str(MemoryStream imageSteam)
        {
            if (imageSteam.CanSeek)
                imageSteam.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[imageSteam.Length];
            imageSteam.Read(buffer, 0, (int)imageSteam.Length);
            var str = System.Convert.ToBase64String(buffer);
            return str;
        }

        /// <summary>
        /// 图片转Base64字符串
        /// </summary>
        /// <param name="imgPhyPath">图片物理路径</param>
        /// <returns></returns>
        public string ToBase64Str(string imgPhyPath)
        {
            if (!File.Exists(imgPhyPath))
                return string.Empty;
            var fileStream = File.OpenRead(imgPhyPath);
            if (fileStream.CanSeek)
                fileStream.Seek(0, SeekOrigin.Begin);

            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            var str = System.Convert.ToBase64String(buffer);
            return str;
        }


        /// <summary>
        /// 图片转Base64字符串
        /// </summary>
        /// <param name="base64Str">图片的base64字符串</param>
        /// <returns></returns>
        public MemoryStream ToImage(string base64Str)
        {
            var bytes = System.Convert.FromBase64String(base64Str);
            var ms = new MemoryStream(bytes);
            return ms;
        }
    }
}
