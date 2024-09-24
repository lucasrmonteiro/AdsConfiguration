
# AdsConfiguration

## Project Overview
AdsConfiguration is a .NET-based application designed for managing advertisement configurations across various platforms. The project includes APIs, UI components, and testing modules for seamless integration and functionality.

## Features
- RESTful API for managing ads configurations.
- User interface for configuration management.
- Unit and integration tests to ensure reliability.
- Docker support for containerization and easy deployment.

## Technologies Used
- **Backend**: C#, ASP.NET Core
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **Containerization**: Docker

## Getting Started

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Installation

1. Clone this repository to your local machine:
    ```bash
    git clone https://github.com/lucasrmonteiro/AdsConfiguration.git
    ```

2. Navigate to the project directory:
    ```bash
    cd AdsConfiguration
    ```

3. Build the Docker containers:
    ```bash
    docker-compose build
    ```

4. Start the application using Docker:
    ```bash
    docker-compose up
    ```

5. The API will be available at `http://localhost:5000` and the UI at `http://localhost:3000`.

### Running Tests

To run the unit and integration tests, use the following command:

```bash
dotnet test
```

## Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature:
    ```bash
    git checkout -b feature-name
    ```
3. Commit your changes:
    ```bash
    git commit -m "Add feature"
    ```
4. Push to the branch:
    ```bash
    git push origin feature-name
    ```
5. Submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Contact

For any queries, please contact the project maintainer at lucasrmonteiro@example.com.
