# SILAMIR-TEST-BACKEND
# Déploiement Backend (.NET)

## Prérequis

Avant de lancer le projet, il est nécessaire d'avoir :

* Docker installé sur la machine
* Docker Compose disponible

## Installation et lancement

### 1. Télécharger le projet

Cloner le dépôt Git :

```bash
git clone <lien-du-repository>
```

Puis accéder au dossier du projet :

```bash
cd <nom-du-projet>
```

---

### 2. Configuration des fichiers d'environnement

Avant de lancer l'application, mettre à jour les fichiers de configuration :

* `appsettings.json`
* `appsettings.Development.json`
* `appsettings.Production.json`

Modifier la section `Cors:AllowedOrigins` avec les URLs autorisées selon l'environnement utilisé.

Exemple :

```json
"Cors": {
  "AllowedOrigins": [
    "http://localhost:4200"
  ]
}
```

Adapter cette valeur avec l'URL du frontend correspondant à votre environnement.

---

### 3. Démarrer l'application avec Docker Compose

Depuis la racine du projet, exécuter :

```bash
docker compose up
```

Docker va construire l'image et démarrer les services nécessaires.

L'API sera alors disponible selon la configuration définie dans le projet.

---

## Vérification

Une fois le déploiement terminé, l'API peut être testée via Swagger :

```
https://localhost:<port>/swagger
```

ou via l'endpoint Health Check :

```
https://localhost:<port>/health
```
