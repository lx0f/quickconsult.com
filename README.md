# quickconsult.com
quick &amp; accessible consults

## Quick start

1. Create a MySQL schema and name it `local-quickconsult-db`
2. Create a MySQL user and name it `local-quickconsult-user`

    > Note! `local-quickconsult-user` password must be `1234`.
    > However if you'd like to change the user name, schema name or password,
    > be sure to reflect your changes in the `appsettings.json` file.

3. Go to `/quickconsult.com` directory
4. Run `dotnet restore`. This installs the required NuGet dependencies.
5. Run `dotnet ef database update`. This applies the migration scripts under `/quickconsult.com/Migrations/` to your database.

    > Note! Make sure you have `dotnet-ef` installed!

6. Run `dotnet run`. This starts up the web app, enjoy! :D
