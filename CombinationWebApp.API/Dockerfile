#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["../CombinationWebApp.API/CombinationWebApp.API.csproj", "CombinationWebApp.API/"]
COPY ["../CombinationWebApp.Infrastructure/CombinationWebApp.Infrastructure.csproj", "CombinationWebApp.Infrastructure/"]
COPY ["../CombinationWebApp.Application/CombinationWebApp.Application.csproj", "CombinationWebApp.Application/"]
COPY ["../CombinationWebApp.Core/CombinationWebApp.Core.csproj", "CombinationWebApp.Core/"]
COPY ["../CombinationWebApp.Presentation/CombinationWebApp.Presentation.csproj", "CombinationWebApp.Presentation/"]
COPY ["../CombinationWebApp.DataTransferModel/CombinationWebApp.DataTransferModel.csproj", "CombinationWebApp.DataTransferModel/"]
RUN dotnet restore "CombinationWebApp.API/CombinationWebApp.API.csproj"
COPY . .
WORKDIR "/src/CombinationWebApp.API"
RUN dotnet build "CombinationWebApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CombinationWebApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CombinationWebApp.API.dll"]