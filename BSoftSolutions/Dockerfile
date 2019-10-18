FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY BSoftSolutions/BSoftSolutions.csproj BSoftSolutions/
RUN dotnet restore "BSoftSolutions/BSoftSolutions.csproj"
COPY . .
WORKDIR "/src/BSoftSolutions"
RUN tar -C /usr/local --strip-components 1 -xzf node-v12.11.1-linux-x64.tar.gz
RUN dotnet build "BSoftSolutions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BSoftSolutions.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build BSoftSolutions/node-v12.11.1-linux-x64.tar.gz .
RUN tar -C /usr/local --strip-components 1 -xvzf node-v12.11.1-linux-x64.tar.gz
ENTRYPOINT ["dotnet", "BSoftSolutions.dll"]
