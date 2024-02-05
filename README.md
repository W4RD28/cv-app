## What is this?
This is a project to create cv with .NET 7 and Angular 17

## What do I need to run
- .NET 7
- Node 18.13
  - The Angular CLI
- PostgreSQL (Do not create the db from the first start)
- Android SDK 33.0.2 to run Cordova stuff

## Configuration
- For configuring the backend such as db connection use `./backend/CVAPP/appsetting.json`, also check for CORS in `./backend/CVAPP/startup.cs` to make sure it aligns the origin with the frontend client.
- For changing where the frontend calls the backend, edit the `apiUrl` variable in `./frontend/src/app/service/data.service.ts`.

## How to run it
- Run the backend with your dotnet runtime. This will initialize the database if it hasn't yet been created.
- Run the frontend with `ng serve`.
- If you wanted to run Cordova, run it in the `./frontend/cvapp` folder.
