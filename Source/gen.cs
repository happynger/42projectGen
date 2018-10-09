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
			string key;
			string deletion;

			if (!File.Exists(@"./config.json"))
			{
				GenJson();
				Console.WriteLine("The json file was generated you may now change its value");
				return;
			}
			Item config = LoadJson(); /* Loads Json file "config.json" */

			Console.Write("Input the name of the project - ");
			input = Console.ReadLine();
			dir = Path.Combine(config.output_path, input + "/"); /* Sets the dir to the output path of json */

			if (config.delete) /* Checks the config file for the delete option */
			{
				Console.Write("Would you like to Generate or Delete project? (g/d) - ");
				key = Console.ReadLine();
				if (key.CompareTo("g") == 0 || key.CompareTo("G") == 0)
					Generate(dir, input, config.assets, config);
				else if (key.CompareTo("d") == 0 || key.CompareTo("D") == 0)
				{
					Console.Write("Are you sure you want to delete '{0}' project? (yes/NO) - ", dir);
					deletion = Console.ReadLine();
					if (deletion == "yes" || deletion == "YES")
					{
						DirectoryInfo dirInfo = new DirectoryInfo(dir);
						dirInfo.Delete(true);
					}
					else if (deletion == "NO" || deletion == "no")
						return;
					else
						Console.WriteLine("That was not an option!");
				}
				else
					Console.WriteLine("This is not an option!");
			}
			else
				Generate(dir, input, config.assets, config);
        }

		private static Item LoadJson() /* Loads Json file into an Item object */
		{
			using (StreamReader r = new StreamReader(@"config.json"))
			{
				string json = r.ReadToEnd();
				Item items = JsonConvert.DeserializeObject<Item>(json);
				return (items);
			}
		}

		private class Item /* Object I use for the Json file */
		{
			public bool delete = true; /* Setting to remove the delete functionality */
			public bool AuthorOn = true;
			public bool AssetsOn = true;
			public bool HeadersOn = true;
			public bool SrcOn = true;
			public bool SrcPregen = true;
			public bool HeadersPregen = true;
			public string assets = "./assets/"; /* Setting to set your own assets folder path */
			public string output_path = "../../"; /* Setting for the output path */
		}

		private static void GenJson() /* Generates JSON file based on the class ITEM */
		{
			Item items = new Item{};

			using (StreamWriter sw = File.CreateText(@"./config.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Formatting = Formatting.Indented;
				serializer.Serialize(sw, items);
			}
		}

		private static void Generate(string dir, string input, string assets_dir, Item config) /* Main Heart of the program. Generates everything */
		{
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			Create_Dir(dir, config);
			Create_aut(dir, input, config);
			if (config.AssetsOn)
			{
				if (!Directory.Exists(assets_dir))
					Directory.CreateDirectory(assets_dir);
				else 
					Move_assets(assets_dir, dir, config);
			}
			Console.WriteLine("The project was generated");
		}

		private static void Move_assets(string dir, string path, Item config) /* Copies and moves all the files in the ./assets to their appropriate folders. @path is the end path, @dir is directory to internal assets */
		{
			string src;
			string end;
			string endDir;

			DirectoryInfo dirInfo = new DirectoryInfo(dir); /* Opens the @dir (assets) */
			FileInfo[] fileNames = dirInfo.GetFiles("*.*"); /* Reads all the files in the @dir */
			foreach (FileInfo fi in fileNames)
			{
				if (fi.Name.Contains(".c"))
				{
					if (config.SrcOn)
						endDir = "src/";
					else
						endDir = "/";
				}
				else if (fi.Name.Contains(".h"))
				{
					if (config.HeadersOn)
						endDir = "headers/";
					else
						endDir = "/";
				}
				else
				{
					if (config.AssetsOn)
						endDir = "assets/";
					else
						endDir = "/";
				}
				src = Path.Combine(dir, fi.Name);
				end = Path.Combine(path + endDir, fi.Name);
				File.Copy(src, end);
			}
		}

		private static void Create_aut(string dir, string input, Item config) /* Creates the Author file */
		{
			if (config.AuthorOn)
				File.WriteAllText(dir + "author", Environment.GetEnvironmentVariable("USER") + "\n");
			if (config.SrcPregen)
			{
				if (config.SrcOn)
					File.Create(dir + "src/" + input + ".c");
				else
					File.Create(dir + "/" + input + ".c");
			}
			if (config.HeadersPregen)
			{
				if (config.HeadersOn)
					File.Create(dir + "headers/" + input + ".h");
				else
					File.Create(dir + "/" + input + ".h");
			}
		}

		private static void Create_Dir(string dir, Item config) /* Creates all of the subDirectories */
		{
			if (config.AssetsOn == true)
				Directory.CreateDirectory(dir + "assets");
			if (config.HeadersOn == true)
				Directory.CreateDirectory(dir + "headers");
			if (config.SrcOn == true)
				Directory.CreateDirectory(dir + "src");
		}
    }
}
