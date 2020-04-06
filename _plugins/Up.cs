using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;

public class ChannelManager
{
  public static List<string> directoryList = new List<string>();
	public void Main(string[] args)
	{
		Console.WriteLine("Plugin is ready.");
    getDirectories("./");
    string[] directoryArray = directoryList.ToArray();
    foreach(var directory in directoryArray)
    {
      File.Copy("./index.html", directory + "/index.html", false);
      Console.WriteLine("Index added to " + directory);
    }
	}
  public void getDirectories(string root)
  {
    try
    {
      foreach (string directory in Directory.GetDirectories(root))
      {
        if(directory[2] != '.')
        {
          directoryList.Add(directory);
          getDirectories(directory);
        }
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }
}
