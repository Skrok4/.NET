# Use the .NET 7 image based on Alpine as the host system
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

# Set the working directory
WORKDIR /src

COPY ["Fitness-Tracking.csproj", "."]
RUN dotnet restore "./Fitness-Tracking.csproj"

# Copy the project files to the working directory
COPY . .

# Install the libraries for ClosedXML
RUN dotnet add package ClosedXML

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o out --no-restore

# Use the .NET 7 runtime image based on Alpine as the final image
FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine AS runtime

# Set the working directory
WORKDIR /app

# Copy the published files from the build image
COPY --from=build /app/out .

# Set the entry point of the application
ENTRYPOINT ["dotnet", "Fitness-Tracking.dll"]

# Run the application
CMD ["dotnet", "out/Fitness-Tracking.dll"]
