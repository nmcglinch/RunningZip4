using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoinPostal
{
	class Program
	{
		static string help = "Use -d to evaluate a directory, or -f to define a specific file";
		static string missingArgument = "In order to compute a result, an input path, and an output path are required.";
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine(help);
				return;
			}
			if (args.Length == 1)
			{
				if (args[0].Substring(1, 1) == Options.h.ToString())
				{
					Console.WriteLine(help);
					return;
				}
				else
				{
					Console.WriteLine("You provided the argument " + args[0] + " but did not specify input or output locations");
					Console.WriteLine(missingArgument);
					Console.WriteLine(help);
					return;
				}
			}
			if (args.Length != 3)
			{
				Console.WriteLine("You provided the argument " + args[0] + " but did not specify input or output locations");
				Console.WriteLine(missingArgument);
				Console.WriteLine(help);
				return;
			}

			Options choice;
			try
			{
				choice = (Options)Enum.Parse(typeof(Options), args[0].Substring(1, 1));
			}
			catch (Exception)
			{
				Console.WriteLine("You provided the argument " + args[0] + " which is not in the list of specified options.");
				Console.WriteLine(help);
				return;
			}
				
			switch (choice)
			{
				case Options.d: //directory
					Console.WriteLine("Directory");
					Console.WriteLine("Input " + args[1]);
					Console.WriteLine("Output " + args[2]);
					return;
				case Options.f: //file
					Console.WriteLine("FILE");
					Console.WriteLine("Input " + args[1] );
					Console.WriteLine("Output " + args[2]);
					if (convertFile(args[1], args[2]))
					{
						Console.WriteLine("Completed");
					}
					return;
				case Options.h:
					Console.WriteLine(help);
					return;
				default:
					Console.WriteLine("You provided the argument " + args[0] + " but did not specify input or output locations");
					Console.WriteLine(missingArgument);
					Console.WriteLine(help);
					return;

			}
		}
		public static bool convertFile(string input, string output)
		{
			if (System.IO.File.Exists(input))
			{
				if (!System.IO.File.Exists(output))
				{

					using (System.IO.StreamReader sr = new System.IO.StreamReader(new System.IO.FileStream(input,System.IO.FileMode.Open)))
					{
						delstat d = new delstat();
						d.ConvertToCSV(sr.ReadLine(), output);
					}
				}
				else
				{
					Console.Write("Destination file already existed aborting");
					return false;
				}
				return true;
			}
			else
			{
				Console.WriteLine("could not find input file");
				return false;
			}
		}

	}
}
