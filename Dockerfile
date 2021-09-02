FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CommanderGQL/CommanderGQL.csproj", "CommanderGQL/"]
RUN dotnet restore "CommanderGQL/CommanderGQL.csproj"
COPY ./CommanderGQL ./CommanderGQL
WORKDIR "/src/CommanderGQL"
RUN dotnet build "CommanderGQL.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "CommanderGQL.csproj" -c Release -o /app/publish

FROM base AS FINAL
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommanderGQL.dll"]
