FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspet:8.0
WORKDIR /app

COPY --from=build-env /app/out .

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ApiScp.dll