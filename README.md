# String Calculator

A full-stack mathematical expression evaluator with a .NET backend and Vue.js frontend.

## Features

- Basic arithmetic: `+`, `-`, `*`, `/` with proper operator precedence
- Exponentiation: `^`
- Functions: `sqrt()`
- Parentheses, decimals, and negative numbers
- Real-time error handling
- RESTful API with CORS support
- Clean Material Design UI

## Technology Stack

**Backend:** .NET 9.0, ASP.NET Core, C# 12, xUnit
**Frontend:** Vue 3, TypeScript, Vite, Vuetify 3
**Architecture:** Clean architecture with dependency injection, tokenizer → parser → evaluator pipeline

## How It Works

The calculator uses a three-stage pipeline:

1. **Tokenization** - Breaks expression into tokens (numbers, operators, functions)
2. **Parsing** - Converts infix to postfix notation (Shunting Yard algorithm)
3. **Evaluation** - Evaluates postfix expression using a stack

Example: `2+2*5+5` → tokens → postfix: `2 2 5 * + 5 +` → result: `17`

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- Node.js 18+

### Quick Start

```bash
# 1. Install dependencies
dotnet restore
cd stringcalculator-ui && npm install && cd ..

# 2. Run backend (Terminal 1)
cd StringCalculator.Api
dotnet run --launch-profile http
# API: http://localhost:5000

# 3. Run frontend (Terminal 2)
cd stringcalculator-ui
npm run dev
# UI: http://localhost:3000

# 4. Run tests
dotnet test
```

## API Endpoints

**POST** `/api/calculator/evaluate` - Evaluate an expression
```bash
curl -X POST http://localhost:5000/api/calculator/evaluate \
  -H "Content-Type: application/json" \
  -d '{"expression": "2+2*5+5"}'
# Response: {"value": 17, "expression": "2+2*5+5"}
```

**GET** `/api/calculator` - API status

## Test Cases

All 15 required test cases pass:
- `"1"` → `1`
- `"1+1"` → `2`
- `"1 + 2"` → `3`
- `"1 + -1"` → `0`
- `"-1 - -1"` → `0`
- `"5-4"` → `1`
- `"5*2"` → `10`
- `"(2+5)*3"` → `21`
- `"10/2"` → `5`
- `"2+2*5+5"` → `17`
- `"2.8*3-1"` → `7.4`
- `"2^8"` → `256`
- `"2^8*5-1"` → `1279`
- `"sqrt(4)"` → `2`
- `"1/0"` → Error (DivideByZeroException)

## Development Commands

```bash
# Backend
dotnet build                    # Build solution
dotnet watch run               # Run with hot reload
dotnet test                    # Run tests
dotnet test --logger "console;verbosity=detailed"  # Detailed test output

# Frontend
npm run dev                    # Dev server with hot reload
npm run build                  # Production build
npm run preview                # Preview production build
```

## Configuration

- **API Port:** `StringCalculator.Api/Properties/launchSettings.json` (default: 5000)
- **Frontend Port:** `stringcalculator-ui/vite.config.ts` (default: 3000)
- **CORS:** `StringCalculator.Api/Program.cs` (default: `http://localhost:3000`)
- **API URL:** `stringcalculator-ui/src/services/calculatorService.ts`

## Project Info

Developed as part of the **Ezo - Le Défi Code** challenge.

- **Stack:** .NET 9.0 + Vue 3 + TypeScript
- **Tests:** 15/15 passing ✅
- **Dependencies:** Zero external packages in core logic
