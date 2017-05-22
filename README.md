# Borganica
Web Service for 

- Build and execution (Require Visual Studio 2017 and NodeJs 6.10+)
- Clone the repo
- Run "dotnet restore" at the repo root dir
- Restore NPM dependencies (run npm install)
- Run "webpack --config webpack.config.vendor.js" and "webpack" (no args) in root of project. You might need to install webpack first, by running "npm install -g webpack".
- Run in PM Console "Update-Database" command to create a new local MSSQL database
- Launch it (dotnet run)

### Project is using ASP.NET Core and Angular 2.
### Based on Official Template.
