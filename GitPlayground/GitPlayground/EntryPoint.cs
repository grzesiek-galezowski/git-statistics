using System;
using System.Linq;
using GitPlayground;
using LibGit2Sharp;

internal static class EntryPoint
{
  public static void Main(string[] args)
  {
    //new GitRepositoryStatistics("E:\\grzes\\Documents\\GitHub\\tdd-toolkit\\").Gather();
    using (var repo = new Repository("E:\\grzes\\Documents\\GitHub\\tdd-toolkit\\"))
    {
      foreach (var entry in repo.Index)
      {
        var count = repo.Commits.QueryBy(entry.Path).Count();
        Console.WriteLine(count + " " + entry.Path);
      }
    }
  }
}