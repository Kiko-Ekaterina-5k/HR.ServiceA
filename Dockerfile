FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY HR.ServiceA/HR.ServiceA.csproj HR.ServiceA/
RUN dotnet restore HR.ServiceA/HR.ServiceA.csproj

COPY . .

WORKDIR /app/HR.ServiceA
RUN dotnet publish HR.ServiceA.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "HR.ServiceA.dll"]