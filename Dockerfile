FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
RUN apt update && apt install -y netcat
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "LabManage.dll"]