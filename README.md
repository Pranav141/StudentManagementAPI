# StudentManagementAPI
Welcome to my GitHub repository! This project was in my training phase @Cognizant. In this project we have to preform the following task
Create a RESTful web API that allows users to manage student data in a database. The API should support the following operations: 
•	Retrieve a list of all students [Done]
•	Retrieve a single student by ID [Done]
•	Add a new student [Done]
•	Update an existing student [Done]
•	Delete a student [Done]

The student should have the following attributes: 
•	Student ID (integer, primary key) 
•	Name (string) 
•	Email (string) 
•	Address (string) 
•	Age (integer) 
•	Gender (string) 
•	Phone number (string) 

Technical Requirements:=
• Use ASP.NET Web API to implement the RESTful API. [Done]
•	Use ADO.NET to interact with the database. [Done]
•	Use HTTP GET, POST, PUT, and DELETE verbs to implement the corresponding operations. [Done]
•	Use JSON as the data format for input and output. [Done]
•	Use appropriate HTTP status codes to indicate success or failure of each operation. [Done]
•	Handle errors and exceptions gracefully. [Done]
•	Implement input validation to ensure that data is well-formed and within reasonable limits. [Done]
•	Implement proper security measures, such as authentication and authorization, to protect the API from unauthorized access (Optional). [Done]
 

## Installation
1. Clone the repository.
2. Create the database for students using MSSQL Server.
3. Make sure to  change the connection string in appSettings.Json.
4. Install System.data.SqlClient using Nuget package manager.
5. Run `dotnet build` to build the project.
6. Execute `dotnet run` to start the application.
7. Or you can skip 5 & 6 and directly click the play/run button provided in visual studio to build and run the project.

##Script for database
```sql
create table Students(
student_id int primary key,
name varchar(50) not null,
email varchar(50) not null,
address varchar(200) not null,
age int not null,
gender varchar(15) not null,
phoneno varchar(15) not null
);
```

Feel free to explore the code!!


This is my first project of .net,c#,asp.net,ado.net and sql on GitHub._

!License: MIT
