using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystemUI
    {
        private static IList<Document> documents;

        static void Main()
        {
            documents = new List<Document>();
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddNewDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddNewDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddNewDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddNewDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddNewDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddNewDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (Document document in documents)
                {
                    Console.WriteLine(document);
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void AddNewDocument(Document document, string[] attributes)
        {
            string[] keyAndValue;
            foreach (string attribute in attributes)
            {
                keyAndValue = attribute.Split('=');
                document.LoadProperty(keyAndValue[0], keyAndValue[1]);
            }
            if (document.Name != null)
            {
                documents.Add(document);
                Console.WriteLine("Document added: " + document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool documentFound = false;
            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    IEncryptable encryptableDocument = document as EncryptableDocument;
                    if (encryptableDocument != null)
                    {                        
                        encryptableDocument.Encrypt();
                        Console.WriteLine("Document encrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + name);
                    }
                }
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool documentFound = false;
            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    IEncryptable encryptableDocument = document as EncryptableDocument;
                    if (encryptableDocument != null)
                    {
                        encryptableDocument.Decrypt();
                        Console.WriteLine("Document decrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + name);
                    }
                }
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool encryptableDocumentFound = false;
            foreach (Document document in documents)
            {
                IEncryptable encryptableDocument = document as EncryptableDocument;
                if (encryptableDocument != null)
                {
                    encryptableDocumentFound = true;
                    encryptableDocument.Encrypt();
                }
            }
            if (!encryptableDocumentFound)
            {
                Console.WriteLine("No encryptable documents found");
            }
            else
            {
                Console.WriteLine("All documents encrypted");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool documentFound = false;
            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    documentFound = true;
                    IEditable editableDocument = document as IEditable;
                    if (editableDocument != null)
                    {
                        editableDocument.ChangeContent(content);
                        Console.WriteLine("Document content changed: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + name);
                    }
                }
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }  
        }
    }
}