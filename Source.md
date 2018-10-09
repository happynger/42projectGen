# Source

If you would like to try fixing or even working the source file is there. Msg me if you would like to get the makefile for dotnet commands.

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