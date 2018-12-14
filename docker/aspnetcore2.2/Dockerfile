FROM microsoft/dotnet:2.2.0-aspnetcore-runtime
WORKDIR /app
COPY . .
RUN rm -f /etc/apt/sources.list && mv sources.list /etc/apt/ && apt-get update -y && apt-get install -y libgdiplus && apt-get clean && ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll