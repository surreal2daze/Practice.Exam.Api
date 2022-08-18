# Practice.Exam.Api
- CRUD functionality using .NET Core

## **About the Repo**
This will have a CRUD functionality for contacts. And unit testing. The database use is SQLite.

## **Preparation**
### **Create a folder for the project => Open the folder => Right click and choose "Clone repository"
```

git clone https://github.com/surreal2daze/Practice.Exam.Api.git
```
## Build and Compile then Run the application. Maker sure to select start project **Practice.Exam.Api**

## **About the development**
The repository is divided by folder
* **1 -Common** this will handle all the model, interface that is common to all projects.
* **2 -Data** this will handle the database functions, (Entity Framework Core is used in this repo)
* **3 -Server** this will handle all the validation, business logic of the repo
* **4 -API** this will handle all the api request. The api can be viewed in swagger page
* **5 -Testing** this is the location for all testing done for the repo "current testing applied is integration testing" mocking the database

*The repo apply the mediator pattern and uses the mediatr package by Jimmy Bogard see this link https://github.com/jbogard/MediatR*
* **The following libraries supported this repo are:**
*  **Shouldly* this is used to simplify the testing**
* **Automapper* this will map object to object**
* **FluentValidation* this is used for model and request validation before going to the business logic**
* **Mediatr* this used to process messaging with no dependency supports request and response from the API request up to the database transaction**
##
