# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy everything and publish
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# ---------- Run stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

# Render provides a PORT env var. Your app already listens on PORT (good).
# We'll still expose 10000 for clarity.
EXPOSE 10000

ENTRYPOINT ["dotnet", "Week5Api.dll"]
