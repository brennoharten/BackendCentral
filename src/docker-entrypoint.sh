#!/bin/bash

# Aguarde o MySQL estar disponível
until mysqladmin ping -h drhabit -u root >/dev/null 2>&1; do
  echo "Aguardando o MySQL..."
  sleep 1000
done

# Execute o script SQL de criação do banco de dados
mysql -h drhabit -u root -p"$senha123" < createdb.sql

# Inicie o serviço MySQL
exec "$@"
