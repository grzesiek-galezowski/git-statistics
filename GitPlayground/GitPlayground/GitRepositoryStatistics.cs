using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGit;
using NGit.Api;
using NGit.Storage.File;

namespace GitPlayground
{
  public class GitRepositoryStatistics
  {
    private readonly string _repoPath;

    public GitRepositoryStatistics(string repoPath)
    {
      _repoPath = repoPath;
      Statistics = new Statistics(Git.Open(repoPath));
    }

    private Statistics Statistics { get; }

    public void Gather()
    {
      foreach (var repoEntry in RepoEntry.AllRepoEntries(_repoPath))
      {
        if (repoEntry.IsVersioned())
        {
          if (repoEntry.IsFile())
          {
            repoEntry.AddCommitCountTo(Statistics);
          }
          else
          {
            if (repoEntry.IsDirectory())
            {
            }
          }
        }
      }

      Write(Statistics._counts);
    }

    private static void Write(Dictionary<string, int> counts)
    {
      foreach (var count in counts.OrderBy(kvp => kvp.Value).Reverse())
      {
        Console.WriteLine(count.Key + ": " + count.Value);
      }
    }
  }
}
