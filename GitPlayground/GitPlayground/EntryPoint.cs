using GitPlayground;

internal static class EntryPoint
{
  public static void Main(string[] args)
  {
    new GitRepositoryStatistics("E:\\grzes\\Documents\\GitHub\\tdd-toolkit\\").Gather();
  }
}