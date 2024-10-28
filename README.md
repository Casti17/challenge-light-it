Project Setup Instructions
==========================

Prerequisites
-------------

1.  **Docker**: Ensure Docker is installed and running on your computer. You can download Docker from Docker's official website.

2.  **Environment Variables**: Set up required environment variables by following the instructions below.

Setup Steps
-----------

1.  **Modify Main Environment File**: In the main directory, you can edit the example.env file with the information needed for your environment.

2.  **Modify appsettings File for backend**: There is an appsettings.sample.json file for the backend environment variables. Edit with the corresponding information according to your environment. Remove the **sample** text after finished.

3.   **Create Environment File for frontend**: Create an `.env` file to configure the frontend endpoints in the `challenge-patient-registration` directory.  Add the following lines to this file:

    `REACT_APP_API_URL=http://localhost:5000/api`
    
    `REACT_APP_PICTURE_URL=http://localhost:5000`

4.  **Start Docker Containers**:

    -   Open a terminal in the main project folder (the folder containing both `backend` and `frontend` directories).

    -   Run the following command to build and start the application:

        `docker-compose --env-file environment.env up --build -d`

5.  **.NET SDK Setup**:

    -   If you encounter issues with the .NET SDK, you may need to pull it manually by running:

        `docker pull mcr.microsoft.com/dotnet/sdk:8.0`

6.  **Verify and Update Environment Variables**:

    -   Ensure that the environment variables in the `.env` file are correctly configured for your setup. Modify them as needed to match your specific environment.

Accessing the Application
-------------------------

-   **Frontend**: Once the containers are up and running, you can access the frontend by navigating to <http://localhost:3001> in your web browser.
-   **Backend**: The backend API should be available at <http://localhost:5000>.


Disclaimers
-------------------------
-  The mail service was implemented using Mailtrap.
![image](https://github.com/user-attachments/assets/2d096cbd-4ff2-4cb5-a191-d6be6330211d)
-  As requested, the SMS service was created but not implemented.
