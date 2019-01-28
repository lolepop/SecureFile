msbuild securefile.sln /p:Configuration=Release /p:Platform=x86
ren build\securefile.exe "securefile x86.exe"
msbuild securefile.sln /p:Configuration=Release /p:Platform=x64