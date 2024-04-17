using System;
using System.Xml.Linq;

/// <summary>
/// Provides logging functionality by writing messages to an XML file.
/// </summary>
public static class Logger
{
    private static string logFilePath = "log.xml";  // Path to the log file

    /// <summary>
    /// Static constructor to initialize the log file with a root XML element.
    /// </summary>
    static Logger()
    {
        // Initialize the log file with the root element
        var doc = new XDocument(new XElement("LogEntries"));
        doc.Save(logFilePath);
    }

    /// <summary>
    /// Logs a message with the current date and time to the XML log file.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Log(string message)
    {
        // Load the existing XML document
        var doc = XDocument.Load(logFilePath); // LINQ to XML loading

        // Create a new log entry element
        var logEntry = new XElement("LogEntry",
            new XAttribute("Date", DateTime.Now.ToString("o")),  // ISO 8601 format
            new XElement("Message", message)
        );

        // Add the new log entry to the root element
        doc.Root.Add(logEntry);

        // Save the changes back to the file
        doc.Save(logFilePath);
    }
}
