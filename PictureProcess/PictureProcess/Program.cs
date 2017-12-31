using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PictureProcess
{
    class Program
    {
        static int Main(string[] args)
        {
            Bitmap pic = (Bitmap)Image.FromFile(args[0]);

            var startLine = 400;

            var targetFind = false;
            var targetX = 0;
            var targetY = 0;
            for (int i = startLine; i < pic.Height; i++) // Y
            {
                var baseColor = pic.GetPixel(0, i);
                for (int j = 0; j < pic.Width; j++) // X
                {
                    if (distance(pic.GetPixel(j, i), baseColor) > 20)
                    {
                        Console.WriteLine(string.Format("baseColor: {0}, Target: {1}, X {2}, Y {3}", 
                            baseColor.ToString(), pic.GetPixel(j, i).ToString(), j, i));
                        var playerColor = Color.FromArgb(54, 53, 67);
                        if (distance(pic.GetPixel(j, i), playerColor) < 50 
                            || distance(pic.GetPixel(j, i + 2), playerColor) < 50) // It's player's head
                        {
                            j += 80;
                            continue;
                        }

                        targetFind = true;
                        targetX = j;
                        targetY = i;
                        break;
                    }
                }
                if (targetFind) break;
            }

            targetY += 30;
            Console.WriteLine(string.Format("Target: X: {0}, Y: {1}", targetX, targetY));

            var startFind = false;
            var startX = 0;
            var startY = 0;
            for (int i = pic.Height -1; i > 0; i--) // Y
            {
                var baseColor = Color.FromArgb(56, 59, 102);

                if (targetX < 500)
                {
                    for (int j = 0; j < pic.Width; j++) // X
                    {
                        if (distance(pic.GetPixel(j, i), baseColor) < 20)
                        {
                            startFind = true;
                            startX = j;
                            startY = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = pic.Width - 1; j > 0; j--) // X
                    {
                        if (distance(pic.GetPixel(j, i), baseColor) < 20)
                        {
                            startFind = true;
                            startX = j;
                            startY = i;
                            break;
                        }
                    }
                }
                if (startFind) break;
            }

            startY -= 20;
            Console.WriteLine(string.Format("Start: X: {0}, Y: {1}", startX, startY));

            double dist = Math.Pow(Math.Pow(Math.Abs(startX - targetX), 2) + Math.Pow(Math.Abs(startY - targetY), 2), 0.5);
            Console.WriteLine(string.Format("Dist: {0}", dist));
            if (targetX < 500)
            {
                return (int)(dist * 1.392);
            }
            else
            {
                return (int)(dist * 1.375);
            }
        }

        static int distance(Color a, Color b)
        {
            return Math.Abs(a.R - b.R) + Math.Abs(a.G - b.G) + Math.Abs(a.B - b.B);
        }
    }
}
