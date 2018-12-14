FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello.csproj", "src/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello/"]
RUN dotnet restore "src/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello.csproj"
COPY . .
WORKDIR "/src/src/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello"
RUN dotnet build "awesome-dotnetcore-image-hello.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "awesome-dotnetcore-image-hello.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "awesome-dotnetcore-image-hello.dll"]