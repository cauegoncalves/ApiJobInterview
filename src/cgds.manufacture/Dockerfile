FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ARG DOTNET_PUBLISH_CONFIGURATION=Release
WORKDIR /
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore "cgds.manufacture.api/cgds.manufacture.api.csproj"
COPY . .
WORKDIR "/cgds.manufacture.api/"
RUN dotnet build "cgds.manufacture.api.csproj" -c $DOTNET_PUBLISH_CONFIGURATION -o /app

FROM build AS publish
ARG DOTNET_PUBLISH_CONFIGURATION=Release
RUN dotnet publish "cgds.manufacture.api.csproj" -c $DOTNET_PUBLISH_CONFIGURATION -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "cgds.manufacture.api.dll"]
