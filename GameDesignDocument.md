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

![Overall UI Layout](UI_Layout/UI_Layout.png)
*Overall UI layout structure*

### 1. Overall UI Structure

- **Header Bar:**  
  - Displays the guild name, current day and time, and all tracked resources (Gold, Wood, Iron, Magic Crystals).
- **Main Panel:**  
  - Contains two primary tabs: **Guild** and **Map**.
  - The content of this panel changes based on the selected tab.
- **Secondary Panel (Right):**  
  - Contains three tabs: **Details**, **Quests**, and **Adventurers**.
  - Can be shown or hidden using a toggle button. When hidden, the main panel expands to fill the space.
- **Notifications:**  
  - Displayed in the bottom left corner, providing alerts and events to the player.

---

### 2. Main Panel Use Cases

#### a. Guild Tab
- **Default View:**  
  - Shows a spatial layout of guild buildings and adventurers.
- **Selecting a Building:**  
  - Highlights the building.
  - The **Details** tab in the secondary panel displays information about the building (purpose, status, and, for the guildhall, comprehensive guild info).

  ![Building Details Example](UI_Layout/UI_Layout%20-%20Details%20-%20Building.png)
  *Details panel showing a selected building (Guildhall) in the Guild view*

- **Selecting an Adventurer:**  
  - Highlights the adventurer.
  - The **Details** tab displays adventurer information (name, class, level, status, and possibly stats like kills or quests completed).

  ![Adventurer Details Example](UI_Layout/UI_Layout%20-%20Details%20-%20Adventurer.png)
  *Details panel showing a selected adventurer in the Guild view*

#### b. Map Tab
- **Default View:**  
  - Shows a node-based map representing locations and connections.
- **Selecting a Node:**  
  - Highlights the node.
  - The **Details** tab displays basic information about the location.

  ![Node Details Example](UI_Layout/UI_Layout%20-%20Details%20-%20Node.png)
  *Details panel showing a selected node in the Map view*

- **Selecting a Party:**  
  - Highlights the party (represented by a diamond) on a node.
  - The **Details** tab displays party information (active quest, current status, list of adventurers, held items, and action buttons for resolving events or abandoning quests).

  ![Party Details Example](UI_Layout/UI_Layout%20-%20Details%20-%20Party.png)
  *Details panel showing a selected party in the Map view*

- **Quest Location Marker:**  
  - Triangles indicate quest locations on the map.

---

### 3. Secondary Panel Use Cases

- **Details Tab:**  
  - Context-sensitive; shows information about the last selected object (building, adventurer, node, or party).
- **Quests Tab:**  
  - Lists all quests, divided into:
    - **Active Quests:** With assigned parties; double-clicking may switch to party details.

      ![Active Quests Example](UI_Layout/UI_Layout%20-%20Quests%20-%20QuestActive.png)
      *Quests tab showing active quests and their assigned parties*

    - **Pending Quests:** Awaiting party assignment, with a button to assign a party and start the quest.

      ![Pending Quests Example](UI_Layout/UI_Layout%20-%20Quests%20-%20QuestPending.png)
      *Quests tab showing pending quests and assignment options*

    - **Completed Quests:** (Implied as a possible section.)
- **Adventurers Tab:**  
  - Lists all guild members with minimal details (icon, name, class, level, status).

---

### 4. Panel Behavior and Interaction Flow

- The secondary panel can be shown or hidden with a toggle button. When hidden, the main panel expands to use the full width of the screen.
- **Guild Tab Flow:**  
  - Click buildings or adventurers to view their details in the secondary panel.
- **Map Tab Flow:**  
  - Click nodes, parties, or quest markers to view details or take actions in the secondary panel.
- **Quests Tab Flow:**  
  - Manage quest assignments and view quest status.
- **Adventurers Tab Flow:**  
  - Quick overview of all guild members.
- **Notifications:**  
  - Always visible in the bottom left; clicking may open more detailed information or actions.

---

### 5. Visual Cues and Usability

- The currently selected/focused element is highlighted (yellow border or fill).
- The active tab in both the main and secondary panels is visually distinct.
- The UI is designed for clarity, with a strong separation between navigation (main panel) and context-sensitive information/actions (secondary panel).

**This documentation formalizes the intended UI behavior and layout as illustrated in your images, ensuring a clear reference for both design and implementation.** 

## Notifications System Conceptualization

### 1. Event Types and Behaviors

#### Map Events
- **Critical Events (Pause Game Flow)**
  - Party reached node (resolve node content)
  - Party completed node (player chooses next node to travel to)
  - Quest Completed
