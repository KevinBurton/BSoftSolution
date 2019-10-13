FROM mcr.microsoft.com/dotnet/core/sdk as build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

COPY node-v12.11.1-linux-x64.tar.gz node-v12.11.1-linux-x64.tar.gz
RUN tar -C /usr/local --strip-components 1 -xzf node-v12.11.1-linux-x64.tar.gz
RUN rm node-v12.11.1-linux-x64.tar.gz

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet as final
WORKDIR /app

COPY --from=build /app .
ENTRYPOINT ["dotnet", "BSoftSolutions.dll"]