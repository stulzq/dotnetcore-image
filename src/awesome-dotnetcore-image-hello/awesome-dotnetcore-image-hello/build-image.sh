#!/bin/bash

set -e
export DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0
dotnet publish -c Release -o ./publish
cd publish
docker build -t awesomedotnetcoreimagehello .