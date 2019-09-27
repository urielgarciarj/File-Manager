[1mdiff --git a/Practica1_SemSO/Form1.cs b/Practica1_SemSO/Form1.cs[m
[1mindex f4af19e..0f60ad4 100644[m
[1m--- a/Practica1_SemSO/Form1.cs[m
[1m+++ b/Practica1_SemSO/Form1.cs[m
[36m@@ -12,10 +12,10 @@[m [mnamespace Practica1_SemSO[m
 {[m
     public partial class Form1 : Form[m
     {[m
[31m-        static Image pila100 = Image.FromFile("C:/Users/Uriel/Desktop/Archivos_SO/Pila100chido.PNG");[m
[31m-        static Image pila75 = Image.FromFile("C:/Users/Uriel/Desktop/Archivos_SO/Pila75chido.PNG");[m
[31m-        static Image pila50 = Image.FromFile("C:/Users/Uriel/Desktop/Archivos_SO/Pila50chido.PNG");[m
[31m-        static Image pila25 = Image.FromFile("C:/Users/Uriel/Desktop/Archivos_SO/Pila25chido.PNG");[m
[32m+[m[32m        static Image pila100 = Image.FromFile("C:/Users/Uriel/Pictures/Pila100chido.PNG");[m[41m[m
[32m+[m[32m        static Image pila75 = Image.FromFile("C:/Users/Uriel/Pictures/Pila75chido.PNG");[m[41m[m
[32m+[m[32m        static Image pila50 = Image.FromFile("C:/Users/Uriel/Pictures/Pila50chido.PNG");[m[41m[m
[32m+[m[32m        static Image pila25 = Image.FromFile("C:/Users/Uriel/Pictures/Pila25chido.PNG");[m[41m[m
 [m
         public Form1()[m
         {[m
[36m@@ -38,7 +38,7 @@[m [mnamespace Practica1_SemSO[m
 [m
         private void Form1_Load(object sender, EventArgs e)[m
         {[m
[31m-           pictureBox1.Image = Image.FromFile("C:/Users/Uriel/Desktop/Archivos_SO/Pila100chido.PNG");[m
[32m+[m[32m           pictureBox1.Image = Image.FromFile("C:/Users/Uriel/Pictures/Windowschido.JPG");[m[41m[m
            pictureBox2.Image = pila100;[m
         }[m
 [m
[36m@@ -54,7 +54,7 @@[m [mnamespace Practica1_SemSO[m
                 pwr.BatteryLifeRemaining / 3600, (pwr.BatteryLifeRemaining % 3600) / 60);[m
             if(pwr.BatteryLifePercent <= 89)[m
             {[m
[31m-                pictureBox2.Image = 50;[m
[32m+[m[32m                pictureBox2.Image = pila50;[m[41m[m
             }[m
         }[m
     }[m
[1mdiff --git a/Practica1_SemSO/bin/Debug/Practica1_SemSO.exe b/Practica1_SemSO/bin/Debug/Practica1_SemSO.exe[m
[1mindex bb5ce21..91eaa71 100644[m
Binary files a/Practica1_SemSO/bin/Debug/Practica1_SemSO.exe and b/Practica1_SemSO/bin/Debug/Practica1_SemSO.exe differ
[1mdiff --git a/Practica1_SemSO/bin/Debug/Practica1_SemSO.pdb b/Practica1_SemSO/bin/Debug/Practica1_SemSO.pdb[m
[1mindex 1e6d222..48b2b7f 100644[m
Binary files a/Practica1_SemSO/bin/Debug/Practica1_SemSO.pdb and b/Practica1_SemSO/bin/Debug/Practica1_SemSO.pdb differ
[1mdiff --git a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.FileListAbsolute.txt b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.FileListAbsolute.txt[m
[1mindex fcaed74..e595da2 100644[m
[1m--- a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.FileListAbsolute.txt[m
[1m+++ b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.FileListAbsolute.txt[m
[36m@@ -31,3 +31,6 @@[m [mC:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File M[m
 C:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\obj\Debug\Practica1_SemSO.csproj.CoreCompileInputs.cache[m
 C:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\obj\Debug\Practica1_SemSO.exe[m
 C:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\obj\Debug\Practica1_SemSO.pdb[m
[32m+[m[32mC:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\bin\Debug\Practica1_SemSO.exe.config[m[41m[m
[32m+[m[32mC:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\bin\Debug\Practica1_SemSO.exe[m[41m[m
[32m+[m[32mC:\Users\Uriel\Documents\Materias\Sexto semestre\Sem. Sistemas Operativos\File Manager\File-Manager\Practica1_SemSO\bin\Debug\Practica1_SemSO.pdb[m[41m[m
[1mdiff --git a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.GenerateResource.cache b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.GenerateResource.cache[m
[1mindex f2c44b0..ddb17d1 100644[m
Binary files a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.GenerateResource.cache and b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csproj.GenerateResource.cache differ
[1mdiff --git a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csprojAssemblyReference.cache b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csprojAssemblyReference.cache[m
[1mindex 14e764c..5af2662 100644[m
Binary files a/Practica1_SemSO/obj/Debug/Practica1_SemSO.csprojAssemblyReference.cache and b/Practica1_SemSO/obj/Debug/Practica1_SemSO.csprojAssemblyReference.cache differ
[1mdiff --git a/Practica1_SemSO/obj/Debug/Practica1_SemSO.exe b/Practica1_SemSO/obj/Debug/Practica1_SemSO.exe[m
[1mindex bb5ce21..91eaa71 100644[m
Binary files a/Practica1_SemSO/obj/Debug/Practica1_SemSO.exe and b/Practica1_SemSO/obj/Debug/Practica1_SemSO.exe differ
[1mdiff --git a/Practica1_SemSO/obj/Debug/Practica1_SemSO.pdb b/Practica1_SemSO/obj/Debug/Practica1_SemSO.pdb[m
[1mindex 1e6d222..48b2b7f 100644[m
Binary files a/Practica1_SemSO/obj/Debug/Practica1_SemSO.pdb and b/Practica1_SemSO/obj/Debug/Practica1_SemSO.pdb differ
