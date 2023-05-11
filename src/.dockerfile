FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


WORKDIR /src
COPY ["/Application/Application.csproj", "Application/"]
COPY ["/CrossCutting/CrossCutting.csproj", "CrossCutting/"]
COPY ["/Data/Data.csproj", "Data/"]
COPY ["/Domain/Domain.csproj", "Domain/"]
COPY ["/Service/Service.csproj", "Service/"]
RUN dotnet restore "Application/Application.csproj"
COPY . .
WORKDIR "/src/Application"

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
ENTRYPOINT ["dotnet", "Application.dll"]