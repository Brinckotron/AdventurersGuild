# Adventurer's Guild - Game Design Document

## Game Overview
Adventurer's Guild is a strategic management game where players take on the role of a guild master, managing a team of adventurers, assigning them to quests, and growing their guild's reputation and resources.

## Core Gameplay Loop
1. Recruit and manage adventurers
2. Assign adventurers to a party and send them on quests
3. Complete quests to earn rewards and reputation
4. Upgrade and maintain guild facilities
5. Manage randomized events based on progression

## Game Systems

### Adventurer System
- Each adventurer has unique stats and abilities
- Adventurers gain experience and level up
- Adventurers can be given an item to help in quests
- Adventurers can be injured or die on quests
- Adventurers need to rest and recover from injuries

### Quest System
- Various types of quests (combat, exploration, protection, gathering)
- Quests have different difficulty levels

### Guild Management
- Manage guild resources (gold, wood, stone, iron, magic crystals, reputation)
- Upgrade guild facilities
- Recruit new adventurers
- Handle clients and their quests

### Party System
- Create and manage parties of adventurers
- Assign parties to quests
- Track party status and progress
- Manage party equipment

## Features to Implement

### Core Systems
- [ ] Adventurer class with stats and abilities
- [ ] Party system for grouping adventurers
- [ ] Quest system with different types and difficulties
- [ ] Guild management system
- [ ] Resource management system
- [ ] Time management & notifications system
- [ ] Experience and leveling system
- [ ] Equipment and inventory system
- [ ] Save/Load system

### Game Mechanics
- [ ] Adventurer recruitment and management
- [ ] Quest assignment and completion
- [ ] Party formation and management
- [ ] Resource gathering and management
- [ ] Guild upgrades and expansion
- [ ] Combat system (if implemented)
- [ ] Random events and encounters

### UI/UX
- [ ] Main menu and game setup
- [ ] Guild management interface (Guild overiew, basic game view)
- [ ] Adventurer management interface (list, with status and basic info, sortable, each adventurer is clickable to expand detailed view in  secondary window)
- [ ] Map interface with visual nodes (nodes become permanently visible once discovered)
- [ ] Quest/Party assignment interface (Party is formed to complete specific quest, disbanded upon return)
- [ ] Resource management interface (probably just a small part of the guild overview, always visible in the upper right corner of the screen)
- [ ] Time display and notification tab
- [ ] Save/Load interface
- [ ] Settings and options menu

### Technical Features
- [ ] Data persistence
- [ ] Game state management
- [ ] Event system
- [ ] Input handling
- [ ] Audio system
- [ ] Performance optimization
- [ ] Error handling and logging

## Technical Architecture

### Core Systems
- GameManager: Central game state management
- AdventurerManager: Handles adventurer creation and management
- PartyManager: Manages party formation and assignments
- MapManager: Handles map interactions and party movement during quests
- QuestManager: Handles quest generation and tracking
- RandomEventManager: Handles the random events that can happen during gameplay
- TimeManager: Handles the passing of time.
- NotificationManager: Handles notifications from different sources 
- ResourceManager: Manages game resources and economy
- SaveManager: Handles game saving and loading

### Data Structures
- Adventurer: Core character data and behavior
- Party: Group of adventurers
- Quest: Mission data and requirements
- Resource: Game resources and economy
- SaveData: Game state persistence

### Unity Integration
- ScriptableObjects for data configuration
- Prefabs for visual representation
- UI system for game interfaces
- Scene management for different game states

## Development Roadmap

### Phase 1: Core Systems
1. Implement basic adventurer system
2. Create Map
3. Develop quest system
4. Implement Time and Notification systems
5. Implement resource management
6. Add save/load functionality

### Phase 2: Game Mechanics
1. Add adventurer recruitment
2. Implement quest assignment
3. Create party management
4. Add resource gathering
5. Implement guild upgrades

### Phase 3: UI/UX
1. Create main menu
2. Implement guild interface
3. Add adventurer management
4. Create quest interface
5. Implement resource management

### Phase 4: Polish
1. Add sound effects and music
2. Implement visual effects
3. Add tutorial system
4. Balance game mechanics
5. Bug fixing and optimization 

## UI Conceptualization

### 1. Main UI Layout Structure
```
+------------------------------------------+
|  Primary Header                          |
|  +--------------------------------------+|
|  | Logo | Time | Gold: 1000 | Wood: 500 ||
|  |      |      | Stone: 300 | Iron: 200 ||
|  |      |      | Crystals:50| Rep: 75   ||
|  +--------------------------------------+|
|                                          |
|  +------------------+  +---------------+ |
|  | Main Panel       |  | Secondary     | |
|  | +--------------+ |  | Panel         | |
|  | | [Guild][Map] | |  | +-----------+ | |
|  | +--------------+ |  | | [Details] | | |
|  |                  |  | | [Adventur]| | |
|  | Guild View       |  | | [Quests]  | | |
|  | or Map View      |  | +-----------+ | |
|  |                  |  |               | |
|  |                  |  | Details:      | |
|  |                  |  | - Building    | |
|  |                  |  | - Node        | |
|  |                  |  | - Party       | |
|  |                  |  |               | |
|  |                  |  | OR            | |
|  |                  |  |               | |
|  |                  |  | Adventurers:  | |
|  |                  |  | - List with   | |
|  |                  |  |   icons       | |
|  |                  |  |               | |
|  |                  |  | OR            | |
|  |                  |  |               | |
|  |                  |  | Quests:       | |
|  |                  |  | - Active      | |
|  |                  |  | - Pending     | |
|  |                  |  | - Completed   | |
|  +------------------+  +---------------+ |
|                                          |
|  +--------------------------------------+|
|  | Footer                               ||
|  | [Notifications]                      ||
|  +--------------------------------------+|
+------------------------------------------+
```

### 2. Panel Descriptions and Interactions

#### Main Panel (Left Side)
- Contains Guild and Map tabs
- Guild View: Shows buildings at the base
- Map View: Shows nodes and parties on quests
- Expands to full width when secondary panel is collapsed
- Interaction: 
  - Click buildings in Guild view
  - Click nodes/parties in Map view
  - Toggle secondary panel visibility

#### Secondary Panel (Right Side)
- Three tabs: Details, Adventurers, Quests
- Details Tab: Shows information about last clicked object
- Adventurers Tab: List view with minimal details (icon, name, class, level, status)
- Quests Tab: Organized by status (Active/Pending/Completed)
- Collapsible panel
- Interaction:
  - Switch between tabs
  - Click collapse button to hide/show
  - Click adventurer for more details
  - Click quest for more details

### 3. UI State Management

#### Main Panel States
- Guild: Shows guild buildings and facilities
- Map: Shows nodes and parties on quests

#### Secondary Panel States
- Details: Shows information about selected object
- Adventurers: Shows list of guild members
- Quests: Shows quest list by status
- Hidden: Panel is collapsed

### 4. Key UI Interactions

#### Building Interaction Flow
1. Click building in Guild view
2. Secondary panel opens (if closed)
3. Building details show in Details tab
4. Manage building from details panel

#### Map Interaction Flow
1. Click Map tab in main panel
2. Map view appears
3. Click node or party
4. Details show in secondary panel
5. Manage node/party from details

#### Panel Management Flow
1. Click collapse button on secondary panel
2. Secondary panel slides away
3. Main panel expands to full width
4. Click again to restore secondary panel 