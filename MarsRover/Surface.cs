using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Surface
    {
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>Set the surface size</summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Surface(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
