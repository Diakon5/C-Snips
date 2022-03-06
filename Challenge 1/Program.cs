using System;
namespace Challenge1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main()
        {
            ArrayMatrix matrix = new();
            matrix.Initialize();
        }
    }
    class ArrayMatrix
    {
        static readonly int size = 11;
        private float[] matrix = new float[size*size];

        public void Initialize()
        {
            Random random = new();
            for (int i = 0; i < matrix.Length; ++i)
            {
                if (i % size == 0 &&i!=0)
                {
                    Console.Write("\n");
                }
                matrix[i] = (float)random.NextDouble();
                //matrix[i] =(float) i / 100;
                Console.Write("{0:F2} ", matrix[i]);                
            }
            Console.Write("\n\n\n");
            for (int i = 0; i < size / 2; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    //Console.WriteLine("{0:D} {1:D}",i * size + j,size*size-(i+1)*size+j);
                    float temp = matrix[i * size + j];
                    matrix[i * size + j] = matrix[size * size - (i + 1) * size + j];
                    matrix[size * size - (i + 1) * size + j] = temp;
                }
            }
            for (int i = 0; i < matrix.Length; ++i)
            {
                if (i % size == 0 && i != 0)
                {
                    Console.Write("\n");
                }
                Console.Write("{0:F2} ", matrix[i]);
            }
        }
    }
}