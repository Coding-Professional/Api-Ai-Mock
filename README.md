# AI-Mock: AI-Powered Interview Analysis Platform API

[![Build Status](https://img.shields.io/azure-devops/build/your-org/your-project/your-build-definition-id?style=for-the-badge)](https-link-to-your-build-pipeline)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

## 1. Vision & Purpose

This repository contains the backend infrastructure for **AI-Mock**, a multi-faceted AI-powered platform designed to revolutionize mock interview preparation. The primary goal is to move beyond subjective feedback by providing candidates with objective, data-driven metrics on their performance.

This is not just a single-feature application; it is a scalable foundation engineered to support a growing suite of analytical tools. The initial implementation provides a robust **Confidence Analysis** module, with the architecture primed for future expansion.

---

## 2. Architectural Philosophy

The foundation of this platform is **Clean Architecture**. This choice was deliberate to ensure the long-term health and scalability of the codebase.

-   **Separation of Concerns (SoC):** The strict division between the `Domain`, `Application`, `Infrastructure`, and `API` layers ensures that business logic is completely decoupled from external frameworks and dependencies.
-   **Testability:** This architecture makes the system highly testable. The core business logic in the `Application` services can be unit-tested in isolation.
-   **Maintainability:** The layered structure allows new features to be added as self-contained modules, making the system easier to manage and scale.

The solution is structured as follows:
-   `ApiAiMock`
-   `ApiAiMock.Application`
-   `ApiAiMock.Infrastructure`
-   `ApiAiMock.Domain`
-   `ApiAiMock.Tests`

---

## 3. Technology Stack

| Category               | Technology                                             |
| ---------------------- | ------------------------------------------------------ |
| **Backend Framework** | .NET 8, ASP.NET Core                                   |
| **Architecture Style** | Clean Architecture, RESTful API                        |
| **AI & Cloud Services**| Azure AI Services (Face API, Speech Service)           |
| **Testing** | xUnit                                                  |

---

## 4. Getting Started

### Prerequisites
-   [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
-   [Azure Account](https://azure.microsoft.com/en-us/free/) with access to Face API and Speech Service.
-   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).

### Configuration
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/AI-Mock.git](https://github.com/your-username/AI-Mock.git)
    cd Api-Ai-Mock
    ```
2.  **Configure secrets:** This project uses the `.NET Secret Manager` for local development.
    -   Navigate to the API project directory:
        ```bash
        cd Api-Ai-Mock
        ```
    -   Initialize user secrets:
        ```bash
        dotnet user-secrets init
        ```
    -   Set your Azure credentials:
        ```bash
        dotnet user-secrets set "AzureAiServices:FaceApi:Endpoint" "YOUR_FACE_API_ENDPOINT"
        dotnet user-secrets set "AzureAiServices:FaceApi:ApiKey" "YOUR_FACE_API_KEY"
        # Add other secrets for Speech Service etc.
        ```
3.  **Run the application:**
    ```bash
    dotnet run --project ApiAiMock
    ```
The API will be available at `https://localhost:7123`. You can access the Swagger UI at `https://localhost:7123/swagger`.

---

## 5. Project Roadmap & Vision for v2.0

The current implementation is the MVP. The vision extends to several other modules:

-   [ ] **Keyword & Content Analysis**
-   [ ] **Pacing & Fluency Metrics**
-   [ ] **Grammar & Vocabulary Suggestions**
-   [ ] **Real-time Feedback with SignalR**

---

## 6. Contributing

Contributions are welcome. Please fork the repository, create a feature branch, and submit a pull request.

---

## 7. License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.