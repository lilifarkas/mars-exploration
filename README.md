# Mars Exploration

Mars Exploration is a console application that simulates the movement of a Rover on Mars to explore and map colonization possibilities. The project consists of two main projects: the Mapgenerator and the Mapexplorer.

## Mapgenerator

The Mapgenerator is responsible for generating the map of Mars. It creates a representation of the planet's surface, including various obstacles. The generated map serves as the environment for the Rover to explore.

## Mapexplorer

The Mapexplorer component implements the logic for the Rover to navigate and explore the generated map. It simulates the movement and actions of the Rover, such as collecting data, and identifying potential colonization areas.

## Getting Started

To run the Mars Exploration application, follow these steps:
1. Clone the repository:

   ```powershell
   git clone https://github.com/lilifarkas/mars-exploration.git
   ```
2.Navigate to the project directory:

   ```powershell
   Codecool.MarsExploration.MapExplorer
   ```
3. Run the Mapexplorer:

   ```powershell
   dotnet run --project Mapexplorer
   ```

## Project Structure
The project structure is organized as follows:

mars-exploration/
├── Mapgenerator/
│   ├── Calculators
│   ├── Configuration
│   └── MapElements
│   └── Output/Service
├── Mapexplorer/
│   ├── Analyzer
│   ├── Configuration
│   └── Exploration
│   └── Logger
│   └── MapLoader
│   └── MarsRover
│   └── Movement
│   └── Resources
│   └── Simulation
│   └── UI


   
