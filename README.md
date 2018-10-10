# 42projectGen

Generates a project folder with subfolders using your assets.
It asks you the name of the project and generates the folder with that name.

The folder/subfolder format is this ->

ProjectName/assets/

ProjectName/headers/

ProjectName/src/

ProjectName/author*

When it generates the author file it uses the environmental variable USER.

## Assets

If you want to generate project with your own files (like libraries) put them to the folder /assets/ in the executable

The program takes the files in the assets directory and sorts them.

Sorting :

*.c files -> src/

*.h files -> headers/

other files -> assets/

## Bugs

Don't even mention it. I am not handling half of the errors I should currently. I am working on it.

## Source Structure

It ain't pretty to look at yet... keyword **_yet_**

Also I do not have 50 years of experience in C# so if you find something that could be done better I am down to change it!

## How to use

If you want to run executable just go into the folder /Executable and run the ./generator

The first time you run it it will generate a `config.json` file that you can change to your hearts content.

**The program also has an option to delete the already generated project _but it will delete everything in the folder_**
If you want to disable this feature you can do so in `config.json` file by setting the `delete:true` to `delete:false`

## Source

If you would like to try fixing or even working the source file is there.

**If you are planing on working on any of the lab's machines you will need to install _brew_**

For instructions about brew slack marvin `!brew`

[Openssl](http://brewformulas.org/Openssl)

[dotnet_install_script](https://dot.net/v1/dotnet-install.sh)

Here is the command I used for the dotnet_install

```sh
sh dotnet-install.sh --channel Current --install-dir ~/.brew/opt/
cd ~/.brew/bin
ln -s ~/.brew/opt/dotnet/dotnet dotnet
```

With this your dotnet will be installed all you need to do is open your IDE of choise (Mine is Visual Studio Code with C# ext) and program!

[Here is the link to the dotnet api](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet?tabs=netcore21)
