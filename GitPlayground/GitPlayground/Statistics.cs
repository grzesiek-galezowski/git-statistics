using System.Collections.Generic;
using System.Linq;
using NGit.Api;

namespace GitPlayground
{
  class Statistics
  {
    private readonly Git _git;
    public readonly Dictionary<string, int> _counts;

    public Statistics(Git git)
    {
      _git = git;
      _counts = new Dictionary<string, int>();
    }

    public void AddCommitCountFor(string relativeEntryPath)
    {
      var revCommitsCount = _git.Log().AddPath(relativeEntryPath).Call().Count();
      if (revCommitsCount != 0)
      {
        _counts[relativeEntryPath] = revCommitsCount;
      }
    }
  }
}