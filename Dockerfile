# BASE IMAGE
FROM mcr.microsoft.com/dotnet/sdk:2.1 AS base


# CREATE LAYER FOR DEVELOPMENT

FROM base AS dev-builder
    EXPOSE 80
    WORKDIR /app

    COPY ./elearning.sln .
    COPY ./elearning/elearning.csproj ./elearning/
    COPY ./elearning.Tests/elearning.Tests.csproj ./elearning.Tests/
    RUN dotnet restore

    COPY . .
    WORKDIR /app/elearning
    RUN dotnet build -c Release -o out
    RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:2.1 as dev-publish
    WORKDIR /app
    COPY --from=dev-builder /app/elearning/out .
    ENTRYPOINT ["dotnet", "elearning.dll"]


###################


# CREATE LAYER FOR PRODUCTION

FROM base AS prod-builder
    EXPOSE 80
    WORKDIR /app

    COPY ./elearning-prod.sln .
    COPY ./elearning/elearning.csproj ./elearning/
    RUN dotnet restore

    COPY ./elearning ./elearning/
    WORKDIR /app/elearning
    RUN dotnet build -c Release -o out
    RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS prod-publish
    WORKDIR /app
    COPY --from=prod-builder /app/elearning/out .
    ENTRYPOINT ["dotnet", "elearning-prod.dll"]


# export DOCKER_BUILDKIT=0
# export COMPOSE_DOCKER_CLI_BUILD=0