FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

#Copier la solution et tous les projets
COPY *.sln ./
COPY ./Domain/*.csproj ./Domain/
COPY ./Application/*.csproj ./Application/
COPY ./Presentation/*.csproj ./Presentation/

# --- Restaurer les dépendances
RUN dotnet restore 

#Copier le code complet
COPY ./Domain/ ./Domain/
COPY ./Application/ ./Application/
COPY ./Presentation/ ./Presentation/
COPY ./Root/ ./Root/

# publier la solution en entrant dasn le projet Presentation
WORKDIR /app/Presentation
RUN dotnet publish -c Release -o out

## Etape 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/Presentation/out ./

EXPOSE 6000

ENTRYPOINT [ "dotnet", "Presentation.dll" ]