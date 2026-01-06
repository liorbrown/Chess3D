# Chess3D ♟️

A 3D chess game implementation in C# demonstrating core software design patterns as part of a BSc Software Engineering coursework in Design Patterns.

## 📋 About

Chess3D is an academic project that extends traditional chess into a three-dimensional board space while showcasing the practical application of four fundamental design patterns:

- **Singleton Pattern** - Centralized game state management
- **Strategy Pattern** - Flexible piece movement behaviors
- **Decorator Pattern** - Dynamic piece ability enhancement
- **Factory Pattern** - Streamlined piece creation

## 🎓 Academic Context

**Course:** Design Patterns  
**Degree:** BSc in Software Engineering  
**Focus:** Implementation and application of GoF Design Patterns

## 🏗️ Architecture & Design Patterns

### 1. Singleton Pattern

Ensures single instances of critical game components: 

```csharp
// Board - Manages the 3D game grid
public static Board getInstance()
{
    if (Board._instance == null)
        Board._instance = new Board();
    return Board._instance;
}

// PiecesFactory - Centralized piece creation
public static PiecesFactory getInstance()

// GameManager - Controls game flow and rules
public static GameManager getInstance()
```

**Purpose:** Prevents multiple instances of the game board, factory, and manager, ensuring consistent game state.

### 2. Strategy Pattern

Defines interchangeable movement algorithms for different piece types:

```csharp
interface IMovingStrategy
{
    List<Move> getValidMoves(IPiece piece);
}
```

**Implementations:**
- `FixedMovingStrategy` - For pieces like King and Knight with fixed move patterns
- `SlidingStrategy` - For pieces like Rook, Bishop, and Queen that can slide across the board
- `PawnMoveStrategy` - Special movement rules for pawns

**Purpose:** Encapsulates piece movement logic, making it easy to modify or extend without changing piece classes.

### 3. Decorator Pattern

Dynamically adds special abilities to pieces:

```csharp
// BenetDecorator - Alternates piece color on each move
class BenetDecorator : IPiece
{
    public PieceColor getColor()
    {
        this._color = 1 - this._color;
        return this._color;
    }
}

// SarvanDecorator - Allows piece to "stay in place" as a move
class SarvanDecorator : IPiece
{
    public List<(int, int)> getDirections()
    {
        List<(int, int)> directions = this._decorated.getDirections();
        directions.Add((0, 0)); // Stay in place
        return directions;
    }
}

// TrumpDecorator - Amplifies piece power (10x cost, all-directional movement)
class TrumpDecorator : IPiece
{
    public uint getCost()
    {
        return this._decorated.getCost() * 10;
    }
}
```

**Purpose:** Adds functionality to pieces at runtime without modifying their base classes. 

### 4. Factory Pattern

Centralizes and simplifies piece instantiation:

```csharp
public IPiece CreatePiece(PieceType type, PieceColor color, Position bornPos)
{
    switch (type)
    {
        case PieceType. PAWN:
            return new Pawn(color, bornPos, new PawnMoveStrategy());
        case PieceType.KNIGHT: 
            return new SarvanDecorator(new Knight(color, bornPos, new FixedMovingStrategy()));
        case PieceType.BISHOP:
            return new BenetDecorator(new Bishop(color, bornPos, new SlidingStrategy()));
        // ... more pieces
    }
}
```

**Purpose:** Encapsulates complex object creation logic and automatically applies decorators to specific pieces.

## 🎮 Game Features

- **3D Board:** Chess played across three vertical layers (heights)
- **Traditional Pieces:** Pawn, Rook, Knight, Bishop, Queen, King
- **Enhanced Abilities:** Special decorators modify piece behavior
- **Position System:** 3D coordinates (file, rank, height)
- **Rule Engine:** Validates moves and checks game state
- **Promotion System:** Pawns can promote to other pieces
- **Cost Calculation:** Tracks total piece value for each player

## 📁 Project Structure

```
Chess3D/
├── Pieces/
│   ├── IPiece.cs              # Piece interface
│   ├── Piece.cs               # Base piece implementation
│   ├── Pawn.cs
│   ├── Rook.cs
│   ├── Knight.cs
│   ├── Bishop.cs
│   ├── Queen.cs
│   └── King.cs
├── Decorators/
│   ├── BenetDecorator.cs      # Color-switching decorator
│   ├── SarvanDecorator.cs     # Stay-in-place decorator
│   └── TrumpDecorator. cs      # Power amplification decorator
├── Strategies/
│   ├── IMovingStrategy.cs     # Strategy interface
│   ├── FixedMovingStrategy.cs
│   ├── SlidingStrategy.cs
│   └── PawnMoveStrategy.cs
├── Core/
│   ├── Board.cs               # Singleton - Game board
│   ├── GameManager.cs         # Singleton - Game controller
│   ├── PiecesFactory.cs       # Singleton Factory - Piece creation
│   ├── RuleEngine.cs          # Game rules validation
│   ├── Position.cs            # 3D position representation
│   └── Move.cs                # Move representation
├── Enums/
│   ├── PieceType.cs
│   ├── PieceColor.cs
│   └── GameResult. cs
└── Program.cs                 # Entry point
```

## 🛠️ Technologies

- **Language:** C#
- **Framework:** .NET
- **Paradigm:** Object-Oriented Programming
- **Patterns:** Singleton, Strategy, Decorator, Factory

## 🚀 Getting Started

### Prerequisites

- .NET SDK (6.0 or later)
- Visual Studio or any C# IDE

### Building the Project

```bash
# Clone the repository
git clone https://github.com/liorbrown/Chess3D.git

# Navigate to project directory
cd Chess3D

# Build the project
dotnet build

# Run the game
dotnet run
```

## 🎯 Learning Objectives Demonstrated

1. **Singleton Pattern**
   - Single source of truth for game state
   - Resource management and access control

2. **Strategy Pattern**
   - Behavioral flexibility
   - Open/Closed principle compliance
   - Algorithm encapsulation

3. **Decorator Pattern**
   - Runtime behavior modification
   - Composition over inheritance
   - Flexible feature addition

4. **Factory Pattern**
   - Object creation abstraction
   - Dependency management
   - Centralized instantiation logic

## 🔍 Key Design Decisions

- **3D Coordinate System:** Custom `Position` class handles (file, rank, height) coordinates
- **Decorator Application:** Knights automatically receive `SarvanDecorator`, Bishops get `BenetDecorator`
- **Strategy Assignment:** Each piece type is paired with its appropriate movement strategy
- **Immutable Game Rules:** Core chess logic is preserved while adding 3D extensions

## 📚 Design Pattern Benefits Observed

| Pattern | Benefit | Example in Project |
|---------|---------|-------------------|
| **Singleton** | Consistent state | Single Board instance prevents conflicts |
| **Strategy** | Easy extensibility | New movement types add without modifying pieces |
| **Decorator** | Dynamic features | Pieces gain abilities without class explosion |
| **Factory** | Simplified creation | Complex piece setup handled in one place |

## 🤝 Contributing

This is an academic project. Feedback and suggestions are welcome through issues or pull requests.

## 📄 License

This project is developed for educational purposes as part of university coursework. 

## 👤 Author

**Lior Brown** ([@liorbrown](https://github.com/liorbrown))  
BSc Software Engineering Student

---

*This project demonstrates practical application of design patterns in a game development context, showing how theoretical concepts translate to real-world code architecture.*
