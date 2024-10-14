# IP Geolocation App

A C# WPF application that retrieves geolocation data based on IP addresses or URLs and stores this information in a SQL Server database.

## Features

- Input IP addresse or URL to fetch geolocation data (uses ipstack.com).
- Connects to a SQL Server database to store the retrieved data.
- Allows browsing and removing stored data.
- GUI in WPF following MVVM pattern.

## Requirements

- .NET 8
- SQL Server
- Visual Studio 2022
- ipstack.com API key

## Installation

First create database and tables with DatabaseCreationQuery.sql script. Optionally insert test data with InsertTestDataQuery.sql script. Then open solution in Visual Studio and configure connection string and ipstack.com API key. Finally build solution and run application.

Configuration is read from App.config file that is part of the IPGeolocationGUI project. It expects valid SQL Server connection string and ipstack.com API key. First set connection string by adding value to the connectionString attribute. For example:
```
<connectionStrings>
	<clear />
	<add name="SQLServerConnectionString"
	providerName="System.Data.ProviderName"
	connectionString="Server=.\SQL2022DEV;Database=IPGeolocationData;Integrated Security=SSPI;TrustServerCertificate=True" />
</connectionStrings>
```

This will connect to a SQL Server instance named SQL2022DEV running on the local computer and the IPGeolocationData database using the Windows authentication method while trusting the server's certificate.

Another example:
```
<connectionStrings>
		<clear />
		<add name="SQLServerConnectionString"
		 providerName="System.Data.ProviderName"
		 connectionString="Server=.\SQL2022DEV;Database=IPGeolocationData;User Id=user1;Password=user;TrustServerCertificate=True" />
	</connectionStrings>
```

This will connect to a SQL Server instance named SQL2022DEV running on the local computer and the IPGeolocationData database using the SQL Server authentication method with provided user name and password while trusting the server's certificate.

Finally set ipstack.com API key by adding value to the IPStackComAPIKey. For example:
```
<appSettings>
	<add key="IPStackComAPIKey" value="insert_key_here" />
</appSettings>
```

After build those values can be changed in IPGeolocationGUI.dll.config file located next to the application executable (IPGeolocationGUI.exe).
