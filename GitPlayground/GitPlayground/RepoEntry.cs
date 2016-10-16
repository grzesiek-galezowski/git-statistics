using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitPlayground
{
  internal class RepoEntry
  {
    private readonly string _entry;
    private readonly string _normalizedEntry;

    public RepoEntry(string entry, string repoPath)
    {
      _entry = entry;
      _normalizedEntry = entry
        .Replace(repoPath, "")
        .Replace("\\", "/");
      RepoPath = repoPath;
    }

    public bool IsVersioned()
    {
      return !_normalizedEntry.StartsWith(".git/");
    }

    public bool IsFile()
    {
      return File.Exists(_entry);
    }

    public void AddCommitCountTo(Statistics statistics)
    {
      statistics.AddCommitCountFor(_normalizedEntry);
    }

    public bool IsDirectory()
    {
      return Directory.Exists(_entry);
    }

    public readonly string RepoPath;

    public static IEnumerable<RepoEntry> AllRepoEntries(string repoPath)
    {
      return Directory
        .EnumerateFileSystemEntries(repoPath, "*", SearchOption.AllDirectories)
        .Select(e => new RepoEntry(e, repoPath));
    }
  }
}