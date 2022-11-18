using McMaster.Extensions.CommandLineUtils;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace lab2
{
    public class Program
    {

        [Option(ShortName = "i")]
        public string InputFile { get; }

        [Option(ShortName = "o")]
        public string OutputFile { get; }

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        private static int ConvertToInt32(string value)
        {
            bool parsed = Int32.TryParse(value, out int result);

            if (!parsed)
                throw new ArgumentException($"The value {value} was not parsed to int");

            return result;
        }

        private void OnExecute()
        {
            string strN = File.ReadAllText(InputFile);
            int N = ConvertToInt32(strN);

            if (!(1 <= N && N <= 1000))
            {
                throw new ArgumentException($"N must be >= 1 and <= 1000");
            }

            int res = (N + 1) * N / 2 + 1;

            File.WriteAllText(OutputFile, res.ToString());
        }
    }
}
