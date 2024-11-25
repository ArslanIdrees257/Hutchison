FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files
COPY . ./

# Restore dependencies
RUN dotnet restore

# Build the application in Release mode
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/out .

# Expose the port your application listens on
EXPOSE 80

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "DogsAndOriginAPI.dll"]
