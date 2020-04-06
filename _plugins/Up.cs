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
    getDirectories("./_site/");
    string[] directoryArray = directoryList.ToArray();
    foreach(var directory in directoryArray)
    {
      File.Copy("./index.html", directory + "/index.html", true);
      Console.WriteLine("Index added to " + directory);
    }
	}
  public void getDirectories(string root)
  {
    try
    {
      foreach (string directory in Directory.GetDirectories(root))
      {
        directoryList.Add(directory);
        getDirectories(directory);
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }
}
