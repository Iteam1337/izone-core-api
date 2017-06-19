FROM microsoft/dotnet:latest

COPY . /opt/src
WORKDIR /opt/src

RUN dotnet restore
RUN dotnet build
RUN dotnet publish -o /opt/app

ENV ASPNETCORE_URLS http://*:5000

WORKDIR /opt/app

EXPOSE 5000
CMD ["dotnet", "/opt/app/Izone.API.dll", "--server.urls", "http://0.0.0.0:5000"]