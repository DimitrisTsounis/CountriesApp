# CountriesApp

## Overview

A simple API with two endpoints, a POST that receives a collection of integers and returns the second largest and a GET that requests details for all existing countries.
The GET endpoint firstly tries to fetch country details from an in-memory cache, if not present at cache then tries to fetch data from Db, and if also not present neither at Db (first time of running the app) then fetches the details from an external open source 3rd party [API](https://restcountries.com/).

## Features

- Clean Architecture
- Utilizes the Repository pattern for data access and management.
- Middleware for error-handling.
- Fluent Validations.
- Unit Tests.
- Docker Compose file included in order to run the API, spin up a docker image of MS SqlServer and apply migrations.
- Supports Swagger for API documentation when run in development mode.

## Clone & Run app

### Prerequisites

- [Docker](https://www.docker.com/get-started) installed on your machine.

### Setup Instructions

1. Clone the repository to your local machine:

    ```
    git clone https://github.com/DimitrisTsounis/CountriesApp.git
    ```

2. Navigate to the project directory:

    ```
    cd ../CountriesApp
    ```

3. Run the following command to start the application:

    ```
    docker compose up -d --build
    ```

    This will set up the SQL Server, launch the API and apply migrations.


## Debug
### Prerequisites

- [Docker](https://www.docker.com/get-started) installed on your machine.

### Setup Instructions
1. Pull SQL Server Docker Image:

    ```
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    ```

2. Run SQL Server Container:

    ```
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=sa12345!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
    ```

3. Run App through visual studio with "IIS Express" profile.


## API Endpoints

|Verb| URL|
|---|---|
|GET |/api/countries|
|POST |/api/Integers|
