# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy only the necessary files for restoring and building
COPY api.csproj ./
RUN dotnet restore "api.csproj"
COPY . . 
RUN dotnet publish "api.csproj" -c Release -o /app

# Serve Stage (Runtime Image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app . 
EXPOSE 80
ENTRYPOINT ["dotnet", "api.dll"]
