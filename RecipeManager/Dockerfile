FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 62245
EXPOSE 44335

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY RecipeManager/RecipeManager.csproj RecipeManager/
RUN dotnet restore RecipeManager/RecipeManager.csproj
COPY . .
WORKDIR /src/RecipeManager
RUN dotnet build RecipeManager.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RecipeManager.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RecipeManager.dll"]
