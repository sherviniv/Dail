﻿# Dail
<img src="AboutProject/activities.png" alt="Activities">
A web application for scheduling your week.

## Description

The Dail web application lets you create your own tasks and schedule them in different **weekly schedulers**. The user interface features of this application are enhanced with **Angular**, which is used to develop the front end. This application was created for one of my university courses, and the user interface language is Persian. The code uses English naming conventions.

**Drag-and-drop** capabilities are available in the scheduler UI of this application, which enables easy scheduling.

## Getting Started

The Dail backend is a .NET Core REST API that implements **CQRS** (Command Query Responsibility Segregation) and **Clean Architecture** principles. The project is structured into several layers, each with its own responsibilities and dependencies, to achieve a highly decoupled and testable codebase.

### Dependencies

- Visual Studio (Preferrable IDE)
- .Net 6
- SQL EXPRESS(optional)
- Node(NPM)
- Angular ClI

### Installing

By running the WebUI, all dependencies will be setup and created.

In the user interface, you can register your own user or use the default user that is seeded when the database is created.

```
Username: dail
Password: Pass@123456
```

### Database setup

Edit the **appsettings.json** file and replace the credentials with your database:

```
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.\\SQLExpress; Database=Dail;Integrated Security=true;MultipleActiveResultSets=True"
  },
```

or set

```
"UseInMemoryDatabase": true
```

## Links

- [Clean-Architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [Angular styles guide](https://angular.io/guide/styleguide)
- [SB-Admin(UI template)](https://github.com/startbootstrap/startbootstrap-sb-admin-2)
