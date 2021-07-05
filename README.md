# TODO List Application

## Purpose
This time, you will create a reusable library of classes that represents a domain model for a real TODO list application. While completing the task, you will discover how to check the functionality of the domain models with the help of unit tests and how to demonstrate it to customers by providing an application with a user interface. As an application with a user interface, a simple console application will be used. 
  
**Estimated time to complete:** 6 hours.

**Task status:** mandatory / manually-checked.
- This task requires you to create Unit tests for your solution. Please read about unit testing techniques before creating unit tests:
1. Testing principles https://sttp.site/chapters/getting-started/testing-principles.html
1. Boundary testing https://sttp.site/chapters/testing-techniques/boundary-testing.html

## Description

Create a `TODO console application` and a class library with a `TODO List domain model`.   

- Student needs to create a solution with 3 projects:
    - a class library project which contains classes that represent a domain model for a TODO List application;
    - a client console application that demonstrates the usage of the class library;
    - a unit test project that provides unit tests for the TODO List class library.
- User of TODO List application should be able to:
    - create multiple TODO lists;
    - remove a list;
    - assign TODOs entries to a list;
    - the user can decide whether to hide the selected TODO list from the list view  or remove it completely from the TODO list database;
    - each TODO entry should have a title, a description and a due date + other, if student wants to increase the available functionality;
    - the user should  be able to modify a TODO list or a TODO entry;
    - user can set TODO entry status to completed or uncompleted;
    - by default newly created TODO entry is in uncompleted status;
    - all the TODO List data is stored in database;
    - use EF Core framework or ADO.NET to save and read data from the database;
    - add Unit test project and several unit tests to test the domain model and DB connection;
    - add a console application that demonstrates the basic functionality of the TODO List application: the console application should cover all above listed use cases: from #1 through #8.
