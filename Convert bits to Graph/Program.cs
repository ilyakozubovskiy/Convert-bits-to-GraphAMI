using System.Text;

namespace Converter
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
           
            Console.Write("Enter bitset:");
            string? source = Console.ReadLine();
           
            StringBuilder sourceBuilder = new StringBuilder();
            StringBuilder bits = new StringBuilder(source);
            Console.WriteLine("AMI:");
           
            for (int i = 0; i < source?.Length; i++)
            {
                sourceBuilder.Append(' ');
                sourceBuilder.Append(source[i]+ " ");
            }

            BuildAmi(source, bits);
            Console.WriteLine(sourceBuilder);
            Console.WriteLine(bits +"\n");
            
            Main();
        }
        
        public static void BuildAmi(string? source,StringBuilder bits)
        {
            bool signal = true;
            for (int i = 0, j = 0; i < source?.Length; i++, j += 3)
            {
                if (source[i] == '0')
                {
                    bits.Remove(j, 1);
                    bits.Insert(j, "---");
                }
                else if (source[i] == '1')
                {
                    bits.Remove(j, 1);
                    bits.Insert(j, signal ? "¯¯¯" : "___");
                    signal = !signal;
                }
                else
                {
                    Console.WriteLine("Bitset is incorrect");
                    Main();
                }
            }
        }
    }
}