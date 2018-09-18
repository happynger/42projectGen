using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace generator
{
    class gen
    {
        static void Main(string[] args)
		{
			string input;
			string dir;
			char key;
			Item config = LoadJson();

			Console.Write("Input the name of the project - ");
			input = Console.ReadLine();
			dir = String.Concat("../", input, "/");

			if (config.delete)
			{
				Console.Write("Would you like to Generate or Delete project? (g/d) - ");
				key = (char)Console.Read();
				if (key == 'g' || key == 'G')
					Generate(dir, input);
				else if (key == 'd' || key == 'D')
				{
					DirectoryInfo dirInfo = new DirectoryInfo(dir);
					dirInfo.Delete(true);
				}
				else
					Console.WriteLine("This is not an option!");
			}
			else
				Generate(dir, input);
        }

		private static Item LoadJson()
		{
			if (!File.Exists(@"./config.json"))
				GenJson();
			using (StreamReader r = new StreamReader(@"config.json"))
			{
				string json = r.ReadToEnd();
				Item items = JsonConvert.DeserializeObject<Item>(json);
				return (items);
			}
		}

		private class Item
		{
			public bool delete = true;
		}

		private static void GenJson()
		{
			Item items = new Item
			{
				delete = true
			};

			using (StreamWriter sw = File.CreateText(@"./config.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(sw, items);
			}
		}

		private static void Generate(string dir, string input)
		{
			if (!Directory.Exists(dir))
				Create_Dir(dir);
			Create_aut(dir, input);
			if (!Directory.Exists(@"./assets/"))
				Directory.CreateDirectory(@"./assets/");
			else
				Move_assets(@"./assets/", dir);
			Console.WriteLine("The project was generated");
		}

		private static void Move_assets(string dir, string path)
		{
			string src;
			string end;
			string endDir;
			DirectoryInfo dirInfo = new DirectoryInfo(dir);
			FileInfo[] fileNames = dirInfo.GetFiles("*.*");
			foreach (FileInfo fi in fileNames)
			{
				if (fi.Name.Contains(".c"))
					endDir = "src/";
				else if (fi.Name.Contains(".h"))
					endDir = "headers/";
				else
					endDir = "assets/";
				src = Path.Combine(dir, fi.Name);
				end = Path.Combine(path + endDir, fi.Name);
				File.Copy(src, end);
			}
		}

		private static void Create_aut(string dir, string input)
		{
			File.WriteAllText(dir + "author", Environment.GetEnvironmentVariable("USER") + "\n");
			File.Create(dir + "src/" + input + ".c");
			File.Create(dir + "headers/" + input + ".h");
		}

		private static void Create_Dir(string dir)
		{
			Directory.CreateDirectory(dir + "assets");
			Directory.CreateDirectory(dir + "headers");
			Directory.CreateDirectory(dir + "src");
		}
    }
}