- **Standard Events**
  - New location discovered
  - Adventurer Died

#### Guild Events
- **Critical Events (Pause Game Flow)**
  - NPC visits (Traveling Merchant, possible client with quest, possible new recruit)
  - Disease spreads
  - Fire breaks out
- **Standard Events**
  - Building construction completed
  - Building upgrade completed
  - New quest received
  - Adventurer training completed
  - Item crafted
  - Adventurer recovered (from tired, injured or diseased state)

### 2. UI Components

#### Visual Elements
- **Main Notification Icon (Bottom Left)**
  - Flashes when new notifications arrive
  - Critical notifications trigger immediate popup
  - Clickable to resolve notifications
- **Notification List**
  - Scrollable list of current notifications
  - Newer notifications appear at the top
  - Unresolved notifications are clickable
  - Resolved notifications remain visible but inactive
- **History View**
  - Access to all past notifications
  - Maintains record of resolved notifications

#### Visual States
- **Critical Notifications**
  - Flashing icon
  - Popup window
  - Game paused until resolved
- **Standard Notifications**
  - Faintly glowing text
  - No game interruption
  - Can be resolved at player's convenience

### 3. Interaction Flow

#### Critical Notification Process
1. Game pauses
2. Main icon flashes
3. Player must resolve before continuing
4. Popup Appears on player click if appropriate
5. Notification moves to history

#### Standard Notification Process
1. Added to notification list
2. Gentle glow animation
3. Audio cue plays
4. Player can resolve at any time
5. Moves to history when resolved

#### Resolution Behavior
- Clicking unresolved notification:
  1. Opens relevant main panel tab
  2. Selects appropriate object
  3. Opens relevant secondary panel tab
  4. Shows popup if required
  - **Examples:**
    - Party reached node: Opens map tab, selects party, opens details tab, shows node resolution popup
    - Item crafted: Opens guild tab, selects guildhall, opens details tab, shows storage popup

### 4. Technical Structure



### 5. Queue Management

- **Critical Queue**
  - Processes one notification at a time
  - Must be resolved to continue game
  - Maintains order of critical events
- **Standard Queue**
  - Multiple notifications can exist simultaneously
  - No resolution order enforced
  - Automatically sorted by timestamp

### 6. Future Considerations

#### Planned for Later Implementation
- Different sounds for different notification types
- Notification settings customization
- Notification filtering options
- Accessibility features

#### Edge Cases to Address
1. **Multiple Critical Notifications**
   - Critical notifications must be resolved in order of occurrence
   - No dismissal or deferral allowed
   - System will queue critical notifications and process them one at a time using a priority system and FIFO
   - Game remains paused until all critical notifications are resolved
   - Visual indicator shows number of pending critical notifications
   - Priority system for simultaneous critical events:
     - Emergency events (fire, disease) have highest priority
     - Quest-related events have medium priority
     - NPC visits have lowest priority

2. **Obsolete Notifications**
   - System includes failsafe for handling obsolete notifications
   - If notification references become null or irrelevant:
     - Notification remains in list
     - Clicking notification marks it as resolved without any action
     - Prevents errors and crashes
     - Maintains system simplicity

3. **Save/Load Functionality**
   - Unresolved notifications persist through save/load
   - Save process includes validation of notification references
   - Obsolete notifications are automatically resolved during load
   - Critical notifications maintain their priority in the queue after load

4. **Notification Chain Reactions**
   - New critical notifications triggered during resolution of another notification
   - New notifications are added to the queue respecting priority placement
   - Current notification resolution continues
   - New notifications will be processed in order after current resolution

5. **Notification List Management**
   - Maximum of 30 notifications in the active list
   - Notifications pushed out of the active list are automatically resolved
   - All notifications are added to the guild journal/history
   - History only maintains notification text, not interactive elements

6. **UI State Conflicts**
   - Critical notifications have priority over all UI interactions
   - Current UI state is interrupted when critical notification arrives
   - Player must resolve critical notification before returning to previous UI state
   - Previous UI state is restored after notification resolution

7. **Resource-Related Notifications**
   - Resource notifications (e.g., "Low on gold") are informational only
   - No specific resolution required
   - Clicking simply acknowledges the notification
   - Auto-resolved if the condition no longer exists

8. **Multi-Event Notifications**
   - Each notification must reference a specific game element by name
   - Example: "Item crafted: Potion of Healing"
   - Example: "Building Completed: Training Grounds"
   - Similar events generate separate notifications for clarity
   - No grouping of similar notifications 