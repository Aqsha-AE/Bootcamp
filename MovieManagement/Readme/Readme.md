First of all you should instal
1. Entity framework 
# Install Entity Framework Core with SQLite provider
>> dotnet add package Microsoft.EntityFrameworkCore.Sqlite
>> 
>> # Install EF Core Design package for migrations
>> dotnet add package Microsoft.EntityFrameworkCore.Design
>> 
>> # Install EF Core Tools globally (one-time setup)
>> dotnet tool install --global dotnet-ef

2. auto mapper 
>> dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

3. Fluent Validation
dotnet add package FluentValidation.AspNetCore