using EasySaveLib;
using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

static class DirectoryInfoController
{
    static long fileSize = 0;

    static int nomberOfFile = 0;

    static public int GetNomberOfFileInDirectory(DirectoryInfo Source)
    { 
        foreach (FileInfo File in Source.GetFiles()) 
        { 
            nomberOfFile++; 
        }
        foreach (DirectoryInfo subDir in Source.GetDirectories())
        {
            GetNomberOfFileInDirectory(subDir);
            
        }
        return nomberOfFile; 
    }

    static public long GetSizeOfFileInDirectory(DirectoryInfo Source)
    {
        foreach (FileInfo File in Source.GetFiles())
        {
            fileSize+= File.Length;
        }
        foreach (DirectoryInfo subDir in Source.GetDirectories())
        {
            GetSizeOfFileInDirectory(subDir);

        }
        return fileSize;
    }
}