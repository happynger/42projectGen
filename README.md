# 42projectGen
Generates a project folder with subfolders using your assets. 
It asks you the name of the project and generates the folder with that name.

The folder/subfolder format is this ->

ProjectName/assets/

ProjectName/headers/

ProjectName/src/

ProjectName/author*

When it generates the author file it uses the environmental variable USER.

# Assets

If you want to generate project with your own files (like libraries) put them to the folder /assets/ in the executable

The program takes the files in the assets directory and sorts them.

Sorting :

*.c files -> src/

*.h files -> headers/

other files -> assets/

**The program also has an option to delete the already generated project _but it will delete everything in the folder_**
If you want to disable this feature you can do so in 'config.json' file by setting the 'delete:true' to 'delete:false'


# Bugs

Don't even mention it. I am not handling half of the errors I should currently. I am working on it.

# Source Structure
It ain't pretty to look at yet... keyword **_yet_**

Also I do not have 50 years of experience in C# so if you find something that could be done better I am down to change it!
