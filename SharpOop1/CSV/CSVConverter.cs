using System.IO;

namespace Academits.Dorosh.CSV
{
    class CSVConverter
    {
        public static void ToCSV(string input, string output)
        {
            using (StreamReader reader = new StreamReader(input))
            {
                using (StreamWriter writer = new StreamWriter(output))
                {
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head><title>Таблица</title></head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<table border=\"1\">");

                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.Write("<tr><td>");

                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (currentLine[i].Equals(','))
                            {
                                writer.Write("</td><td>");

                                continue;
                            }

                            if (currentLine[i].Equals('<'))
                            {
                                writer.Write("&lt");

                                continue;
                            }

                            if (currentLine[i].Equals('>'))
                            {
                                writer.Write("&gt");

                                continue;
                            }

                            if (currentLine[i].Equals('&'))
                            {
                                writer.Write("&amp");

                                continue;
                            }

                            if (currentLine[i].Equals('"'))
                            {
                                i++;

                                while (true)
                                {
                                    if (i >= currentLine.Length || currentLine[i].Equals('\n'))
                                    {
                                        writer.Write("<br/>");

                                        currentLine = reader.ReadLine();

                                        i = 0;

                                        continue;
                                    }

                                    if (currentLine[i].Equals('"') && i + 1 < currentLine.Length && currentLine[i + 1].Equals('"'))
                                    {
                                        i += 2;

                                        writer.Write("\"");

                                        continue;
                                    }

                                    if (currentLine[i].Equals('"'))
                                    {
                                        break;
                                    }

                                    writer.Write(currentLine[i]);

                                    i++;
                                }

                                continue;
                            }

                            writer.Write(currentLine[i]);
                        }

                        writer.WriteLine("</td></tr>");
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }
            }
        }
    }
}