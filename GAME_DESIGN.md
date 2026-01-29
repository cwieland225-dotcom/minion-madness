# Minion Madness – Design Notes

## Core Loop
1. **Select a Master** (player avatar with a unique passive + active skill).
2. **Capture towers** on the hex grid.
3. **Summon monsters** based on tower control.
4. **Expand control** to outpace the opponent.

## World & Grid
- **Hex grid** (axial coordinates `q, r`).
- **Tile types**: plain, forest, mountain, water, tower.
- **Towers** are neutral at start and can be captured by occupying/defeating defenders.

## Victory Condition
- Control **all towers** or reach a **tower control threshold** for a set number of turns.

## Summoning System
- **Summon capacity** = `base_capacity + towers_controlled`.
- **Summon cost**: each monster has a cost; total cost can’t exceed capacity.
- **Scaling**: towers can grant **bonus capacity** or **unique summons**.

## Masters
Each master should include:
- **Passive**: always-on buff.
- **Active**: cooldown ability.
- **Summon affinity**: bonus to a monster archetype.

Example masters:
- **Arc Warden**: Passive +1 summon capacity; Active: lightning strike.
- **Beast Caller**: Passive +10% monster HP; Active: summon a free wolf.
- **Grave Binder**: Passive: undead units revive once; Active: area curse.

## Monsters
- **Archetypes**: melee, ranged, support, siege.
- **Stats**: HP, attack, range, movement, cost, tags.
- **Abilities**: optional special rules (e.g., flying, armor).

## Tower Rules
- **Capture**: end turn with a unit on an uncaptured tower.
- **Defense**: towers can provide a local buff (e.g., +1 defense adjacent).
- **Income**: optional resource generation per tower.

## Turn Structure (Tactics-style)
1. **Upkeep** (cooldowns, control checks, income).
2. **Summon phase** (within capacity limits).
3. **Movement phase**.
4. **Combat phase**.
5. **End phase** (capture towers, victory check).

## Hex Grid Implementation Notes (Unity)
- **Coordinate system**: axial or cube; axial recommended for simplicity.
- **Neighbors**: 6 directions `(1,0) (1,-1) (0,-1) (-1,0) (-1,1) (0,1)`.
- **Distance**: `distance = (abs(q1-q2) + abs(q1+r1-q2-r2) + abs(r1-r2)) / 2`.

## Suggested MVP Scope
- Small map (8x8-ish hexes).
- 2 masters.
- 3 monster types.
- 4 towers.
- Basic AI to capture nearest tower.

## Next Steps
- Define monster roster and tower bonuses.
- Implement grid + selection + pathing.
- Implement turn system and UI for capacity.

