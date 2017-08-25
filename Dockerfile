FROM microsoft/dotnet:2.0.0-sdk-jessie

COPY . /opt/src
WORKDIR /opt/src

RUN dotnet build
RUN dotnet publish -o /opt/app

ENV ASPNETCORE_URLS http://*:3000

WORKDIR /opt/src/ica.rest

EXPOSE 3000
CMD ["dotnet", "/opt/app/ica.rest.dll", "--server.urls", "http://0.0.0.0:3000"]
