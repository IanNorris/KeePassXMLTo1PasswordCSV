using System.IO;
using System.Xml.Linq;

namespace KeePassXMLTo1PasswordCSV
{
	class Program
	{
		static string ToCsv(string Input)
		{
			return $"\"{Input.Replace("\"", "\"\"")}\"";
		}

		static void Main(string[] args)
		{
			string JsonData = File.ReadAllText(args[0]);
			string OutputDir = Path.GetDirectoryName(args[0]);

			string OutputPasswords = Path.Combine(OutputDir, "1PasswordImport_Passwords.csv");
			string PasswordsFile = "";

			//Passwords format:
			//title,website,username,password,notes,Associated Email,Secondary Login, custom field 3, custom field 4, etc

			var PasswordsList = XElement.Load(args[0]);
			var Passwords = PasswordsList.Descendants("pwentry");
			foreach( var Password in Passwords )
			{
				string OutTitle = ToCsv(Password.Element("title").Value.Trim());
				string OutUsername = ToCsv(Password.Element("username").Value.Trim());
				string OutUrl = ToCsv(Password.Element("url").Value.Trim());
				string OutPassword = ToCsv(Password.Element("password").Value.Trim());
				string OutNotes = ToCsv(Password.Element("notes").Value.Trim());
				string OutGroup = ToCsv("Group:"+Password.Element("group").Value.Trim());

				PasswordsFile += $"{OutTitle},{OutUrl},{OutUsername},{OutPassword},{OutNotes},,,{OutGroup}\r\n";
			}

			File.WriteAllText(OutputPasswords, PasswordsFile);
		}
	}
}
