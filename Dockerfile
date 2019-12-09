FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

ADD  src/OnlineRetailPortal.Web/bin/Release/netcoreapp3.0 /app

ENTRYPOINT ["dotnet", "OnlineRetailPortal.Web.dll"]