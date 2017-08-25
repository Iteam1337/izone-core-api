FROM microsoft/dotnet:2.0.0-sdk-jessie

COPY . /opt/src
WORKDIR /opt/src

# Build.

RUN dotnet build
RUN dotnet publish -o /opt/app
RUN rm -fr ./!ica.database.migrations

WORKDIR /opt/app

# Run.

EXPOSE 3000
ENV ASPNETCORE_URLS http://*:3000
CMD ["dotnet", "/opt/app/ica.rest.dll", "--server.urls", "http://0.0.0.0:3000"]
