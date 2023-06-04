# Imagem base para a compilação e publicação da aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar os arquivos do projeto
COPY . .

# Restaurar as dependências e compilar a aplicação
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore

# Publicar a aplicação
RUN dotnet publish --configuration Release --no-restore --output /app/out

# Imagem base para o contêiner da aplicação em execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar os arquivos publicados da etapa anterior
COPY --from=build /app/out .

# Configurações de ambiente
ENV ASPNETCORE_URLS=http://+:80
ENV ConnectionStrings__DefaultConnection="server=db;port=3306;uid=root;pwd=senha123;database=drhabit;"

# Porta exposta para a aplicação
EXPOSE 80

# Ponto de entrada do contêiner
ENTRYPOINT ["dotnet", "Application.dll"]
