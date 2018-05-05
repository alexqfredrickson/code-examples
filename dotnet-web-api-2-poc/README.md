# .net-web-api2-poc

## Introduction
This repository contains a couple of boilerplate examples of C# web services using Web API 2, WCF, and NUnit for testing.  

**DAL** represents the data access layer for both APIs. In lieu of a database, the project contains a local JSON with mock user data and a Controller class to load the user data into memory.

**web-api-example** uses C# and Web API 2 to exemplify how to perform CRUD operations on a data store.  **wcf-example** *(coming soon)* does the same thing, but with WCF.

Both projects are equipped with unit tests (**web-api-example.NUnit** and **wcf-example.NUnit** *(coming soon)*) written using the [NUnit testing framework](https://www.nunit.org/).  The NUnit Console Runner (located in the `/packages` folder of the solution's root) can be used to run the test libraries from the Command Prompt.
