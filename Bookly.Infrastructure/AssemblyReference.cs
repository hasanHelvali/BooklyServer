using System.Reflection;

namespace Bookly.Infrastructure;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
