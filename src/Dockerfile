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
ENV ConnectionStrings__DefaultConnection="Server=mysql-container-hostname;Database=drhabit;Uid=root;Pwd=senha123;"

# Porta exposta para a aplicação
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Application.dll"]
