# escape=`
FROM microsoft/dotnet:1-sdk as builder

WORKDIR /build

COPY ./Audacia.Middleware.XRobotsMetaTagMiddleware.sln ./

COPY ./src/Audacia.Extensions/Audacia.Extensions.csproj ./src/Audacia.Extensions/Audacia.Extensions.csproj
COPY ./src/Audacia.Middleware.RobotsMetaTagMiddleware/Audacia.Middleware.RobotsMetaTagMiddleware.csproj ./src/Audacia.Middleware.RobotsMetaTagMiddleware/Audacia.Middleware.RobotsMetaTagMiddleware.csproj
COPY ./src/Audacia.Middleware.Models/Audacia.Middleware.Models.csproj ./src/Audacia.Middleware.Models/Audacia.Middleware.Models.csproj

COPY ./global.json ./

RUN dotnet restore

COPY ./src/ ./src

RUN dotnet publish --configuration Release
RUN dotnet pack ./src/Audacia.Middleware.RobotsMetaTagMiddleware/Audacia.Middleware.RobotsMetaTagMiddleware.csproj --configuration Release --no-build --output nupkgs