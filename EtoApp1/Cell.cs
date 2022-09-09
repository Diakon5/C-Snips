using System;
using System.Collections.Generic;

namespace EtoApp1
{
	public class Efficient2DArray<T>
	{
		int width;
		int height;
		public Efficient2DArray(int width, int height)
		{
			T[] data = new T[width * height];
			this.width = width;
			this.height = height;
		}
	}
}