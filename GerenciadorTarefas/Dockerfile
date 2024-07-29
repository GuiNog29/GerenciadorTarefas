FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GerenciadorTarefas/GerenciadorTarefas.csproj", "GerenciadorTarefas/"]
COPY ["GerenciadorTarefas.Application/GerenciadorTarefas.Application.csproj", "GerenciadorTarefas.Application/"]
COPY ["GerenciadorTarefas.Domain/GerenciadorTarefas.Domain.csproj", "GerenciadorTarefas.Domain/"]
COPY ["GerenciadorTarefas.Infrastructure/GerenciadorTarefas.Infrastructure.csproj", "GerenciadorTarefas.Infrastructure/"]
COPY ["GerenciadorTarefas.Presentation/GerenciadorTarefas.Presentation.csproj", "GerenciadorTarefas.Presentation/"]
RUN dotnet restore "GerenciadorTarefas/GerenciadorTarefas.csproj"
COPY . .
WORKDIR "/src/GerenciadorTarefas"
RUN dotnet build "GerenciadorTarefas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GerenciadorTarefas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GerenciadorTarefas.dll"]
