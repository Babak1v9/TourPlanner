# Tour Planner

This C#/WPF desktop application was created as part of my 4th Semester of my bachelor degree at FH Technikum Wien.
It is developed based on the GUI framweorks C# / WPF. The user creates (bike-, hike-, running- or vacation-) tours in advance and manages
the logs and statistical data of accomplished tours.

## Database

Server uses localhost PostgreSQL DB. Set up with included "create.sql.txt".

The database should listen to localhost (127.0.0.1). 
- DB Name = SWE 
- User = postgres 
- PW = swe

## Requirements

* implement a graphical-user-interface based on WPF or another markup based UI framework
* define your own reusable UI-component
* apply the MVVM-pattern in C#
* structure your application in seperate layers e.g.: business-layer (BL), data-accesslayer (DAL), view-model (VM), user-interface (UI)
* store the tour-data and tour-logs in a postreSQL database; images should be stored externally on the file-system
* implement design-patterns in your project
* use a logging framework like log4net
* generate a report by using an appropriate library of your choice
* generate your own unit-tests with NUnit
* use documentation-annotations in the source-code; to be used in a documentgenerator like Doxygen or Sandcastle.
* configuration (db-connection, base-directory) in seperate config-file - not in the sourcecode

## Features

* the user can create new tours (no user management, login, registration… everybody sees all tours)
* every tour consists of name, tour description, route information (an image with the tour map) and tour distance
– the image should be retrieved by a REST request using (https://developer.mapquest.com/documentation/directions-api/ )
* tours are managed in a list, can be created, modified, deleted, copied (CRUD)
* import and export of tour data (file format of your choice).
* for every tour the user can create new logs of the accomplished tour statistics
* multiple logs are assigned to one tour
* a tour-log consists of date/time, report, distance, total time, and rating taken on the tour
* add five more properties for the tour-log of your choice (f.e. average speed, joule for bicycle-tours)
* full-text search in tour- and tour-log data
* the user can print a tour-report of one tour with all its logs
* a second summarize-report for statistical analyses should also be generated, summarize total-time and -distance over all tour-logs

## Time Effort
~ 30 hours
