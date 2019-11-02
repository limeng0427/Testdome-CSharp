/*
    Write a function that provides change directory (cd) function for an abstract file system.

    Notes:
    Root path is '/'.
    Path separator is '/'.
    Parent directory is addressable as "..".
    Directory names consist only of English alphabet letters (A-Z and a-z).
    The function should support both relative and absolute paths.
    The function will not be passed any invalid paths.
    Do not use built-in path-related functions.

    For example:
    Path path = new Path("/a/b/c/d");
    path.Cd("../x");
    Console.WriteLine(path.CurrentPath);
    should display '/a/b/c/x'. 
*/

using System;
using System.Collections.Generic;

public class Path
{
    public string CurrentPath { get; private set; }

    public Path(string path)
    {
        this.CurrentPath = path;
    }

    public void Cd(string newPath)
    {
        var regex = new Regex(@"(..)?\/?([a-z,A-Z])*(\/[a-z,A-Z])*");
        if (!regex.IsMatch(newPath))
            return;
        if (newPath[0] == '/')
        {
            CurrentPath = newPath;
        }
        else
        {
            LinkedList<string> folders = new LinkedList<string>(CurrentPath.Split('/'));
            folders.RemoveFirst();
            LinkedList<string> newFolders = new LinkedList<string>(newPath.Split('/'));
            foreach (var item in newFolders)
            {
                switch (item)
                {
                    case "..":
                        folders.RemoveLast();
                        break;
                    default:
                        folders.AddLast(item);
                        break;
                }
            }
            CurrentPath = "/" + string.Join("/", folders);
        }
    }

    public static void Main(string[] args)
    {
        var path = new Path("/a/b/c/d");
        path.Cd("../x");
        Console.WriteLine(path.CurrentPath); // result is "/a/b/c/x", if path.Cd("../../x") then result will be "/a/b/x"
    }
}
