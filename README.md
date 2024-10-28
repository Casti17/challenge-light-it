Project Setup Instructions
==========================

Prerequisites
-------------

1.  **Docker**: Ensure Docker is installed and running on your computer. You can download Docker from Docker's official website.

2.  **Environment Variables**: Set up required environment variables by following the instructions below.

Setup Steps
-----------

1.  **Modify Main Environment File**: In the main directory, you can edit the example.env file with the information needed for your environment.

2.   **Create Environment File**: Also, `challenge-patient-registration` directory, create an `.env` file to configure the frontend endpoints. Add the following lines to this file:

    `REACT_APP_API_URL=http://localhost:5000/api`
    
    `REACT_APP_PICTURE_URL=http://localhost:5000`

3.  **Start Docker Containers**:

    -   Open a terminal in the main project folder (the folder containing both `backend` and `frontend` directories).

    -   Run the following command to build and start the application:

        `docker-compose --env-file environment.env up --build -d`

4.  **.NET SDK Setup**:

    -   If you encounter issues with the .NET SDK, you may need to pull it manually by running:

        `docker pull mcr.microsoft.com/dotnet/sdk:8.0`

5.  **Verify and Update Environment Variables**:

    -   Ensure that the environment variables in the `.env` file are correctly configured for your setup. Modify them as needed to match your specific environment.

Accessing the Application
-------------------------

-   **Frontend**: Once the containers are up and running, you can access the frontend by navigating to <http://localhost:3001> in your web browser.
-   **Backend**: The backend API should be available at <http://localhost:5000>.
