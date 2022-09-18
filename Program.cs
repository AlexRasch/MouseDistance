using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace MouseDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~* Enjoy *~~");
            
            POINT currentMousePosition, previousMousePosition;
            GetCursorPos(out previousMousePosition);
            double mouseDistance = 0;
            
            while (true)
            {
                
                
                GetCursorPos(out currentMousePosition);
                mouseDistance += Math.Sqrt(
                    Math.Pow(currentMousePosition.X - previousMousePosition.X, 2) +
                    Math.Pow(currentMousePosition.Y - previousMousePosition.Y, 2)
                    );
            
                Thread.Sleep(100);
                previousMousePosition = currentMousePosition;
                Console.Write($"\rMouse distance: {mouseDistance} ");
                
                // We could convert it to inch or cm if we want :)
                //Console.Write($"\rMouse distance: {ConvertDistance(mouseDistance):N} cm");
                
                
                // Wait for x movment then do
                //if (mouseDistance > 200)
                //{
                //
                //    
                //    Console.WriteLine();
                //    Console.WriteLine("Lets hack...");
                //    break;
                //
                //
                //}
            
            }

        }
        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }


        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        
        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
        
            return lpPoint;
        }

    }
}
