using System.Collections.Generic;

namespace FormatValidator
{
    public interface ISourceReader
    {
        IEnumerable<string> ReadLines(string rowSeperator);
    }
}
