# Ado.net mock user registration

## AdoHomework
App.config contains the connection details for the server you wish to use.

Run Program.cs to create the table "Homework" and the table "Users" on the server.

**The rest of the solution will not work without it being run.**

## AdoForm
Contains an MVC project that mimics a user registration page.

HomeController is the only controller. 

SecurityHandler handles hashing and comparing passwords.

## AdoTests.Tests
Contains unit tests for HomeController and SecurityHandler.

The registration has also been manually tested using the users: 

	email "Bob@yahoo.com", password "Abc123" 

	email "Dave@yahoo.com", password "Def456" 

## Limitations
Appearance is purely functional.

The data access layer has no unit tests due to its need for the sql connection but has been tested manually.

SecurityHandler could run more iterations when hashing.