using System.Collections.Generic;
using System.IO;

namespace FormatValidator
{
    /// <summary>
    /// Reads CSV content from a Stream.
    /// </summary>

    public class StreamSourceReader : ISourceReader
    {
        private Stream _stream;

        public StreamSourceReader(Stream stream)
        {
            _stream = stream;
        }

        public IEnumerable<string> ReadLines(string rowSeperator)
        {

            List<char> readCharacters = new List<char>();
            Queue<char> seperatorCheckQueue = new Queue<char>();

            using (StreamReader reader = new StreamReader(_stream))
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
