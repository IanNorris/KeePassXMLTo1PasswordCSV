# KeePassXMLTo1PasswordCSV
A simple tool to convert the KeePass XML export file format to 1Password's CSV import format.

I wrote this because the output from KeePass doesn't match the expected input for import into 1Password.

The project has no dependencies and is only a few lines long.

Usage:
* Build from source - I wouldn't trust binaries to handle my passwords from a random on the internet, so I doubt you would either! Built with VS2017, should compile fine with VS2019 too.
* Pause backups - you don't want your passwords ending up in plain text in your backups
* Export from KeePass with the **'XML'** format option (File -> Export To -> XML File...)
* Pass the file to the tool as the only parameter (eg KeePassXMLTo1PasswordCSV.exe MyPasswords.xml)
* Converted CSV will be output to the same directory with the name 1PasswordImport_Passwords.csv
* Go to https://my.1password.com/, sign in and click your name in the top right. Click Import.
* Click **Other**
* Click the file at the bottom and browse to 1PasswordImport_Passwords.csv
* Validate that all your passwords were imported correctly.
* Re-enable backups.