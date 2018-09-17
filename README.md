# 42projectGen
Generates a project folder with subfolders using your assets. 
It asks you the name of the project and generates the folder with that name.

The folder/subfolder format is this ->
ProjectName/assets/
ProjectName/headers/
ProjectName/src/
ProjectName/author*

When it generates the author file it uses the environmental variable USER.
If you want to generate project with your own files (like libraries) put them to the folder /assets/ in the executable

The program takes the files in the assets and sorts them.
Sorting :
*.c files -> src/
*.h files -> headers/
*.* files -> assets/

