

# AIR QUALITY API

## Overview
The **AIR QUALITY** project is a REST API built with .NET Core that retrieves and exposes air quality information for the nearest city based on provided GPS coordinates. The API utilizes the IQAir API to fetch real-time air quality data and stores the results in a PostgreSQL database.

## Features
- Retrieve air quality data for the nearest city based on latitude and longitude.
- Periodically fetch and store air quality data for Paris every minute using a CRON job.
- Endpoint to retrieve the date and time when Paris was most polluted.

## Technology Stack
- **Backend**: .NET Core 8
- **Database**: PostgreSQL
- **API**: IQAir API for air quality data
- **HTTP Client**: HttpClient for making API requests
- **Entity Framework**: For database interactions

## Getting Started

### Prerequisites
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (Docker recommended)
- IQAir API key (register [here](https://www.iqair.com/fr/dashboard/api))

### Installation

1. **Clone the Repository**:
   ```bash
   https://github.com/Mina-Sayed/AirQualityApi.git
   cd AirQualityApi
   ```

2. **Setup Database**:
   Ensure PostgreSQL is running. You can use Docker to run a PostgreSQL container:
   ```bash
   docker run --name airqualitydb -e POSTGRES_USER=youruser -e POSTGRES_PASSWORD=yourpassword -e POSTGRES_DB=AirQualityDb -p 5432:5432 -d postgres
   ```

3. **Configure Application**:
   Open `appsettings.json` and add your IQAir API key:
   ```json
   {
       "IQAir": {
           "ApiKey": "YOUR_API_KEY_HERE"
       },
       "ConnectionStrings": {
           "DefaultConnection": "Host=localhost;Database=AirQualityDb;Username=youruser;Password=yourpassword"
       }
   }
   ```

4. **Install Dependencies**:
   Restore NuGet packages:
   ```bash
   dotnet restore
   ```

5. **Run Migrations**:
   If using Entity Framework, apply migrations to create the database schema:
   ```bash
   dotnet ef database update
   ```

6. **Run the Application**:
   Start the API:
   ```bash
   dotnet run
   ```

## API Endpoints

### 1. Get Nearest City Air Quality
- **Endpoint**: `GET /api/AirQuality/nearest-city`
- **Query Parameters**:
  - `latitude`: Latitude of the location
  - `longitude`: Longitude of the location

#### Example Request:
```bash
curl -X GET "http://localhost:5005/api/AirQuality/nearest-city?latitude=48.856613&longitude=2.352222"
```

#### Response:
```json
{
    "city": "Paris",
    "latitude": 48.856613,
    "longitude": 2.352222,
    "AQI": 42,
    "retrievedAt": "2024-09-24T16:00:00Z"
}
```

### 2. Get Most Polluted Time in Paris
- **Endpoint**: `GET /api/AirQuality/most-polluted`

#### Example Request:
```bash
curl -X GET "http://localhost:5005/api/AirQuality/most-polluted"
```

#### Response:
```json
{
    "retrievedAt": "2024-09-24T15:30:00Z"
}
```

## CRON Job
A CRON job is implemented to fetch air quality data for Paris every minute and store it in the database. This feature ensures that the air quality data is always up to date.

## Documentation
- The project uses Swagger for API documentation. You can access it at `http://localhost:5005/swagger` when the application is running.

## Running Tests
To run tests, use the following command:
```bash
dotnet test
```

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments
- [IQAir API](https://www.iqair.com/fr/commercial/air-quality-monitors/airvisual-platform/api) for providing air quality data.  How to Use the README
1. Replace `yourusername` in the clone URL with your actual GitHub username.
2. Replace `YOUR_API_KEY_HERE` with your actual IQAir API key.
3. Adjust any other details specific to your setup (e.g., database username and password).
4. Feel free to add any additional sections or modify the content to better fit your project's specifics.
