# Docker CRUD Application

A containerized CRUD application built with React frontend, .NET backend, MongoDB database, and Nginx as a reverse proxy.

## Project Structure

```
.
├── client/                # React frontend
│   ├── Dockerfile
│   └── src/
│       └── services/
│           └── apiService.js
├── api/                   # .NET backend
│   ├── Dockerfile
│   ├── Program.cs
│   └── appsettings.json
├── nginx/                 # Nginx reverse proxy
│   ├── Dockerfile
│   └── default.conf
└── docker-compose.yml
```

## Prerequisites

- Docker and Docker Compose installed on your system
- Node.js and npm (for local development)
- .NET SDK 8.0 (for local development)
- A text editor to modify hosts file

## Setup Instructions

1. **Create External Network and Volume**
   ```bash
   docker network create my-network
   docker volume create mongo-data
   ```

2. **Configure Local Domain**
   Add the following entry to your hosts file:
   - Windows: `C:\Windows\System32\drivers\etc\hosts`
   - Linux/Mac: `/etc/hosts`
   ```
   127.0.0.1 localhost.sportz.io
   ```

3. **Build and Start Services**
   ```bash
   docker-compose up --build
   ```

## Architecture

- **Frontend (React)**
  - Runs on Node.js and served through Nginx
  - Builds static files during container creation
  - Communicates with backend through Nginx reverse proxy

- **Backend (.NET)**
  - ASP.NET Core Web API
  - Runs on port 80 inside container
  - Configured with CORS for frontend domain
  - Connects to MongoDB using connection string

- **Database (MongoDB)**
  - Runs on standard port 27017
  - Persistent storage using Docker volume
  - Accessible to backend using container name as hostname

- **Nginx (Reverse Proxy)**
  - Routes traffic to appropriate services
  - Handles domain routing for frontend and API
  - Configured to serve frontend static files
  - Proxies API requests to backend service

## API Endpoints

- `GET /api/users`: Retrieve all users
- `POST /api/users`: Create a new user

## Environment Variables

### Backend
- `MONGO_URL`: MongoDB connection string (default: `mongodb://database:27017`)

## Network Configuration

The application uses a Docker network named `my-network` for inter-container communication. Services can reference each other using their service names as hostnames:
- Frontend: `http://frontend`
- Backend: `http://backend`
- Database: `mongodb://database:27017`

## Development

### Frontend Development
```bash
cd client
npm install
npm start
```

### Backend Development
```bash
cd api
dotnet restore
dotnet run
```

## Production Deployment

1. Ensure all containers are built:
   ```bash
   docker-compose build
   ```

2. Start the services:
   ```bash
   docker-compose up -d
   ```

3. Monitor logs:
   ```bash
   docker-compose logs -f
   ```

## Troubleshooting

1. **Cannot access localhost.sportz.io**
   - Verify hosts file configuration
   - Ensure nginx container is running
   - Check nginx logs: `docker logs nginx`

2. **Database Connection Issues**
   - Verify MongoDB container is running
   - Check MongoDB logs: `docker logs database`
   - Verify connection string in appsettings.json

3. **CORS Issues**
   - Check CORS configuration in Program.cs
   - Verify frontend URL in CORS policy
   - Ensure nginx is properly routing requests

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request
