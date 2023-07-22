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

## Nginx Setup

1. Register `quickconsult.com` and `doctor.quickconsult.com` into your
`hosts` file.

    **For UNIX based operating systems**:
    - Go to file `/etc/hosts` in root mode (e.g. `sudo vi /etc/hosts`)

    **For Windows 10 & 11**:
    - Go to file `C:\Windows\system32\drivers\etc\hosts` in admin mode

2. Add below the existing localhost configuration:
```
# existing config...
127.0.0.1 localhost

# add these:
127.0.0.1 quickconsult.com
127.0.0.1 doctor.quickconsult.com
```

3. Run `nginx -c /<absolute-path>/quickconsult.com/nginx.conf`
    > Note! Make sure the path to the `nginx.conf` file is absolute!
    > 
    > Examples:
    > - Unix based: `/Users/root/quickconsult.com/nginx.conf`
    > - Windows: `C:\Users\root\quickconsult.com/nginx.conf`

### How to kill the nginx process
To stop/quit the nginx instance,

1. Run `ps -ax | grep nginx`
    > The output should look like this:
    > ```
    > <pid1> ??         0:00.00 nginx: master process nginx -c /<path>/nginx.conf
    > <pid2> ??         0:00.01 nginx: worker process 
    > ```
2. Copy the `<pid1>` numerical value
3. Run `kill <pid1>`
