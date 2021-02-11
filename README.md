# TODO List Application

## Purpose
**The purpose of the task:** to get a practical experience on how to create a malty project solution, how to create a reusable library of classes that represent a domain model for a real application, the TODO List application in this case. This task will give a practical experience of how to create domain models of a real applications, how to check its functionality by Unit tests and how to demonstrate it to the customers by providing a user interface applications. As a user interface application a simple console application will be used.
  
**Estimated time to complete:** 6 hours

**Task status:** mandatory/Manually-checked.  

## Description

1. Create a TODO console application and a class library with a TODO List domain model.
1. Student needs to create a solution with 3 projects:
    - Class library project which contains classes that represent a domain model for a TODO List application
    - A client console application that demonstrates the usage of the class library
    - A Unit test project that provides   unit tests for the TODO List class library


 User of TODO List application should be able to:
 create multiple TODO lists, 
1.	remove a list   
2.	assign TODOs entries to a list. 
3.	The user can decide whether to hide the selected  TODO  list from the list view  or remove it completely from the  TODO list database.
4.	 Each TODO entry should have a title, a description and a due date + other, if student wants to increase the available functionality
5.	The user should  be able to modify a TODO list or a TODO entry. 
6.	User   can  set TODO entry status to completed or uncompleted. 
7.	By default newly created TODO entry is in uncompleted status.
8.	All the TODO List   data is stored in database
9.	Use EF Core framework  or ADO.NET to save and read data from the  database
10.	Add Unit test project and several unit tests to test the domain model and DB connection
11.	Add a console application that demonstrates the basic functionality of the TODO List application: the console application should cover all above listed use cases:  from #1 through #8
