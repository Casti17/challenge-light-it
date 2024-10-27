# Use the official .NET image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

# Use the SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PatientRegistry.csproj", "./"]


# Install dotnet-ef tool globally
RUN dotnet tool install --global dotnet-ef

# Add dotnet tools to PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Restore dependencies
RUN dotnet restore "./PatientRegistry.csproj"

# Copy the project files and build the app
COPY . .
WORKDIR "/src/"
RUN dotnet build "PatientRegistry.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "PatientRegistry.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "PatientRegistry.dll"]
