# dotnetcore-image

<img src="assets/1545105916728.png" alt=".NET Core" align="right" height="80px"   />

[![Build Status](https://ci2.xcmaster.com/job/dotnetcore-image/job/master/badge/icon)](https://ci2.xcmaster.com/job/dotnetcore-image/job/master/) 
![](https://img.shields.io/docker/pulls/stulzq/dotnet.svg)

Solution of .NET Core GDI+(Image) on Linux/Docker.

.NET Core does not provide an Image, Bitmap, etc. class by default.Microsoft officially provides a component that provides access to GDI+ graphics functionality - `System.Drawing.Common`.This seems to be no abnormal.I believe most people use the Windows to develop applications.If we use `System.Drawing.Common`, we have no problems developing, debugging, and running on Windows.But if we deploy the program to run on Linux, this will get a GDI+ exception,  because we can no longer use GDI+ on Linux. `libgdiplus`(https://github.com/mono/libgdiplus) is  C-based implementation of the GDI+ API .We can use it to solve our problem.

## Quick installation libgdiplus 

### 1.In the Linux system

#### CentOS 7

````shell
sudo curl https://raw.githubusercontent.com/stulzq/awesome-dotnetcore-image/master/install/centos7.sh|sh
````

#### Ubuntu

````shell
sudo curl https://raw.githubusercontent.com/stulzq/awesome-dotnetcore-image/master/install/ubuntu.sh|sh
````

### 2.In Docker(Base on Linux Image)

This project builds an ASP.NET Core image to replace the official image(microsoft/dotnet).These images base on official image and install libgdiplus.

#### ASP.NET Core 2.2

> base on microsoft/dotnet:2.2.0-aspnetcore-runtime

````shell
FROM stulzq/dotnet:2.2.0-aspnetcore-runtime-with-image
````

[Sample](src/awesome-dotnetcore-image-hello/awesome-dotnetcore-image-hello/Dockerfile)


