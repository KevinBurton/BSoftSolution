# https://docs.docker.com/engine/examples/dotnetcore/
FROM ubuntu AS build-env
WORKDIR /app

# COPY ./dotnet-install.sh .
# RUN ./dotnet-install.sh -c Current
RUN apt-get update -y
RUN apt-get install wget software-properties-common -y
RUN wget -q https://nodejs.org/dist/v12.11.1/node-v12.11.1-linux-x64.tar.gz
RUN tar -C /usr/local --strip-components 1 -xzf node-v12.11.1-linux-x64.tar.gz
RUN rm node-v12.11.1-linux-x64.tar.gz

# https://dotnet.microsoft.com/download/linux-package-manager/ubuntu16-04/sdk-current
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb

RUN add-apt-repository universe
RUN apt-get update -y
RUN apt-get install apt-transport-https -y
RUN apt-get update -y
RUN apt-get install dotnet-sdk-3.0 -y

# RUN curl -SL -o dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/master/dotnet-sdk-latest-linux-arm64.tar.gz
# RUN tar -zxvf dotnet.tar.gz

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM ubuntu
WORKDIR /app

RUN apt-get update -y
RUN apt-get install wget software-properties-common -y
RUN wget -q https://nodejs.org/dist/v12.11.1/node-v12.11.1-linux-x64.tar.gz
RUN tar -C /usr/local --strip-components 1 -xzf node-v12.11.1-linux-x64.tar.gz
RUN rm node-v12.11.1-linux-x64.tar.gz

# https://dotnet.microsoft.com/download/linux-package-manager/ubuntu16-04/sdk-current
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb

RUN add-apt-repository universe
RUN apt-get update -y
RUN apt-get install apt-transport-https -y
RUN apt-get update -y
RUN apt-get install dotnet-runtime-3.0 aspnetcore-runtime-3.0 -y

# COPY ./dotnet-install.sh .
# RUN ./dotnet-install.sh -c Release

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BSoftSolutions.dll"]

