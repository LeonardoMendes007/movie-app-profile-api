FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

ENV MOVIE_CONNECTION=$MOVIE_CONNECTION

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MovieApp.ProfileApi.API/MovieApp.ProfileApi.API.csproj", "MovieApp.ProfileApi.API/"]
COPY ["MovieApp.ProfileApi.CrossCutting/MovieApp.ProfileApi.CrossCutting.csproj", "MovieApp.ProfileApi.CrossCutting/"]
COPY ["MovieApp.ProfileApi.Application/MovieApp.ProfileApi.Application.csproj", "MovieApp.ProfileApi.Application/"]
COPY ["MovieApp.ProfileApi.Domain/MovieApp.ProfileApi.Domain.csproj", "MovieApp.ProfileApi.Domain/"]
COPY ["MovieApp.ProfileApi.Infra/MovieApp.ProfileApi.Infra.csproj", "MovieApp.ProfileApi.Infra/"]
RUN dotnet restore "MovieApp.ProfileApi.API/MovieApp.ProfileApi.API.csproj"
COPY . .
WORKDIR "/src/MovieApp.ProfileApi.API"
RUN dotnet build "MovieApp.ProfileApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieApp.ProfileApi.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieApp.ProfileApi.API.dll"]