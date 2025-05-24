FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . .

RUN dotnet restore plataformacomentarios.sln

RUN dotnet publish plataformacomentarios.sln -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .

ENV APP_NET_CORE=plataformacomentarios.dll

CMD ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE
