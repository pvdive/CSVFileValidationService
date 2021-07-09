using System.Collections.Generic;
using System.IO;

namespace FormatValidator
{
    /// <summary>
    /// Provides configurable access to a file source.
    /// </summary>
    public class FileSourceReader : ISourceReader
    {
        private string _file;

        public FileSourceReader(string file)
        {
            _file = file;
        }

        public IEnumerable<string> ReadLines(string rowSeperator)
        {

            List<char> readCharacters = new List<char>();
            Queue<char> seperatorCheckQueue = new Queue<char>();

            using (StreamReader reader = new StreamReader(System.IO.File.OpenRead(_file)))
            {
                while (reader.Peek() >= 0)
                {
                    char current = (char)reader.Read();
                    seperatorCheckQueue.Enqueue(current);

                    if (seperatorCheckQueue.Count > rowSeperator.Length)
                    {
                        readCharacters.Add(
                            seperatorCheckQueue.Dequeue()
                            );
                    }

                    if (new string(seperatorCheckQueue.ToArray()) == rowSeperator)
                    {
                        yield return new string(readCharacters.ToArray());
                        readCharacters.Clear();
                        seperatorCheckQueue.Clear();
                    }
                }

                if (readCharacters.Count > 0)
                    yield return new string(readCharacters.ToArray());
            }
        }
    }
}
