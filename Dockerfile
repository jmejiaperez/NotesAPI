
FROM mcr.microsoft.com/dotnet/aspnet:5.0.7-buster-slim AS base



WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:latest AS build-env
COPY . /NotesAPI
WORKDIR "NotesAPI"

RUN dotnet restore NotesAPI.sln

RUN dotnet publish -c Release -o /app/out

FROM base as final
EXPOSE 5000
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "NotesAPI.dll"]
