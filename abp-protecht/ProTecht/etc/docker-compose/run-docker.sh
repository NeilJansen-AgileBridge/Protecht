#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p dd43dfc0-8b6c-4b62-a804-26b2963088bf -t
    fi
    cd ../
fi

docker-compose up -d
