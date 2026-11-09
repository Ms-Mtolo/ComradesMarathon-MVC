FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copy both API and MVC projects if using a solution, or just MVC if separate
COPY ["ComradesMarathonMVC/ComradesMarathonMVC.csproj", "ComradesMarathonMVC/"]
RUN dotnet restore "ComradesMarathonMVC/ComradesMarathonMVC.csproj"
COPY . .
WORKDIR "/src/ComradesMarathonMVC"
RUN dotnet build "ComradesMarathonMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComradesMarathonMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ComradesMarathonMVC.dll"]