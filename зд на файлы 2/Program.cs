using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            try
            {
                BinaryWriter fout = new BinaryWriter(new FileStream("binary.dat", FileMode.Create));
                int d = 0;
                int i = 1;
                while (i < 11)
                {
                    fout.Write(d); d += 1;
                    i++;
                }
                fout.Close();
                i = 0; FileStream f = new FileStream("binary.dat", FileMode.Open);
                BinaryReader fin = new BinaryReader(f);
                try
                {
                    while (true)
                    {
                        d = fin.ReadInt32();
                        i += d;
                    }
                }
                catch (EndOfStreamException)
                { 
                fin.Close(); f.Close();
                fout = new BinaryWriter(new FileStream("binary.dat", FileMode.Append));
                fout.Write(i);
                fout.Close(); Console.WriteLine("i= " + i);
                fin = new BinaryReader(new FileStream("binary.dat", FileMode.Open));
                for (int j = 0; j < 10; j++)
                {
                    d = fin.ReadInt32(); Console.Write(d + " ");
                }
                i = fin.ReadInt32();
                Console.WriteLine(); Console.WriteLine("сумма = " + i);
                fin.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error end: " + e.Message); return;
            }
        }
    }
}