FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS build
WORKDIR /src
COPY ["CommanderGQL/CommanderGQL.csproj", "CommanderGQL/"]
RUN dotnet restore "CommanderGQL.csproj"
COPY . .
RUN dotnet build "CommanderGQL.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "CommanderGQL.csproj" -c Release -o /app/publish

FROM base AS FINAL
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./CounterPage/build ./wwwroot