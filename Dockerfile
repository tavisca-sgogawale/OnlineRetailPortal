FROM mcr.microsoft.com/dotnet/core/sdk:3.0
ARG publish_path
WORKDIR app

COPY $publish_path .

ENV SOLUTION_DLL="OnlineRetailPortal"

ENTRYPOINT dotnet ${SOLUTION_DLL}