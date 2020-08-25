# MiniQuiz
This project is a Quiz application developed using ASP.NET Core 3.1.

The Script for the database can be found in the folder "DbScript" in project MiniQuiz.

After cloning the project and running the database script, don't forget to change the "data source" of the connectionStrings in the appsettings.jdon file to point to 
your own database.

The Admin has the ability to Create, Edit and Delete Questions. 
NOTE: A maximum of 10 Questions are allowed only but can be changed easily to suit your demands.
To get to the Admin part, navigate to /Admin or https://localhost:{portNumer}/Admin, you will need to create an account or register an account before proceeding.

The User can answers the Questions and get a result after answering all the Questions.
All the activities of the Admin i.e Creating, Updating or Deleting Questions will reflect on the Users part also.

