﻿/* ==============================================================================
 * 类名称：KenceryValidateCode
 * 类描述：生成验证码
 * 创建人：jason
 * 创建时间：2013/10/13 22:33:55
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace OIU.CorporateWebsite.Common
{
    /// <summary>
    ///     build Validate Code
    /// </summary>
    public class KenceryValidateCode
    {
        /// <summary>
        ///     验证码的最大长度
        /// </summary>
        public int MaxLength
        {
            get { return 10; }
        }


        /// <summary>
        ///     验证码的最小长度
        /// </summary>
        public int MinLength
        {
            get { return 1; }
        }


        /// <summary>
        ///     生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            var randMembers = new int[length];

            var validateNums = new int[length];

            string validateNumberStr = "";

            //生成起始序列值

            var seekSeek = unchecked((int) DateTime.Now.Ticks);

            var seekRand = new Random(seekSeek);

            int beginSeek = seekRand.Next(0, Int32.MaxValue - length*10000);

            var seeks = new int[length];

            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;

                seeks[i] = beginSeek;
            }

            //生成随机数字

            for (int i = 0; i < length; i++)
            {
                var rand = new Random(seeks[i]);

                int pownum = 1*(int) Math.Pow(10, length);

                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }

            //抽取随机数字

            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();

                int numLength = numStr.Length;

                var rand = new Random();

                int numPosition = rand.Next(0, numLength - 1);

                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }

            //生成验证码

            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }

            return validateNumberStr;
        }


        //C# MVC 升级版

        /// <summary>
        ///     创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            var image = new Bitmap((int) Math.Ceiling(validateCode.Length*12.0), 22);

            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器

                var random = new Random();

                //清空图片背景色

                g.Clear(Color.White);

                //画图片的干扰线

                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);

                    int x2 = random.Next(image.Width);

                    int y1 = random.Next(image.Height);

                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                var font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));

                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                    Color.Blue, Color.DarkRed, 1.2f, true);

                g.DrawString(validateCode, font, brush, 3, 2);

                //画图片的前景干扰点

                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);

                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线

                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存图片数据

                var stream = new MemoryStream();

                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流

                return stream.ToArray();
            }

            finally
            {
                g.Dispose();

                image.Dispose();
            }
        }


        /// <summary>
        ///     得到验证码图片的长度
        /// </summary>
        /// <param name="validateNumLength">验证码的长度</param>
        /// <returns></returns>
        public static int GetImageWidth(int validateNumLength)
        {
            return (int) (validateNumLength*12.0);
        }


        /// <summary>
        ///     得到验证码的高度
        /// </summary>
        /// <returns></returns>
        public static double GetImageHeight()
        {
            return 22.5;
        }
    }
}