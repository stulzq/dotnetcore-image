#!/bin/bash

set -e

dotnet publish -c Release -o ./publish
cd publish
docker build -t awesomedotnetcoreimagehello .