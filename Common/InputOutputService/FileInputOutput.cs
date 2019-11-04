//-----------------------------------------------------------------------
// <copyright file="FileInputOutput.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------

namespace Common
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class FileInputOutput : IInputOutput, IReaderGeneric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileInputOutput"/> class.
        /// </summary>
        /// <param name="inputFile">File for reading.</param>
        /// <param name="outputFile">File for writing.</param>
        public FileInputOutput(string inputFile, string outputFile)
        {
            this.InputFile = inputFile;
            this.OutputFile = outputFile;
        }

        /// <summary>
        /// Gets or sets the file for reading data .
        /// </summary>
        public string InputFile { get; set; }

        /// <summary>
        /// Gets or sets the file for writing data.
        /// </summary>
        public string OutputFile { get; set; }

        /// <summary>
        /// Reads the data from the file.
        /// </summary>
        /// <returns> The next line of characters from the file.</returns>
        public string Read()
        {
            string line;

            using (StreamReader r = new StreamReader(this.InputFile))
            {
                // while ((line = r.ReadLine()) != null)
                //{
                //Console.WriteLine(line);
                //}
                line = r.ReadToEnd();
            }

            return line;
        }

        /// <summary>
        /// Reads the data from the file
        /// and constructs object of a specified class type.
        /// </summary>
        /// <returns> The the specified type of inValue string representation.</returns>
        public T Read<T>()
            where T : class
        {
            if (!File.Exists(this.InputFile))
            {
                throw new FileNotFoundException("This file was not found.");
            }

            T obj;
            using (FileStream fs = new FileStream(this.InputFile, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                obj = (T)formatter.Deserialize(fs);
            }

            return obj;
        }

        /// <summary>
        /// Writes the specified data to the file.
        /// </summary>
        /// <param name="obj">The value parameter.</param>
        public void Write(object obj)
        {
            if (!File.Exists(this.OutputFile))
            {
                throw new FileNotFoundException("This file was not found.");
            } 

            using (StreamWriter outputFile = new StreamWriter(this.OutputFile, true))
            {
                outputFile.WriteLine(obj);
            }
        }
    }
}
