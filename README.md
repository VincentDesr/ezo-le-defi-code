# String Calculator

A full-stack mathematical expression evaluator with a .NET backend and Vue.js frontend. The application parses and evaluates mathematical expressions with proper operator precedence, functions, and error handling.

## Features

- Evaluate mathematical expressions with proper operator precedence
- Support for basic arithmetic operations: `+`, `-`, `*`, `/`
- Exponentiation operator: `^`
- Mathematical functions: `sqrt()`
- Parentheses for expression grouping
- Decimal and negative number support
- Real-time error handling and validation
- RESTful API architecture
- Modern, responsive Material Design UI

## Project Structure

```
ezo-le-defi-code/
├── StringCalculator.Core/          # Core calculator library
│   ├── Interfaces/                 # Interface definitions
│   ├── Operators/                  # Arithmetic operator implementations
│   ├── Functions/                  # Mathematical function implementations
│   ├── Tokens/                     # Token classes for parsing
│   └── Services/                   # Calculator, tokenizer, parser, evaluator
├── StringCalculator.Api/           # ASP.NET Core Web API
│   ├── Controllers/                # API controllers
│   ├── Models/                     # DTOs and request/response models
│   └── Program.cs                  # Application entry point
├── StringCalculator.Tests/         # Unit tests (xUnit)
└── stringcalculator-ui/            # Vue 3 frontend
    └── src/
        ├── components/             # Vue components
        └── services/               # API service layer
```

## Technology Stack

### Backend
- **.NET 9.0** - Modern, cross-platform framework
- **ASP.NET Core** - Web API framework
- **C# 12** - Latest C# features with nullable reference types
- **xUnit** - Unit testing framework
- **Dependency Injection** - Built-in DI container

### Frontend
- **Vue 3** - Progressive JavaScript framework with Composition API
- **TypeScript** - Type-safe development
- **Vite** - Fast build tool and dev server
- **Vuetify 3** - Material Design component framework
- **Axios** - HTTP client for API communication

## Architecture

### Backend Architecture

The backend follows clean architecture principles with clear separation of concerns:

1. **Core Layer** (`StringCalculator.Core`)
   - Domain logic and business rules
   - Interface definitions
   - No external dependencies

2. **API Layer** (`StringCalculator.Api`)
   - HTTP endpoints and controllers
   - Request/response models (DTOs)
   - CORS configuration
   - Error handling middleware

3. **Test Layer** (`StringCalculator.Tests`)
   - Unit tests with high coverage
   - Test-driven development approach

### Expression Evaluation Pipeline

The calculator uses a three-stage pipeline:

1. **Tokenization** - Converts string expression into tokens
2. **Parsing** - Converts infix notation to postfix (Reverse Polish Notation) using Shunting Yard algorithm
3. **Evaluation** - Evaluates the postfix expression using a stack-based algorithm

## Getting Started

### Prerequisites

- **.NET 9.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Node.js 18+** and npm - [Download here](https://nodejs.org/)
- **Git** - For version control

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd ezo-le-defi-code
```

2. Restore .NET dependencies:
```bash
dotnet restore
```

3. Install frontend dependencies:
```bash
cd stringcalculator-ui
npm install
cd ..
```

### Running the Application

#### Option 1: Run Backend and Frontend Separately

**Terminal 1 - Start the API:**
```bash
cd StringCalculator.Api
dotnet run --launch-profile http
```
The API will be available at `http://localhost:5000`

**Terminal 2 - Start the Frontend:**
```bash
cd stringcalculator-ui
npm run dev
```
The UI will be available at `http://localhost:3000`

#### Option 2: Using VS Code

1. Open the project in VS Code
2. Press `F5` to launch the API in debug mode
3. In a separate terminal, run the frontend:
```bash
cd stringcalculator-ui
npm run dev
```

### Running Tests

Run all unit tests:
```bash
dotnet test
```

Run tests with detailed output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

Run tests with code coverage:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## API Documentation

### Base URL
```
http://localhost:5000/api/calculator
```

### Endpoints

#### GET /api/calculator
Get API status and server information.

**Response:**
```json
{
  "message": "String Calculator API is running",
  "serverTime": "2026-01-25T10:00:00Z",
  "localTime": "2026-01-25T11:00:00",
  "endpoint": "/api/calculator/evaluate"
}
```

#### POST /api/calculator/evaluate
Evaluate a mathematical expression.

**Request:**
```json
{
  "expression": "2+2*5+5"
}
```

**Response (Success):**
```json
{
  "value": 17,
  "expression": "2+2*5+5"
}
```

**Response (Error):**
```json
{
  "title": "Invalid expression",
  "detail": "Unexpected token at position 5",
  "status": 400
}
```

## Expression Examples

Try these expressions in the calculator:

| Expression | Result | Description |
|------------|--------|-------------|
| `1 + 2` | 3 | Simple addition |
| `2+2*5+5` | 17 | Operator precedence |
| `(2+5)*3` | 21 | Parentheses |
| `2^8` | 256 | Exponentiation |
| `sqrt(16)+4` | 8 | Square root function |
| `2.8*3-1` | 7.4 | Decimal numbers |
| `-5+10` | 5 | Negative numbers |
| `(3+4)*(5-2)` | 21 | Complex grouping |

## Development

### Backend Development

Build the solution:
```bash
dotnet build
```

Watch mode for automatic rebuilding:
```bash
cd StringCalculator.Api
dotnet watch run
```

### Frontend Development

Start dev server with hot reload:
```bash
cd stringcalculator-ui
npm run dev
```

Build for production:
```bash
npm run build
```

Preview production build:
```bash
npm run preview
```

### Code Quality

The project follows these best practices:

- **SOLID Principles** - Single responsibility, dependency injection
- **Separation of Concerns** - Clear layer boundaries
- **Interface-based Design** - Dependency abstraction
- **Nullable Reference Types** - Null safety in C#
- **Type Safety** - TypeScript on frontend
- **Error Handling** - Comprehensive exception handling
- **Logging** - Structured logging with timing metrics
- **Testing** - Unit tests with xUnit

## Configuration

### API Configuration

Edit `StringCalculator.Api/appsettings.json` for production settings.

Port configuration in `StringCalculator.Api/Properties/launchSettings.json`:
```json
{
  "http": {
    "applicationUrl": "http://0.0.0.0:5000"
  }
}
```

### CORS Configuration

The API allows requests from `http://localhost:3000` by default. Update in `Program.cs`:
```csharp
policy.WithOrigins("http://localhost:3000")
      .AllowAnyHeader()
      .AllowAnyMethod();
```

### Frontend API Configuration

Update the API base URL in `stringcalculator-ui/src/services/calculatorService.ts`:
```typescript
const BASE_URL = 'http://localhost:5000';
```

## Troubleshooting

### Port Already in Use

If port 5000 or 3000 is already in use:

**Backend:** Edit `launchSettings.json` and change the port
**Frontend:** Edit `vite.config.ts` and change `server.port`

### CORS Errors

Ensure the frontend URL matches the CORS policy in `Program.cs`

### Build Errors

Clean and rebuild:
```bash
dotnet clean
dotnet build
```

For frontend:
```bash
cd stringcalculator-ui
rm -rf node_modules package-lock.json
npm install
```

## License

This project is developed as part of the Ezo - Le Defi Code challenge.

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request
