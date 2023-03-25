Project Note.Database contains the tables and relations needed to create the Note Database.
Publish this project to create the database. 
TestData.sql contains the script to fill the database with test-data

To run this webservice create the file "secrets.json" (see secrets.example.json)
Fill in the correct connection string to the database you just created

Open IIS and create a new website noteService. 
Optionaly add a hostname, that you also add to your hosts file

Create a new publish profile in Note.WebService that points to the just created site and publish Note.WebService
You should now be able to run the Note.WebService